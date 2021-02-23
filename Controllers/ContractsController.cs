using Microsoft.AspNetCore.Mvc;
using contracts.Models;
using contracts.Service;

namespace contracts.Controllers
{
      [Route("api/[controller]")]
  [ApiController]
    public class ContractsController :ControllerBase
    {
    private readonly ContractsService _service;
    public ContractsController(ContractsService service)
    {
      _service = service;
    }

    [HttpPost]
    public ActionResult<Contract> Post([FromBody] Contract newContract )
    {
        try
        {
        return Ok(_service.Create(newContract));
      }
        catch (System.Exception e)
        {
            
            return BadRequest(e.Message);
        }
    }
[HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }



  }
}