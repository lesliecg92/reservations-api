using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations.Web.Api.ViewModel
{
    public class PaginationViewModel
    {
        public int PageSize { get; set; }

        public int Page { get; set; }

        public string OrderBy { get; set; }

        public string Order { get; set; }
    }
}
