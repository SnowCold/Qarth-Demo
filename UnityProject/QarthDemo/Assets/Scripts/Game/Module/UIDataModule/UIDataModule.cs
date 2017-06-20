using System;
using UnityEngine;
using System.Collections;
using Qarth;

namespace Qarth.Demo
{
    public class UIDataModule : AbstractModule
    {
        protected override void OnComAwake()
        {
            PanelData.PREFIX_PATH = "Resources/UI/Panels/{0}";
            PageData.PREFIX_PATH = "Resources/UI/Panels/{0}";

            RegisterAllPanel();
        }

        private void RegisterAllPanel()
        {
            UIDataTable.SetABMode(true);

            UIDataTable.AddPanelData(EngineUI.FloatMessagePanel, null, "Common/FloatMessagePanel", true, 1);
            UIDataTable.AddPanelData(EngineUI.MsgBoxPanel, null, "Common/MsgBoxPanel", true, 1);
            UIDataTable.AddPanelData(EngineUI.HighlightMaskPanel, null, "Guide/HighlightMaskPanel", true, 0);
			UIDataTable.AddPanelData(EngineUI.GuideHandPanel, null, "Guide/GuideHandPanel", true, 0);

            ////////////////////////////////////////////////////////////////////////
            UIDataTable.AddPanelData(UIID.HomePanel, null, "HomePanel/HomePanel");
            UIDataTable.AddPanelData(UIID.EventSystemDemo1, null, "EventSystemDemo/EventSystemDemo1");
        }
    }
}
