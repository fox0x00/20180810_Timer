using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace _20180810_Timer
{
	public class VM_TIME : INotifyPropertyChanged, ICommand
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

			this.m_Number.Add("");
			this.m_Number.Add("");
			this.m_Number.Add("");
			this.m_Number.Add("");
			this.m_Number.Add("");
			this.m_Number.Add("");
			this.m_Number.Add("");
			this.m_Number.Add("");
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

		private ObservableCollection<String> m_Number = new ObservableCollection<String>();
		public ObservableCollection<String> Number
		{
			get
			{
				return this.m_Number;
			}
		}

		private int StrtoNum(String str, int now)
		{
			int ret;

			if (int.TryParse(str, out ret) == false)
			{
				ret = now;
			}

			return ret;
		}



		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			switch ((String)parameter)
			{
				case "ADDHOUR":
					Number[3] = (StrtoNum(this.Number[3], DateTime.Now.Hour) + 1).ToString();
					break;
				default:
					break;
			}

			return;
		}



		public event PropertyChangedEventHandler PropertyChanged;
		public event EventHandler CanExecuteChanged;

		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
