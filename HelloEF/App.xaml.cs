using HelloEF.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HelloEF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //MessageBox.Show(Path.Combine(Environment.CurrentDirectory, "HelloEFDB.mdf"));
            // run bootstrapper
            using (var db = new HelloEF.Data.HelloEFContext())
            {
                db.Customers.AddRange(
                    new Customer[] {
                        new Customer(){ CustomerID = 1, FullName="Dana Birkby", Phone="394-555-0181"},
                        new Customer(){ CustomerID = 2, FullName="Adriana Giorgi", Phone="117-555-0119"},
                        new Customer(){ CustomerID = 3, FullName="Wei Yu", Phone="798-555-0118"}
                    }
                    );
                db.SaveChanges();
                //customers = db.Customers.ToList<Customer>();
            }
        }
    }
}
