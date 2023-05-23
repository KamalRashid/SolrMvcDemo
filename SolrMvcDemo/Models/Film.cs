using SolrNet.Attributes;

namespace SolrMvcDemo.Models
{
    public class Film
    {
        public string? Name { get; set; }
        public List<string>? DirectedBy { get; set; }
        public string? InitialReleaseDate { get; set; }
        public List<string>? Genre { get; set; }
    }
}
