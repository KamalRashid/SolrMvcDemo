using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrMvcDemo.Models
{
    public class Post
    {
        public string? Id { get; set; }
        public int? PostTypeId { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public ICollection<string?> Tags { get; set; } = new List<string?>();
        public float? PostScore { get; set; }
        public int? OwnerUserId { get; set; }
        public int? AnswerCount { get; set; }
        public int CommentCount { get; set; }
        public int? FavoriteCount { get; set; }
        public int? ViewCount { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public DateTime? ClosedDate { get; set; }
    }
}
