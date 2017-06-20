using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;

namespace Qarth.Demo
{
    public class InitModuleNode : ExecuteNode
    {
        public override void OnBegin()
        {
            Log.i("ExecuteNode:" + GetType().Name);
            GameMgr.S.AddCom<UIDataModule>();
            GameMgr.S.AddCom<InputModule>();
            GameMgr.S.AddCom<DatabaseModule>();
            GameMgr.S.AddCom<CommonResModule>();
            GameMgr.S.AddCom<GuideModule>();
            GameMgr.S.poltProcessModule = GameMgr.S.AddCom<PoltProcessModule>();
			//UIMgr.S.OpenTopPanel(EngineUI.GuidePanel, null);
			
            isFinish = true;
        }
    }
}
