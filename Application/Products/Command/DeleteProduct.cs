using MediatR;

namespace Application.Products.Command
{
    public class DeleteProduct : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
