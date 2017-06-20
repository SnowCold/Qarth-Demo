using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qarth;
using System.Text;
using System.Text.RegularExpressions;

namespace Qarth.Demo
{
    public class PoltProcessModule : AbstractModule
    {
        private RegexHelper m_RegexHelper = new RegexHelper();

        public string ProcessDrama(string rawValue)
        {
            return m_RegexHelper.ProcessString(rawValue);
        }

        protected override void OnComAwake()
        {
            m_RegexHelper.RegisterKeyProcess("<user_name>", UserNameGetter);
        }

        private string UserNameGetter()
        {
            return "SnowCold";
        }
    }
}
