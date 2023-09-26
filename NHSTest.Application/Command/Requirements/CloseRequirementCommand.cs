using MediatR;
using Microsoft.EntityFrameworkCore;
using NHSTest.Application.Queries.Requirements;
using NHSTest.Application.ResponseModels;
using NHSTest.Persistence;
using static NHSTest.Application.Queries.Requirements.GetRequirementQuery;

namespace NHSTest.Application.Command.Requirements;

public class CloseRequirementCommand : IRequest<GenericResponseModel>
{
    public int Id { get; set; }

   
    public class Handler : IRequestHandler<CloseRequirementCommand, GenericResponseModel>
    {

     
    private readonly IDataContext _dataContext;

    public Handler(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<GenericResponseModel> Handle(CloseRequirementCommand request, CancellationToken cancellationToken)
    {
        {
            var res = await _dataContext.Requirements.SingleOrDefaultAsync(x => x.Id == request.Id,
                cancellationToken: cancellationToken);

            var response = new ResponseModel();

            if (res == null)
            {
                return GenericResponseModel.Failed("Cannot find requirement", response);
            }

            res.Close();

            await _dataContext.SaveChangesAsync(cancellationToken);
            return GenericResponseModel.Succeeded();
        }
    }
}
    
}