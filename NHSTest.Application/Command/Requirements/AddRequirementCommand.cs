using MediatR;
using Microsoft.EntityFrameworkCore;
using NHSTest.Application.ResponseModels;
using NHSTest.Persistence;
using static NHSTest.Application.Queries.Requirements.GetRequirementQuery;

namespace NHSTest.Application.Command.Requirements;

public class AddRequirementCommand
{
    public class Request : IRequest<GenericResponseModel>
    {
        public string? Title { get; set; }

        public int StaffId { get; set; }
        public string? Description { get; set; }

    

    }

    public class CommandHandler : IRequestHandler<Request, GenericResponseModel>
    {
        private readonly IDataContext _dataContext;

        public CommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<GenericResponseModel> Handle(Request request, CancellationToken cancellationToken)
        {
            {
                var staff = await _dataContext.Staff.SingleOrDefaultAsync(x => x.Id == request.StaffId,
                    cancellationToken: cancellationToken);

                var response = new ResponseModel();

                if (staff == null)
                {
                    return GenericResponseModel.Failed("Cannot find staff member", response);
                }

                var requirements =
                    new Domain.Entities.Requirements(request.Title, request.Description, staff);
                _dataContext.Requirements.Add(requirements);
                await _dataContext.SaveChangesAsync(cancellationToken);
                return GenericResponseModel.Succeeded();
            }
        }
    }
}
