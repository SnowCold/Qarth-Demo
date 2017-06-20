using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using DG.Tweening;

namespace Qarth.Demo
{
    [TMonoSingletonAttribute("[App]/ApplicationMgr")]
    public class ApplicationMgr : AbstractApplicationMgr<ApplicationMgr>
    {

        protected override void InitThirdLibConfig()
        {
            DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
            
            //DOTween.defaultEaseType = Ease.Linear;
        }

        protected override void InitAppEnvironment()
        {

        }

        protected override void StartGame()
        {
            GameMgr.S.InitGameMgr();
        }

    }
}
