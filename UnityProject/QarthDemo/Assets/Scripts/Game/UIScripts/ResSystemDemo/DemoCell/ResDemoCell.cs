using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Qarth;
using UnityEngine.UI;

namespace Qarth.Demo
{
    public class ResDemoCell : MonoBehaviour
    {
        [SerializeField]
        private Button m_SyncLoadButton;
        [SerializeField]
        private Button m_AsyncLoadButton;
        [SerializeField]
        private Button m_UnLoadButton;
        [SerializeField]
        private InputField m_InputField;

        private ResLoader m_ResLoader;

        protected virtual void OnResLoadSuccess(IRes res)
        {

        }

        protected virtual string TransformName(string rawName)
        {
            return rawName;
        }

        protected virtual bool IsSupportSyncLoad()
        {
            return true;
        }

        protected virtual void OnResUnload()
        {

        }

        protected virtual List<string> GetNeedLoadResNameList()
        {
            return null;
        }

        private void Awake()
        {
            m_UnLoadButton.gameObject.SetActive(false);

            m_SyncLoadButton.onClick.AddListener(OnClickSyncLoadButton);
            m_AsyncLoadButton.onClick.AddListener(OnClickAsyncLoadButton);
            m_UnLoadButton.onClick.AddListener(OnClickUnloadButton);

            if (!IsSupportSyncLoad())
            {
                m_SyncLoadButton.gameObject.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            if (m_ResLoader != null)
            {
                m_ResLoader.Recycle2Cache();
                m_ResLoader = null;
            }
        }

        private void OnClickSyncLoadButton()
        {
            if (AddRes2Load())
            {
                m_ResLoader.LoadSync();
            }
        }

        private void OnClickUnloadButton()
        {
            ClearPreResource();
        }

        private void OnClickAsyncLoadButton()
        {
            if (AddRes2Load())
            {
                m_ResLoader.LoadAsync();
            }
        }

        private bool AddRes2Load()
        {
            string name = m_InputField.text;

            if (string.IsNullOrEmpty(name))
            {
                FloatMessage.S.ShowMsg("请输入有效的资源名");
                return false;
            }

            ClearPreResource();

            name = TransformName(name);

            m_ResLoader = ResLoader.Allocate("ResDemo");

            if (!m_ResLoader.Add2Load(name, OnResLoadFinish))
            {
                FloatMessage.S.ShowMsg("资源加载失败,请检测资源名是否正确.");
                return false;
            }

            return true;
        }

        private void OnResLoadFinish(bool result, IRes res)
        {
            if (!result)
            {
                FloatMessage.S.ShowMsg("资源加载失败,请检测资源名是否正确.");
                return;
            }

            m_UnLoadButton.gameObject.SetActive(true);
            OnResLoadSuccess(res);
        }

        private void ClearPreResource()
        {
            if (m_ResLoader == null)
            {
                return;
            }


            m_ResLoader.Recycle2Cache();
            m_ResLoader = null;

            m_UnLoadButton.gameObject.SetActive(false);
            OnResUnload();
        }
    }
}
