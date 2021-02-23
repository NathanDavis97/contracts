using System;
using System.Collections.Generic;
using contracts.Models;
using contracts.Repositories;

namespace contracts.Services
{
    public class JobsService
    {
         private readonly JobsRepository _repo;

    public JobsService(JobsRepository repo)
    {
      _repo = repo;
    }
        public IEnumerable<Job> Get()
    {
      return _repo.GetAll();
    }
    internal Job GetById(int id)
    {
      Job job = _repo.GetById(id);
      if (job == null)
      {
        throw new Exception("invalid Id");
      } return job;
    }
    internal Job Create(Job newJob)
    {

      return _repo.Create(newJob);
    }
    internal Job Edit(Job updated)
    {
      Job original = GetById(updated.Id);

      original.Title = updated.Title != null ? updated.Title : original.Title;
      original.Pay = updated.Pay > 0 ? updated.Pay : original.Pay;

      return _repo.Edit(original);
;
    }
    internal Job Delete(int id)
    {

      Job job = GetById(id);
      _repo.Delete(id);
      return job;
    }
    }
}