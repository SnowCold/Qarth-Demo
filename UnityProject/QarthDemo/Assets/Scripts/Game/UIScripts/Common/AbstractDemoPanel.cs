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
    public class AbstractDemoPanel : AbstractPanel, TitlePanel.IDelegate
    {
        public virtual string panelTitle
        {
            get
            {
                return GetType().Name;
            }
        }

        public virtual void OnClickCloseButton()
        {
            CloseSelfPanel();
        }

        protected override void OnPanelOpen(params object[] args)
        {
            OpenDependPanel(UIID.TitlePanel, this);
        }
    }
}
