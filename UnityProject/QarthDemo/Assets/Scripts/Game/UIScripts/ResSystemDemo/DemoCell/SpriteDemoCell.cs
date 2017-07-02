using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Qarth;
using UnityEngine.UI;

namespace Qarth.Demo
{
    public class SpriteDemoCell : ResDemoCell
    {
        [SerializeField]
        private Image m_Image;

        protected override void OnResLoadSuccess(IRes res)
        {
            m_Image.sprite = res.asset as Sprite;
        }

        protected override void OnResUnload()
        {
            m_Image.sprite = null;
        }
    }
}
