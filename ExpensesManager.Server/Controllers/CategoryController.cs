using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoryController(ICategoryFacade categoryFacade) : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<CategoryDto> Get(int id)
    {
        var userId = GetUserId();
        var retval = categoryFacade.GetCategoryById(id, userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<List<CategoryDto>> GetAll()
    {
        var userId = GetUserId();
        var retval = categoryFacade.GetAllCategoriesByUser(userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpPost("AddOrUpdate")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<CategoryDto> Post(CategoryDto categoryDto)
    {
        var userId = GetUserId();
        var retval = categoryFacade.SetCategory(categoryDto, userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> Delete(int categoryId)
    {
        var userId = GetUserId();
        var retval = categoryFacade.DeleteCategory(categoryId, userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpDelete("DeleteAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> DeleteAll()
    {
        var userId = GetUserId();
        var retval = categoryFacade.DeleteAllCategories(userId);
        return FacadeResponseToActionResult(retval);
    }
}
