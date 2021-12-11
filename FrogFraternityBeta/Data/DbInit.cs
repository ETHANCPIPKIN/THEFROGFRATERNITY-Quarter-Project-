using FrogFraternityBeta.Models;
using System;
using System.Linq;

namespace FrogFraternityBeta.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ForumContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Posts.Any())
            {
                return;   // DB has been seeded
            }

            var post = new Post[]
            {
                // new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")}
                new Post{Username="FroggyLover",Title="frogs are greate", Content="yay",PostTime=DateTime.Parse("1998-12-14")},
                new Post{Username="Forg",Title="big boy :)", Content="big.",PostTime=DateTime.Now },
            };
            foreach (Post s in post)
            {
                context.Posts.Add(s);
            }
            context.SaveChanges();
            /*
            var users = new User[]
            {
                // new Course{CourseID=1050,Title="Chemistry",Credits=3},
            };
            foreach (User c in users)
            {
                context.User.Add(c);
            }
            context.SaveChanges();
            */
        }
    }
}