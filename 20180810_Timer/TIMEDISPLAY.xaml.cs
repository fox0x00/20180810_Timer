﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _20180810_Timer
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class TIMEDISPLAY : Window
    {
        public TIMEDISPLAY()
        {
            InitializeComponent();

			((App)App.Current).TIME.VIEW = this;
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			((App)App.Current).TIME.M_MODEL.Close();
		}
	}
}
