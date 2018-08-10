using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace _20180810_Timer
{
	public class M_TIME
	{
		private Thread m_th;
		private bool m_runf;

		public M_TIME()
		{
			work_start();

			return;
		}

		public void Close()
		{
			this.work_end();

			return ;
		}

		private void work_start()
		{
			this.m_runf = true;
			this.m_th = new Thread(this.work);
			this.m_th.Start();

			return;
		}

		private void work_end()
		{
			this.m_runf = false;
			if (m_th != null)
			{
				this.m_th.Join();
				m_th = null;
			}

			return;
		}

		private void work()
		{
			DateTime time1, time2, time4;
			TimeSpan time3;

			time2 = new DateTime(2018, 8, 10, 17, 11, 0);
			time4 = time2.AddHours(5);

			while (this.m_runf)
			{
				time1 = DateTime.Now;
				time3 = time4 - DateTime.Now;

				if (this.M_VM_TIME != null)
				{
					this.M_VM_TIME.Text[0] = time1.ToString() + "." + time1.Millisecond.ToString("D03");
					this.M_VM_TIME.Text[1] = time3.ToString();
				}
				Thread.Sleep(7);
			}

			return ;
		}

		private VM_TIME m_vm_time;
		public VM_TIME M_VM_TIME
		{
			get
			{
				return this.m_vm_time;
			}
			set
			{
				if (value != this.m_vm_time)
				{
					this.m_vm_time = value;
				}
			}
		}
	}
}
