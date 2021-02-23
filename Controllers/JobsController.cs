using System;
using System.Collections.Generic;
using contracts.Models;
using contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace contracts.Controllers
{
            [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _js;
      private readonly ContractorsService _cs;

    public JobsController(JobsService js, ContractorsService cs)
    {
      _js = js;
      _cs = cs;

    }
    [HttpGet]
    public ActionResult<IEnumerable<Job>> Get()
    {
        try
        {
        return Ok(_js.Get());
      }
        catch (System.Exception err)
        {
            
                return BadRequest(err.Message);
        }
    }
        [HttpGet("{id}")]
        public ActionResult<Job> Get(int id)
        {
            try
            {
        Job job = _js.GetById(id);
        return Ok(job);
      }
            catch (Exception e)
            {
                
        return BadRequest(e.Message);
            }
        }
        [HttpPost]
    public ActionResult<Job> Create([FromBody] Job newJob)
    {
        try
        {
        Job job = _js.Create(newJob);
        return Ok(job);
      }
        catch (System.Exception err)
        {
            
                return BadRequest(err.Message);
        }
    }
[HttpDelete("{jobId}")]
    public ActionResult<string> Delete(int jobId)
    {
      try
      {
        _js.Delete(jobId);
        {
          return Ok("Deleted");
        };
        throw new System.Exception("Job does not exist");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }

    }

   [HttpPut("{jobId}")]
        public ActionResult<Job> edit([FromBody] Job jobUpdate, int jobId)
        {
            try
            {
        jobUpdate.Id = jobId;
        Job job = _js.Edit(jobUpdate);
        return Ok(jobUpdate);
      }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{JobId}/contractors")]
    public ActionResult<IEnumerable<Contractor>> GetContracts(int jobId)
    {
      try
      {
        return Ok(_cs.GetContractorsByJobId(jobId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    }
}