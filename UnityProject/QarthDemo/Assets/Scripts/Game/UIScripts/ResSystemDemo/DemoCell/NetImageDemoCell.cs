using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Qarth;
using UnityEngine.UI;

namespace Qarth.Demo
{
    public class NetImageDemoCell : TextureDemoCell
    {
        protected override string TransformName(string rawName)
        {
            return "NetImage:" + rawName;
        }

        protected override bool IsSupportSyncLoad()
        {
            return false;
        }
    }
}
