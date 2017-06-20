using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace Qarth.Demo
{
    public class DatabaseModule : AbstractModule
    {
        private const string PROGRESS_KEY = "pailogic_level_db";
        private const string ANIMPOLT_KEY = "pailogic_animpolt_db";

        public class DataRecordCell
        {
            private string m_Key;
            private Dictionary<string, int> m_StateMap = new Dictionary<string, int>();

            public DataRecordCell(string key)
            {
                m_Key = key;
                Load();
            }

            public void RecordComplate(string levelName)
            {
                if (string.IsNullOrEmpty(levelName))
                {
                    return;
                }

                int index = levelName.LastIndexOf('-');

                if (index < 0)
                {
                    return;
                }

                string subType = levelName.Substring(0, index);

                int result = 0;
                if (m_StateMap.ContainsKey(subType))
                {
                    result = m_StateMap[subType];
                    m_StateMap.Remove(subType);
                }

                int levelIndex = int.Parse(levelName.Substring(index + 1));

                result |= 1 << levelIndex;

                m_StateMap.Add(subType, result);

                Sava();
            }

            public bool IsComplate(string levelName)
            {
                if (string.IsNullOrEmpty(levelName))
                {
                    return false;
                }

                int index = levelName.LastIndexOf('-');

                if (index < 0)
                {
                    return false;
                }

                string subType = levelName.Substring(0, index);
                if (!m_StateMap.ContainsKey(subType))
                {
                    return false;
                }

                int result = m_StateMap[subType];

                int levelIndex = int.Parse(levelName.Substring(index + 1));

                result = (result & (1 << levelIndex));

                return result > 0;
            }

            public string GenerateResultString()
            {
                if (m_StateMap.Count == 0)
                {
                    return null;
                }

                string result = "";
                var it = m_StateMap.GetEnumerator();
                while (it.MoveNext())
                {
                    var kv = it.Current;
                    result += string.Format("{0}:{1}|", kv.Key, kv.Value);
                }
                return result;
            }

            public void BuildDataFromString(string raw)
            {
                m_StateMap.Clear();
                if (string.IsNullOrEmpty(raw))
                {
                    return;
                }

                string[] values = raw.Split('|');

                for (int i = 0; i < values.Length; ++i)
                {
                    string v = values[i];
                    if (string.IsNullOrEmpty(v))
                    {
                        continue;
                    }
                    int index = v.IndexOf(':');
                    if (index < 0)
                    {
                        continue;
                    }

                    string key = v.Substring(0, index);
                    int value = int.Parse(v.Substring(index + 1));
                    m_StateMap.Add(key, value);
                }
            }

            public void Sava()
            {
                string result = GenerateResultString();
                if (string.IsNullOrEmpty(result))
                {
                    return;
                }

                PlayerPrefs.SetString(m_Key, result);
                PlayerPrefs.Save();
            }

            public void Load()
            {
                BuildDataFromString(PlayerPrefs.GetString(m_Key));
            }
        }

        private DataRecordCell m_ProgressRecord;
        private DataRecordCell m_AnimPoltRecord;

        public override void OnComStart()
        {
            m_ProgressRecord = new DataRecordCell(PROGRESS_KEY);
            m_AnimPoltRecord = new DataRecordCell(ANIMPOLT_KEY);
        }

        public DataRecordCell progressRecord
        {
            get { return m_ProgressRecord; }
        }

        public DataRecordCell animPoltRecord
        {
            get { return m_AnimPoltRecord; }
        }
    }
}
