using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace Qarth.Demo
{
    public class DisplayInstanceID : MonoBehaviour
    {
        [SerializeField]
        private long m_ID;
        [SerializeField]
        private int m_ResID;

        private void Update()
        {
            var source = GetComponent<AudioSource>();
            if (source != null)
            {
                var clip = source.clip;
                if (clip != null)
                {
                    m_ID = clip.GetInstanceID();

                    IRes res = ResMgr.S.GetRes(clip.name);
                    if (res != null)
                    {
                        m_ResID = res.GetHashCode();
                    }
                    else
                    {
                        m_ResID = -1;
                    }
                }
            }
        }
    }
}
