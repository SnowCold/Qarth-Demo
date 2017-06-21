using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Qarth;
using UnityEngine.UI;

namespace Qarth.Demo
{
    public class TextureDemoCell : ResDemoCell
    {
        [SerializeField]
        protected RawImage m_Image;

        protected override void OnResLoadSuccess(IRes res)
        {
            Texture tex = res.asset as Texture;
            if (tex == null)
            {
                FloatMessage.S.ShowMsg("加载的资源不是纹理,无法正常显示.");
                return;
            }

            m_Image.texture = tex;
        }
    }
}
