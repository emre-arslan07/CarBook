using CarBook.Application.Features.Queries.FooterAddressQueries;
using CarBook.Application.Features.Results.FeatureResults;
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
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var query=await _repository.Get(request.Id);
            if (query != null)
            {
            return new GetFooterAddressByIdQueryResult
            {
                Id = query.ID,
                Address = query.Address,
                Description = query.Description,
                Email = query.Email,
                Phone = query.Phone
            };
               
            }
            else
            {
                return null;
            }
        }
    }
}
