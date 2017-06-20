//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace Qarth.Demo
{
    public static partial class TDThemeTable
    {
        private static TDTableMetaData m_MetaData = new TDTableMetaData(TDThemeTable.Parse, "theme");
        public static TDTableMetaData metaData
        {
            get { return m_MetaData; }
        }
        
        private static Dictionary<string, TDTheme> m_DataCache = new Dictionary<string, TDTheme>();
        private static List<TDTheme> m_DataList = new List<TDTheme>();
        
        public static void Parse(byte[] fileData)
        {
            m_DataCache.Clear();
            m_DataList.Clear();
            DataStreamReader dataR = new DataStreamReader(fileData);
            int rowCount = dataR.GetRowCount();
            int[] fieldIndex = dataR.GetFieldIndex(TDTheme.GetFieldHeadIndex());
    #if (UNITY_STANDALONE_WIN) || UNITY_EDITOR || UNITY_STANDALONE_OSX
            dataR.CheckFieldMatch(TDTheme.GetFieldHeadIndex(), "ThemeTable");
    #endif
            for (int i = 0; i < rowCount; ++i)
            {
                TDTheme memberInstance = new TDTheme();
                memberInstance.ReadRow(dataR, fieldIndex);
                OnAddRow(memberInstance);
                memberInstance.Reset();
                CompleteRowAdd(memberInstance);
            }
            Log.i(string.Format("Parse Success TDTheme"));
        }

        private static void OnAddRow(TDTheme memberInstance)
        {
            string key = memberInstance.id;
            if (m_DataCache.ContainsKey(key))
            {
                Log.e(string.Format("Invaild,  TDThemeTable Id already exists {0}", key));
            }
            else
            {
                m_DataCache.Add(key, memberInstance);
                m_DataList.Add(memberInstance);
            }
        }    
        
        public static void Reload(byte[] fileData)
        {
            Parse(fileData);
        }

        public static int count
        {
            get 
            {
                return m_DataCache.Count;
            }
        }

        public static List<TDTheme> dataList
        {
            get 
            {
                return m_DataList;
            }    
        }

        public static TDTheme GetData(string key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.e(string.Format("Can't find key {0} in TDTheme", key));
                return null;
            }
        }
    }
}//namespace LR