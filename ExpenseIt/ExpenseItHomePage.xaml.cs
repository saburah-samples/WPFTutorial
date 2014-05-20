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

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItHomePage.xaml
    /// </summary>
    public partial class ExpenseItHomePage : Page
    {
        public ExpenseItHomePage()
        {
            InitializeComponent();
        }

        private void OnButtonView_Click(object sender, RoutedEventArgs e)
        {
            var page = new ExpenseItReportPage(this.peopleListBox.SelectedItem);
            this.NavigationService.Navigate(page);
        }
    }
}
