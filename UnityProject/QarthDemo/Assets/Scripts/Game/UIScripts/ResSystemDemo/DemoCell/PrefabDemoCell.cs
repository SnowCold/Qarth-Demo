using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace Qarth.Demo
{
    public class PrefabDemoCell : ResDemoCell
    {
        [SerializeField]
        private Transform m_PrefabRoot;

        private GameObject m_Prefab;

        protected override void OnResLoadSuccess(IRes res)
        {
            GameObject prefab = res.asset as GameObject;
            GameObject node = GameObject.Instantiate(prefab, m_PrefabRoot, false);
            UIHelper.AttachUI(node, m_PrefabRoot);
            m_Prefab = node;
        }

        protected override void OnResUnload()
        {
            if (m_Prefab == null)
            {
                return;
            }

            GameObject.Destroy(m_Prefab);
            m_Prefab = null;
        }
    }
}
