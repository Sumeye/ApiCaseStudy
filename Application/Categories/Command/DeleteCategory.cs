using MediatR;

namespace Application.Categories.Command
{
    public class DeleteCategory : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
