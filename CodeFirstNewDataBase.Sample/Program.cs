using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDataBase.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new BlogbContext()) {
                Console.Write("Input blog name: ");
                string name = Console.ReadLine();

                var blog = new Blog { BlogName = name };

                ctx.Blogs.Add(blog);
                ctx.SaveChanges();

                var blogItem = from a in ctx.Blogs
                               orderby a.BlogName
                               select a;

                Console.WriteLine("Blog name: {0}", blog.BlogName);
                Console.ReadLine();
            }
        }


        public class User {

            [Key]
            public string UserName { get; set; }
            public string Display { get; set; }
        }

        public class Blog {
            public int BlogId { get; set; }
            public string BlogName { get; set; }
            public string Url { get; set; }

            public virtual List<Post> Posts { get; set; }
        }

        public class Post {
            public int PostId { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }

            public int BlogId { get; set; }
            public virtual Blog Blog { get; set; }
        }


        public class BlogbContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }
            public DbSet<User> Users { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>()
                    .Property(a => a.Display)
                    .HasColumnName("display_name");
            }
        }

    }
}


///https://msdn.microsoft.com/en-us/data/jj193542
///Package manager console
///Enable-Migration
///Add-Migration [NameComment] (moi lan thay doi)
///Update-DataBase (moi lan thay doi)