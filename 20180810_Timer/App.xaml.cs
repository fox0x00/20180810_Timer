using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _20180810_Timer
{
	/// <summary>
	/// App.xaml の相互作用ロジック
	/// </summary>
	public partial class App : Application
	{
		private VM_TIME m_vt = new VM_TIME();
		private M_TIME m_mt = new M_TIME();

		public VM_TIME TIME { get { return m_vt; } }

		App()
        {
            m_vt.M_M_TIME = m_mt;
            m_mt.M_VM_TIME = m_vt;
        }

		~App()
		{
		}

    }
}
