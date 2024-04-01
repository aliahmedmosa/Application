using Application.Responses;

namespace Application.Features.UnitOfMeasurement.Requests.Command
{
    public class CreateUOMCommand : IRequest<BaseCommandResponse<string>>
    {
        public UOMDTO UOMDTO { get; set; }
    }
}
