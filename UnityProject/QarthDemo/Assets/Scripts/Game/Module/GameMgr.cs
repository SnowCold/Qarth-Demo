using System;
using UnityEngine;
using System.Collections;
using Qarth;

namespace Qarth.Demo
{
    [TMonoSingletonAttribute("[Game]/GameMgr")]
    public class GameMgr : AbstractModuleMgr, ISingleton
    {
        private static GameMgr s_Instance;

        public static GameMgr S
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = MonoSingleton.CreateMonoSingleton<GameMgr>();
                }
                return s_Instance;
            }
        }

        public PoltProcessModule poltProcessModule
        {
            get;
            set;
        }

        public void InitGameMgr()
        {
            Log.i("Init[GameMgr]");
        }

        public void OnSingletonInit()
        {
        }

        protected override void OnActorStart()
        {
            StartProcessModule module = AddMonoCom<StartProcessModule>();

            module.SetFinishListener(OnStartProcessFinish);
        }

        protected void OnStartProcessFinish()
        {
            GetCom<GuideModule>().StartGuide();
            //UIMgr.S.OpenPanel(UIID.HomePanel);
            //ResUpdateMgr.S.CheckPackage()
        }
    }
}
