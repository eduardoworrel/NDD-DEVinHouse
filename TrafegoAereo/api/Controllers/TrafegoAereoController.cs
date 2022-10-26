using Microsoft.AspNetCore.Mvc;
using service;
namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class TrafegoAereoController : ControllerBase
{
   
    [HttpGet(Name = "GetRisco")]
    public int Get(int id)
    {
        var objetosNoAr = ObjetosAereosRepositiory.GetAll();
        return RiscoService.getRiscoFrom(id,objetosNoAr);
    }
}
