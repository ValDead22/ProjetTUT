﻿using ApplicationJampay.ViewModel.ViewModel;
using System;
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
using System.Windows.Shapes;

namespace ApplicationJampay.View
{
    /// <summary>
    /// Logique d'interaction pour DialogYesNo.xaml
    /// </summary>
    public partial class DialogYesNo : Window
    {
        public DialogYesNo(string msg, Action yes)
        {    
            InitializeComponent();

            DataContext = new YesNoViewModel(msg, yes)
            {
                Close = () => this.Close()
            };
        }
    }
}
