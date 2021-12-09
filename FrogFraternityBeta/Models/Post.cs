using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrogFraternityBeta.Models
{
    public class Post
    {
        [Key]

        public int PostId { get; set; }

        public int Username { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? PostTime { get; set; }
        }
    }
