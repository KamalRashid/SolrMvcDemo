using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
using SolrMvcDemo.Models;
using SolrMvcDemo.Services;
using SolrNet;
using SolrNet.Commands.Parameters;
using SolrNet.Impl;
using System.Diagnostics;
using System.Security.Cryptography.Xml;

namespace SolrMvcDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ISolrIndexService<SolrFilm> _solrIndexService;

        public HomeController(ILogger<HomeController> logger, ISolrIndexService<SolrFilm> solrIndexService)
        {
            this._solrIndexService = solrIndexService;
            _logger = logger;
        }

        public IActionResult Index()
        {

            /*var post = new Post();
            post.Title = "New Post Title Test";
            post.Body = "New Post Body Test";
            post.Id = "ID0002";

            _solrIndexService.AddUpdate(new SolrPost(post));

*/
            /* var post = new Post();
             post.Title = "New Post Title Test";
             post.Body = "New Post Body Test";
             post.Id = "ID0002";

             _solrIndexService.Delete(new SolrPost(post));*/


            return View();

        }

        public string getQuery(string[] q)
        {
            string qeury = "_text_:*" + q[0] + "*";
            if (q[1] != "None")
                qeury += " AND genre:" + q[1];
            if (q[2] != "None")
                qeury += " AND initial_release_date:" + q[2];
            return qeury;
        }

        [HttpGet]
        public IActionResult Query(String q)
        {
            var query = getQuery(q.Split(','));

            string solrUrl = "http://localhost:8983/solr/films";
            string relativeUrl = "/select";
            var parameters = new Dictionary<string, string>
            {
                {"q", query},
                {"wt", "json"},
                { "indent","true"},
                 { "q.op", "AND"},
            };

            var solrConnection = new SolrConnection(solrUrl);
            var response = solrConnection.Get(relativeUrl, parameters);

            return Content(response, "application/json");



            //var query = new SolrQueryByField(searchTerm,q);

            //QueryOptions query_options = new QueryOptions
            //{
            //    Rows = 10,
            //    StartOrCursor = new StartOrCursor.Start(0),
            //    FilterQueries = new ISolrQuery[] { }
            //    //Highlight = new HighlightingParameters
            //    //{
            //    //    Fields = new[] { "*" },
            //    //}
            //};

            //var results = _solrIndexService.Query(query, query_options);
            

            //var result = new List<string>();
            //foreach (var highlight in results.Highlights)
            //{
            //    Console.WriteLine("Highlighted field: {0}", highlight.Key);
            //    foreach (var snippet in highlight.Value)
            //    {
            //        foreach (var v in snippet.Value)
            //        {
            //            Console.WriteLine("Highlighted snippet: {0}", v);
            //            result.Add(v);
            //        }
            //    }
            //}

            //return Json(results);
        }

        [HttpGet]
        public IActionResult Suggest(String q)
        {
            string solrUrl = "http://localhost:8983/solr/films";
            string relativeUrl = "/suggest";
            var parameters = new Dictionary<string, string>
            {
                {"q", q},
                {"wt", "json"},
                {"suggest", "true" },
                {"suggest.build", "true" },
                {"suggest.dictionary", "mySuggester" },
            };

            var solrConnection = new SolrConnection(solrUrl);
            var response = solrConnection.Get(relativeUrl, parameters);
            return Content(response, "application/json");
        }

        [HttpGet]
        public IActionResult Facet(String field)
        {
            var results = _solrIndexService.Facet(field);
            return Json(results);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}