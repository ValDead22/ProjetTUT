﻿using ApplicationJampay.ViewModel.ViewModel.Gérant.PopUp;
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

namespace ApplicationJampay.View.Gérant.PopUp.Produit
{
    /// <summary>
    /// Logique d'interaction pour ModifProduitView.xaml
    /// </summary>
    public partial class ModifProduitView : Window
    {
        public ModifProduitView()
        {
            DataContext = new ModifProduitViewModel
            {
                Close = () => Close()
            };
            InitializeComponent();
        }
    }
}
