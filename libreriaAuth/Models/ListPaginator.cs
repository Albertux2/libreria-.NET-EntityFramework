using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autentifAuthorized.Models
{
    public class ListPaginator<T> : PaginatorConfig
    {
        public List<T> Models;

        public ListPaginator(int actualPage, int totalObjects, int objectsPerPage) 
            :base(actualPage, totalObjects, objectsPerPage)
        {
        }

        public void SetPaginatedList(int page, List<T> list)
        {
            ActualPage = page;
            TotalObjects = list.Count();
            Models = list.Skip((page - 1) * ObjectsPerPage).Take(ObjectsPerPage).ToList();
        }

    }
}