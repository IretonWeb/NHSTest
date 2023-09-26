using MediatR;
using Microsoft.EntityFrameworkCore;
using NHSTest.Application.ResponseModels;
using NHSTest.Persistence;

namespace NHSTest.Application.Queries.Requirements;

public class GetAllRequirementsQuery : IRequest<GenericResponseModel>
{

    public class Handler : IRequestHandler<GetAllRequirementsQuery, GenericResponseModel>
    {
        private readonly IDataContext _context;

        public Handler(IDataContext context)
        {
            _context = context;
        }

        public async Task<GenericResponseModel> Handle(GetAllRequirementsQuery request, CancellationToken cancellationToken)
        {
            var res = _context.Requirements;

            return new GenericResponseModel
            {
                Success = true,
                Data = await res.Select(x => new
                {
                    x.Description,
                    x.Status,
                    x.Title,
                    x.DateCreated,
                    x.Id
                }).ToListAsync(cancellationToken: cancellationToken)
            };
        }
    }
}