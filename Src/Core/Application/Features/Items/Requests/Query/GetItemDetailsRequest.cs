namespace Application.Features.Items.Requests.Query
{
    public class GetItemDetailsRequest : IRequest<ItemDTO>
    {
        public int Id { get; set; }
    }
}
