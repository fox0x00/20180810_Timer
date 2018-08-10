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
		private object loc = new object();

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
		public M_TIME M_MODEL
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

		private TIMEDISPLAY m_view;
		public TIMEDISPLAY VIEW
		{
			get
			{
				return this.m_view;
			}
			set
			{
				if (value != this.m_view)
				{
					this.m_view = value;
					value.DataContext = this;
				}
			}
		}

		private bool m_IsTOP;
		public bool IsTOP
		{
			get
			{
				return this.m_IsTOP;
			}
			set
			{
				if (value != this.m_IsTOP)
				{
					this.m_IsTOP = value;
					if (VIEW != null)
					{
						VIEW.Topmost = value;
					}
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
				lock (loc)
				{
					return this.m_Number;
				}
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

		private void addhour()
		{
			int hour, day, month, year;

			lock (loc)
			{
				hour = StrtoNum(this.Number[3], DateTime.Now.Hour) + 1;
				if (23 < hour)
				{
					hour = 0;

					day = StrtoNum(this.Number[2], DateTime.Now.Day) + 1;
					month = StrtoNum(this.Number[1], DateTime.Now.Month);
					year = StrtoNum(this.Number[0], DateTime.Now.Year);

					if (DateTime.DaysInMonth(year, month) < day)
					{
						day = 1;
						month = month + 1;
						if (12 < month)
						{
							month = 1;
							year = year + 1;
							Number[0] = year.ToString();
						}
						Number[1] = month.ToString();
					}
					Number[2] = day.ToString();
				}
				Number[3] = hour.ToString();
			}
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
					this.addhour();
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
