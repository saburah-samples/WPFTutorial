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
    /// Interaction logic for ExpenseItReportPage.xaml
    /// </summary>
    public partial class ExpenseItReportPage : Page
    {
        public ExpenseItReportPage()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Custom constructor to pass expense report data
        /// </summary>
        /// <param name="data">data - expense report data</param>
        public ExpenseItReportPage(object data)
            :this()
        {
            // Bind to expense report data
            this.DataContext = data;
        }
    }
}
