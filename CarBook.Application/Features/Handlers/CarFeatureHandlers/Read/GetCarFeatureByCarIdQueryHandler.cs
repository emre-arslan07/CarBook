using CarBook.Application.Features.Queries.CarFeatureQueries;
using CarBook.Application.Features.Results.CarFeatureResults;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CarFeatureHandlers.Read
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _carFeatureRepository.GetCarFeaturesByCarId(request.Id);
            return query.Select(x=>new GetCarFeatureByCarIdQueryResult
            { CarId = x.CarId,
                FeatureId = x.FeatureId,
                FeatureName=x.Feature.Name,
                Available=x.Available,
                Id=x.ID
            }).ToList();
        }
    }
}
