using Application.Dto;
using MediatR;

namespace Application.Categories.Command
{
    public class CreateCategory : IRequest<CreatedCategoryDto>
    {
        public string CategoryName { get; set; }     
    }
}
