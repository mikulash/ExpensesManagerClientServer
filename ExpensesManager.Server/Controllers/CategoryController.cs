using ExpensesManager.Server.DTOs;
using ExpensesManager.Server.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoryController(CategoryFacade categoryFacade) : ApiControllerBase
{
    [HttpGet]
    public IActionResult Get(int id)
    {
        var retval = categoryFacade.GetCategoryById(id);
        return FacadeResponseToActionResult(retval);
    }

    [HttpPost("AddOrUpdate")]
    public IActionResult Post(CategoryDto categoryDto)
    {
        var retval = categoryFacade.SetCategory(categoryDto);
        return FacadeResponseToActionResult(retval);
    }

    [HttpDelete]
    public IActionResult Delete(int categoryId)
    {
        var retval = categoryFacade.DeleteCategory(categoryId);
        return FacadeResponseToActionResult(retval);
    }


    [HttpGet("GetAll")]
    public IActionResult GetAll(int? userId)
    {
        if(userId == null)
        {
            return Ok(categoryFacade.GetAllDefaultCategories());
        }
        return Ok(categoryFacade.GetAllCategoriesByUser(userId.Value));
    }
}
