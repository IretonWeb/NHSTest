using MediatR;
using Microsoft.EntityFrameworkCore;
using NHSTest.Application.ResponseModels;
using NHSTest.Persistence;

namespace NHSTest.Application.Queries.Requirements;

public class GetRequirementQuery : IRequest<GenericResponseModel>
{
    public int Id { get; set; }

    public class ResponseModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? Status { get; set; }
        public string? StaffMember { get; set; }
        public DateTime DateCreated { get; set; }


    }
    public class Handler : IRequestHandler<GetRequirementQuery, GenericResponseModel>
    {
        private readonly IDataContext _context;

        public Handler(IDataContext context)
        {
            _context = context;
        }

        public async Task<GenericResponseModel> Handle(GetRequirementQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Requirements.Include(x => x.Staff).SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

            var response = new ResponseModel();

            if (res == null)
            {
                return GenericResponseModel.Failed("Cannot find requirement", response);
            }

            response.Id = res.Id;
            response.Description = res.Description;
            response.Status = res.Status;
            response.DateCreated = res.DateCreated;
            response.Title = res.Title;
            response.StaffMember = $"{res.Staff?.FirstName} {res.Staff?.Surname}"; 

            return GenericResponseModel.Succeeded(response);

        }
    }
}