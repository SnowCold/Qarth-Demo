using UnityEngine;
using System.Collections;
using Qarth;
using UnityEngine.SceneManagement;

namespace Qarth.Demo
{
    public class InputModule : AbstractModule
    {
        private IInputter m_KeyboardInputter;

        public override void OnComLateUpdate(float dt)
        {
            m_KeyboardInputter.LateUpdate();
        }

        protected override void OnComAwake()
        {
            m_KeyboardInputter = new KeyboardInputter();

            m_KeyboardInputter.RegisterKeyCodeMonitor(KeyCode.F1, null, OnClickF1, null);
            m_KeyboardInputter.RegisterKeyCodeMonitor(KeyCode.F2, null, OnClickF2, null);
            m_KeyboardInputter.RegisterKeyCodeMonitor(KeyCode.F3, null, OnClickF3, null);
            m_KeyboardInputter.RegisterKeyCodeMonitor(KeyCode.F4, null, OnClickF4, null);
        }

        private void OnClickF1()
        {

        }

        private void OnClickF2()
        {

        }

        private void OnClickF3()
        {
			
        }

        private void OnClickF4()
        {

        }

        private void OnSceneLoadResult(string sceneName, bool result)
        {

        }
    }
}
