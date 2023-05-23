using SolrNet.Exceptions;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrNet.Commands.Parameters;
using System.Collections.ObjectModel;

namespace SolrMvcDemo.Services
{
    public class SolrIndexService<T, TSolrOperations> : ISolrIndexService<T>
    where TSolrOperations : ISolrOperations<T>
    {
        private readonly TSolrOperations _solr;
        public SolrIndexService(ISolrOperations<T> solr)
        {
            _solr = (TSolrOperations)solr;
        }
        public bool AddUpdate(T document)
        {
            try
            {
                // If the id already exists, the record is updated, otherwise added                         
                _solr.Add(document);
                _solr.Commit();
                return true;
            }
            catch (SolrNetException ex)
            {
                //Log exception
                throw ex;
                return false;

            }
        }

        public bool Delete(T document)
        {
            try
            {
                //Can also delete by id                
                _solr.Delete(document);
                _solr.Commit();
                return true;
            }
            catch (SolrNetException ex)
            {
                //Log exception
                return false;
            }
        }
        public SolrQueryResults<T> Query(ISolrQuery q, QueryOptions qo)
        {
            var results =  _solr.Query(q, qo);
            return results;
        }
        public IEnumerable<KeyValuePair<String, int>> Facet(String filed)
        {
            var results = _solr.FacetFieldQuery(new SolrFacetFieldQuery(filed));
            return results;
        }
    }
}
