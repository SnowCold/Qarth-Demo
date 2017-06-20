using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Qarth;

namespace Qarth.Demo
{
    public class GuideModule : AbstractModule
    {
        public void StartGuide()
        {
            if (!AppConfig.S.isGuideActive)
            {
                return;
            }

            GuideMgr.S.StartGuideTrack();
        }

        protected override void OnComAwake()
        {
            //注册动态的
        }

        
    }
}
