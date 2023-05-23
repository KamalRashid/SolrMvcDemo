using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrMvcDemo.Models
{
    public class SolrFilm
    {
        public SolrFilm() { }

        public SolrFilm(Film model)
        {
            this.Name = model.Name;
            this.InitialReleaseDate = model.InitialReleaseDate;
            this.Genre = model.Genre;
            this.DirectedBy = model.DirectedBy;
        }

        [SolrUniqueKey("id")]
        public string? Id { get; set; }
        [SolrField("name")]
        public string? Name { get; set; }
        [SolrField("directed_by")]
        public List<string>? DirectedBy { get; set; }
        [SolrField("initial_release_date")]
        public string? InitialReleaseDate { get; set; }
        [SolrField("genre")]
        public List<string>? Genre { get; set; }
        [SolrField("film_vector")]
        public List<string> FilmVector { get; set; }

    }
}
