using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autentifAuthorized.Models
{
    public class PaginatorConfig
    {
        public int ActualPage { get; set; }
        public int TotalObjects { get; set; }
        public int ObjectsPerPage { get; set; }

        public PaginatorConfig(int actualPage, int totalObjects, int objectsPerPage)
        {
            ActualPage = actualPage;
            TotalObjects = totalObjects;
            ObjectsPerPage = objectsPerPage;
        }
        
    }
}