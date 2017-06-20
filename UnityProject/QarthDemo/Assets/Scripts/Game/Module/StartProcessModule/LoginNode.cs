using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;

namespace Qarth.Demo
{
    public class LoginNode : ExecuteNode
    {
        public override void OnExecute()
        {
            Log.i("ExecuteNode:" + GetType().Name);
            isFinish = true;
        }
    }
}
