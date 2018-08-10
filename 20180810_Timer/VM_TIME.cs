using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace _20180810_Timer
{
	public class VM_TIME : INotifyPropertyChanged
	{
		public VM_TIME()
		{
			this.m_Text.Add("");
			this.m_Text.Add("");
			this.m_Text.Add("");
			this.m_Text.Add("");
			this.m_Text.Add("");
			this.m_Text.Add("");
			this.m_Text.Add("");
			this.m_Text.Add("");
		}

		private M_TIME m_time;
		public M_TIME M_M_TIME
		{
			get
			{
				return this.m_time;
			}
			set
			{
				if (value != this.m_time)
				{
					this.m_time = value;
				}
			}
		}

		private ObservableCollection<String> m_Text = new ObservableCollection<String>();
		public ObservableCollection<String> Text
		{
			get
			{
				return this.m_Text;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
