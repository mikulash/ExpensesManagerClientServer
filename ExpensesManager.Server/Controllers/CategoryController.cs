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
    public ActionResult<CategoryDto> Get(int id)
    {
        var userId = GetUserId();
        var retval = categoryFacade.GetCategoryById(id, userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpPost("AddOrUpdate")]
    public ActionResult<CategoryDto> Post(CategoryDto categoryDto)
    {
        var userId = GetUserId();
        var retval = categoryFacade.SetCategory(categoryDto, userId);
        return FacadeResponseToActionResult(retval);
    }

    [HttpDelete]
    public ActionResult<bool> Delete(int categoryId)
    {
        var userId = GetUserId();
        var retval = categoryFacade.DeleteCategory(categoryId, userId);
        return FacadeResponseToActionResult(retval);
    }


    [HttpGet("GetAll")]
    public ActionResult<List<CategoryDto>> GetAll()
    {
        var userId = GetUserId();
        var retval = categoryFacade.GetAllCategoriesByUser(userId);
        return FacadeResponseToActionResult(retval);
    }
}
