using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Blogging.Data;
using Blogging.Models;

namespace Blogging
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            using (var db = new BloggingContext())
            {
                db.Blogs.Add(new Blog() { Name = "Test" });
                db.SaveChanges();
                var n = db.Blogs.Count();
                MessageBox.Show(n.ToString());
            }
        }
    }
}
