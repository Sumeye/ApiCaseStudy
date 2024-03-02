using Application.Categories.Command;
using Application.Categories.Queries;
using Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = new GetAllCategories();
            return Ok(await Mediator.Send(categories));
        }

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
             await Mediator.Send(new DeleteCategory { Id = id });
            return NoContent();
        }
    }
}
