using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Domain.Models.Request
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
