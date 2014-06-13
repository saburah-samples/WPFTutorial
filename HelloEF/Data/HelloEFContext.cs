using HelloEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace HelloEF.Data
{
    public class HelloEFContext : DbContext
    {
        public HelloEFContext()
            : base("HelloEFDB")
        {
            //var csb = new SqlConnectionStringBuilder(Database.Connection.ConnectionString);
            //csb.AttachDBFilename = Path.Combine(Environment.CurrentDirectory, "HelloEFDB.mdf");
            //Trace.WriteLine(csb.ConnectionString, "ConnectionString");
            //Database.Connection.ConnectionString = csb.ConnectionString;
            Database.SetInitializer<HelloEFContext>(new DropCreateDatabaseIfModelChanges<HelloEFContext>());
            Database.Initialize(true);
        }
        
        public DbSet<Customer> Customers { get; set; }
    }
}
