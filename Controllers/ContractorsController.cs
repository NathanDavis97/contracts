using System;
using System.Collections.Generic;
using contracts.Models;
using contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace contracts.Controllers
{
            [ApiController]
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsService _cs;
    public ContractorsController(ContractorsService cs)
    {
      _cs = cs;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Contractor>> Get()
    {
        try
        {
        return Ok(_cs.Get());
      }
        catch (System.Exception err)
        {
            
                return BadRequest(err.Message);
        }
    }
        [HttpGet("{id}")]
        public ActionResult<Contractor> Get(int id)
        {
            try
            {
        Contractor contractor = _cs.GetById(id);
        return Ok(contractor);
      }
            catch (Exception e)
            {
                
        return BadRequest(e.Message);
            }
        }
        [HttpPost]
    public ActionResult<Contractor> Create([FromBody] Contractor newContractor)
    {
        try
        {
        Contractor contractor = _cs.Create(newContractor);
        return Ok(contractor);
      }
        catch (System.Exception err)
        {
            
                return BadRequest(err.Message);
        }
    }
[HttpDelete("{contractorId}")]
    public ActionResult<string> Delete(int contractorId)
    {
      try
      {
        _cs.Delete(contractorId);
        {
          return Ok("Deleted");
        };
        throw new System.Exception("Contractor does not exist");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }

    }

   [HttpPut("{contractorId}")]
        public ActionResult<Contractor> edit([FromBody] Contractor contractorUpdate, int contractorId)
        {
            try
            {
        contractorUpdate.Id = contractorId;
        Contractor contractor = _cs.Edit(contractorUpdate);
        return Ok(contractorUpdate);
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
    }
}