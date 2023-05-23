using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrMvcDemo.Models
{
    public class SolrPost
    {
        public SolrPost() { }
        public SolrPost(Post model) {
            this.Id = model.Id;
            this.Body = model.Body;
            this.Title = model.Title;
        }
        [SolrUniqueKey("id")]
        public string? Id { get; set; }
        [SolrField("title")]
        public string? Title { get; set; }
        [SolrField("body")]
        public string? Body { get; set; }
    }
}
