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

            var users = new User[]
            {
                new User{UserName="FroggyLover",
                    Password="10456391824346701",
                    fontColor="#FF0000",
                    profilePic="https://cdn.discordapp.com/attachments/628439897832816642/919102648244920320/20211210_214523.jpg"},
                new User{UserName="Forg",
                    Password="86497712335516898",
                    fontColor="#FFFFFF",
                    profilePic="https://cdn.discordapp.com/attachments/628439897832816642/919102648244920320/20211210_214523.jpg"}
            };
            foreach (User c in users)
            {
                context.Users.Add(c);
            }
            context.SaveChanges();
        }
    }
}