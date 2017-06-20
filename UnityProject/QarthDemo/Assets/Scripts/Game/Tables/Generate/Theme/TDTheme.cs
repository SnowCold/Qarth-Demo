//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace Qarth.Demo
{
    public partial class TDTheme
    {
      
        private string m_Id;
        private string m_Name;
      
      
        /// <summary>
        /// ID
        /// </summary>
        public string id {get { return m_Id; } }
      
        /// <summary>
        /// Key
        /// </summary>
        public string name {get { return m_Name; } }

        public void ReadRow(DataStreamReader dataR, int[] filedIndex)
        {
          int col = 0;
          while(true)
          {
            col = dataR.MoreFieldOnRow();
            if (col == -1)
            {
              break;
            }
            switch (filedIndex[col])
            { 
                case 0:
                    m_Id = dataR.ReadString();
                    break;
                case 1:
                    m_Name = dataR.ReadString();
                    break;
                default:
                    break;
            }
          }

        }
        
        public static Dictionary<string, int> GetFieldHeadIndex()
        {
          Dictionary<string, int> ret = new Dictionary<string, int>(2);
          
          ret.Add("Id", 0);
          ret.Add("Name", 1);
          return ret;
        }
        
        
    }
}//namespace LR