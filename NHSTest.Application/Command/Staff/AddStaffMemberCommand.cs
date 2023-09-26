using System.ComponentModel.DataAnnotations;
using System.Net;
using MediatR;
using NHSTest.Application.ResponseModels;
using NHSTest.Persistence;

namespace NHSTest.Application.Command.Staff;

public class AddStaffMemberCommand
{
    public class Request : IRequest<GenericResponseModel>
    {
        public string? FirstName { get; set; }

     
        public string? Surname { get; set; }

    }

    public  class CommandHandler : IRequestHandler<Request, GenericResponseModel>
    {
        private readonly IDataContext _dataContext;

        public CommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<GenericResponseModel> Handle(Request request, CancellationToken cancellationToken)
        {
            var staff = new Domain.Entities.Staff(request.FirstName, request.Surname);
            _dataContext.Staff.Add(staff);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return GenericResponseModel.Succeeded();
        }
    }
}