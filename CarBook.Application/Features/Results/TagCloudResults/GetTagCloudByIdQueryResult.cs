using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Results.TagCloudResults
{
    public class GetTagCloudByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BlogId { get; set; }
    }
}
