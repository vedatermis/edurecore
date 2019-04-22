using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Edura.WebUI.Entity;

namespace Edura.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }

    public class ProductListModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PageInfo { get; set; }
    }
}