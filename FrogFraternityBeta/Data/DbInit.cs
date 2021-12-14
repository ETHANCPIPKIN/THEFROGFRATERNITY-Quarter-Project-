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
                new Post
                {
                    PostId=0,
                    Username="Admin",
                    Title="Forum F.A.Q",
                    Content="What is this server for?: \n This server is here to serve as a congregational area for frog lovers of all kinds" +
                    "\n Are other amphibians allowed: \n Yes, in the servers eye's all amphibians are frogs but not totally frogs" +
                    "\n Are we allowed to invite friends?: \n Yes" +
                    "\n how do you become an admin?: \n Admin roles are only considered for those who show prowess in the forum" +
                    "\n how long has this forum been going on for?: \n Time is irrelevant when frogs are present." +
                    "\n FOR ANY OTHER QUESTIONS, ASK AN ADMIN THEMSELVES...",
                    PostTime=DateTime.Now

                },
                new Post
                {
                    PostId=1,
                    Username="Admin",
                    Title="Forum Rules",
                    Content="1. Be nice and respectful" +
                    "\n2. The only topic should be Frogs, if it's not frogs, its not here" +
                    "\n3. Follow the rules and what the Admins say.",
                    PostTime=DateTime.Now
                },
                new Post{Username="FroggyLover",Title="frogs are greate", Content="yay",PostTime=DateTime.Parse("1998-12-14")},
                new Post{Username="Forg",Title="big boy :)", Content="big.",PostTime=DateTime.Now },
                new Post{Username="Frogwell",Title="AXLOTLS DONT BELONG HERE", Content="PEOPLE KEEP POSTING AXLOTLS HERE! WHICH IS DUMB AXLOTLS ARENT FROGS THIS IS A FROG FORUM",PostTime=DateTime.Parse("1998-13-14")},
                new Post{Username="FroggyLover22221111222",Title="RE: AXLOTLS DONT BELONG HERE", Content="I think you don't belong here! Especially with that attitude! Other amphibians are allowed the admins said so!",PostTime=DateTime.Parse("1998-13-14")},
                new Post{Username="Frogwell",Title="RE: RE: AXLOTLS DONT BELONG HERE", Content="I HOPE WHEN Y2K HAPPENS A PLANE LANDS ON YOUR HOUSE!!!!",PostTime=DateTime.Parse("1998-13-14")},
                new Post{Username="Bladefan77778889",Title="NEW BLADE MOVIE", Content="Has anyone seen the new blade movie? It's really good!",PostTime=DateTime.Parse("1998-14-14")},
                new Post{Username="HulkHogan",Title="RE: NEW BLADE MOVIE", Content="I THINK IT WOULD'VE BEEN BETTER IF BLADE WAS A FROG BROTHER!!!!!!!",PostTime=DateTime.Parse("1998-16-14")},
                new Post{Username="DorkusMcglorkus",Title="Frog blanket", Content="I knitted my frog a blanket! look! \n(media not found)",PostTime=DateTime.Parse("1998-16-14")},

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