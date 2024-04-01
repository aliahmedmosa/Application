namespace Application.Features.Items.Requests.Query
{
    public class GetItemDetailsRequest : IRequest<BaseCommandResponse<ItemDTO>>
    {
        public int Id { get; set; }
    }
}
