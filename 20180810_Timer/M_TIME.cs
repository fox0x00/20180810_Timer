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

			return;
		}

		public void Close()
		{
			this.work_end();

			return ;
		}

		public void work_start()
		{
			this.m_runf = true;
			this.m_th = new Thread(this.work);
			this.m_th.Start();

			return;
		}

		public void work_end()
		{
			this.m_runf = false;
			if (m_th != null)
			{
				this.m_th.Join();
				m_th = null;
			}

			return;
		}

		private int StrtoNum(String str, int now)
		{
			int ret;

			if(int.TryParse(str, out ret) == false)
			{
				ret = now;
			}

			return ret;
		}

		private void work()
		{
			DateTime time1, time2, time4;
			TimeSpan time3;

			time1 = DateTime.Now;
			this.M_VM_TIME.Number[0] = time1.Year.ToString();
			this.M_VM_TIME.Number[1] = time1.Month.ToString();
			this.M_VM_TIME.Number[2] = time1.Day.ToString();
			this.M_VM_TIME.Number[3] = time1.Hour.ToString();
			this.M_VM_TIME.Number[4] = time1.Minute.ToString();
			this.M_VM_TIME.Number[5] = time1.Second.ToString();

			time2 = DateTime.Now;

			while (this.m_runf)
			{
				time2 = new DateTime(
					this.StrtoNum(this.M_VM_TIME.Number[0], time2.Year),
					this.StrtoNum(this.M_VM_TIME.Number[1], time2.Month),
					this.StrtoNum(this.M_VM_TIME.Number[2], time2.Day),
					this.StrtoNum(this.M_VM_TIME.Number[3], time2.Hour),
					this.StrtoNum(this.M_VM_TIME.Number[4], time2.Minute),
					this.StrtoNum(this.M_VM_TIME.Number[5], time2.Second));
				time1 = DateTime.Now;
				time3 = time2 - DateTime.Now;

				if (this.M_VM_TIME != null)
				{
					this.M_VM_TIME.Text[0] = time1.ToString() + "." + time1.Millisecond.ToString("D03");
					this.M_VM_TIME.Text[1] = time3.ToString().Remove(12);
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
