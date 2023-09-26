using MediatR;
using Microsoft.EntityFrameworkCore;
using NHSTest.Application.Queries.Requirements;
using NHSTest.Application.ResponseModels;
using NHSTest.Persistence;

namespace NHSTest.Application.Queries.Staff;

public class GetAllStaffQuery : IRequest<GenericResponseModel>
{

    public class Handler : IRequestHandler<GetAllStaffQuery, GenericResponseModel>
    {
        private readonly IDataContext _context;

        public Handler(IDataContext context)
        {
            _context = context;
        }

        public async Task<GenericResponseModel> Handle(GetAllStaffQuery request, CancellationToken cancellationToken)
        {
            var res = _context.Staff;

            return new GenericResponseModel
            {
                Success = true,
                Data = await res.Select(x => new
                {
                    x.FirstName,
                    x.Surname,
                   
                    x.Id
                }).ToListAsync(cancellationToken: cancellationToken)
            };
        }
    }

}