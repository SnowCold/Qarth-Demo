using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace Qarth.Demo
{
    public class AudioDemoCell : ResDemoCell
    {
        [SerializeField]
        private AudioSource m_AudioSource;

        protected override void OnResLoadSuccess(IRes res)
        {
            m_AudioSource.clip = res.asset as AudioClip;
            m_AudioSource.loop = true;
        }

        protected override void OnResUnload()
        {
            m_AudioSource.clip = null;
        }
    }
}
