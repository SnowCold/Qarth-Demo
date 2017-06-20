using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;

namespace Qarth.Demo
{
    public class TableModule : AbstractModule
    {
        private bool m_IsTableLoadFinish = false;

        public bool isTableLoadFinish
        {
            get { return m_IsTableLoadFinish; }
        }

        public void SwitchLanguage(string key)
        {
            TDTableMetaData[] tables = new TDTableMetaData[]
            {
                new TDTableMetaData(TDLanguageTable.Parse, FormatTableName(TDLanguageTable.metaData.tableName, key)),
            };

            m_IsTableLoadFinish = false;
            actor.StartCoroutine(TableMgr.S.ReadAll(tables, OnLanguageSwitchLoadFinish));
        }

        private string FormatTableName(string rawName, string key)
        {
            return string.Format("{0}_{1}", rawName, key);
        }

        protected override void OnComAwake()
        {
            InitPreLoadTableMetaData();
            InitDelayLoadTableMetaData();

            m_IsTableLoadFinish = false;
            actor.StartCoroutine(TableMgr.S.PreReadAll(OnTableLoadFinish));
        }

        private void OnLanguageSwitchLoadFinish()
        {
            m_IsTableLoadFinish = true;
            Log.i("OnLanguageSwitchLoadFinish.");
            EventSystem.S.Send(EventID.OnLanguageTableSwitchFinish);
        }

        private void OnTableLoadFinish()
        {
            TDConstTable.InitArrays(typeof(ConstType));

            //处理所有表的重建
            m_IsTableLoadFinish = true;
        }

        private void InitPreLoadTableMetaData()
        {
            TableConfig.preLoadTableArray = new TDTableMetaData[]
            {
                TDConstTable.metaData,
                TDLanguageTable.metaData,
				TDGuideTable.metaData,
				TDGuideStepTable.metaData,
            };
        }

        private void InitDelayLoadTableMetaData()
        {
            TableConfig.delayLoadTableArray = new TDTableMetaData[]
            {

            };
        }
    }
}
