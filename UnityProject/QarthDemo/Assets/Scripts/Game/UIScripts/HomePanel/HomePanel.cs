//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2017 SnowCold. All rights reserved.
//  WebSite:     https://github.com/SnowCold/Qarth
//  Blog:        http://blog.csdn.net/snowcoldgame
//  Author:      SnowCold
//  E-mail:      snowcold.ouyang@gmail.com
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace Qarth.Demo
{
    public class HomePanel : AbstractPanel
    {
        [Serializable]
        public class FuncItem
        {
            public UIID uiID;
            public string funcName;
        }

        [SerializeField]
        private List<FuncItem> m_FuncItems;

        [SerializeField]
        private IUListView m_ListView;

        protected override void OnUIInit()
        {
            m_ListView.SetCellRenderer(OnCellRenderer);
            m_ListView.SetDataCount(m_FuncItems.Count);
        }

        private void OnCellRenderer(Transform root, int index)
        {
            root.GetComponent<FuncLinkButton>().SetData(index, m_FuncItems[index]);
        }
    }
}
