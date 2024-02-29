using MediatR;

namespace Application.Categories.Command
{
    public class UpdateCategory:IRequest<int>
    {
        public int Id { get; set; }
        public string CategoryName{ get; set; }

    }
}
