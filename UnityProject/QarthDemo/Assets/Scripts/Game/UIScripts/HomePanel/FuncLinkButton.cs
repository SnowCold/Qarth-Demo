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
using UnityEngine.UI;

namespace Qarth.Demo
{
    public class FuncLinkButton : IUListItemView
    {
        [SerializeField]
        private Text m_ButtonText;
        [SerializeField]
        private Button m_Button;

        private HomePanel.FuncItem m_FuncItem;

        private void Awake()
        {
            m_Button.onClick.AddListener(() =>
            {
                if (m_FuncItem == null)
                {
                    return;
                }

                UIMgr.S.OpenPanel(m_FuncItem.uiID);
            });
        }

        public override void SetData(int index, object data)
        {
            m_FuncItem = data as HomePanel.FuncItem;
            if (m_FuncItem == null)
            {
                return;
            }
            m_ButtonText.text = m_FuncItem.funcName;
        }
    }
}
