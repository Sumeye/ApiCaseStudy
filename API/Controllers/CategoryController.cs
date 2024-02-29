using Application.Categories.Command;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategory createCategory)
        {
            CreatedCategoryDto result = await Mediator.Send(createCategory);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategory updateCategory)
        {
            if (updateCategory.Id == 0)
            {
                return BadRequest();
            }
            await Mediator.Send(updateCategory);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteCategory { Id = id });
            return NoContent();
        }
    }
}
