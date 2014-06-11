using Blogging.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Blogging.Data
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BloggingContext()
            : base("BloggingDB")
        {
            //var csb = new SqlConnectionStringBuilder();
            //csb.ApplicationName = "Blogging";
            //csb.DataSource = "(LocalDB)\v11.0";
            //csb.AttachDBFilename = @"D:\Projects\WpfTutorial\Blogging\Data\Blogging.mdf";
            //csb.IntegratedSecurity = true;

            //Database.Connection.ConnectionString = csb.ConnectionString;
            //Database.SetInitializer(new CreateDatabaseIfNotExists<BloggingContext>());
            Database.SetInitializer(new DropCreateDatabaseAlways<BloggingContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BloggingContext>());

            Database.Initialize(true);
        }
    }
}
