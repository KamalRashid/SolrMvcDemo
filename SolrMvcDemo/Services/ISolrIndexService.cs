using SolrNet;
using SolrNet.Commands.Parameters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrMvcDemo.Services
{
    public interface ISolrIndexService<T>
    {
        bool AddUpdate(T document);
        bool Delete(T document);
        SolrQueryResults<T> Query(ISolrQuery q, QueryOptions qo);
        IEnumerable<KeyValuePair<String, int>> Facet(String filed);
    }
}