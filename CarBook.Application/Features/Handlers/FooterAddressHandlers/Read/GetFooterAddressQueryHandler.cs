using CarBook.Application.Features.Queries.FooterAddressQueries;
using CarBook.Application.Features.Results.FooterAddressResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.FooterAddressHandlers.Read
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetList();
            return query.Select(x => new GetFooterAddressQueryResult
            {
                Id=x.ID,
                Address=x.Address,
                Description=x.Description,
                Email=x.Email,
                Phone=x.Phone
            }).ToList();
        }
    }
}
