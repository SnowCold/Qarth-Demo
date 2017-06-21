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
    public class TitlePanel : AbstractPanel
    {
        public interface IDelegate
        {
            string panelTitle { get; }
            void OnClickCloseButton();
        }

        [SerializeField]
        private Text m_PanelTitle;
        [SerializeField]
        private Button m_CloseButton;

        private IDelegate m_Delagate;

        protected override void OnUIInit()
        {
            m_CloseButton.onClick.AddListener(() =>
            {
                if (m_Delagate == null)
                {
                    return;
                }

                m_Delagate.OnClickCloseButton();
            });
        }

        protected override void OnPanelOpen(params object[] args)
        {
            m_Delagate = null;
            if (args.Length > 0)
            {
                m_Delagate = args[0] as IDelegate;
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            if (m_Delagate == null)
            {
                m_CloseButton.gameObject.SetActive(false);
                m_PanelTitle.text = "";
                return;
            }

            m_CloseButton.gameObject.SetActive(true);

            m_PanelTitle.text = m_Delagate.panelTitle;
        }
    }
}
