using System;
using System.Collections.Generic;
using contracts.Models;
using contracts.Repositories;

namespace contracts.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _repo;
    private readonly JobsRepository _jrepo;


    public ContractorsService(ContractorsRepository repo, JobsRepository jrepo)
    {
      _repo = repo;
      _jrepo = jrepo;

    }
    public IEnumerable<Contractor> Get()
    {
      return _repo.GetAll();
    }
    internal Contractor GetById(int id)
    {
      Contractor contractor = _repo.GetById(id);
      if (contractor == null)
      {
        throw new Exception("invalid Id");
      }
      return contractor;
    }
    internal Contractor Create(Contractor newContractor)
    {

      return _repo.Create(newContractor);
    }
    internal Contractor Edit(Contractor updated)
    {
      Contractor original = GetById(updated.Id);

      original.Name = updated.Name != null ? updated.Name : original.Name;
      original.YearsInProf = updated.YearsInProf > 0 ? updated.YearsInProf : original.YearsInProf;

      return _repo.Edit(original);
      ;
    }
    internal Contractor Delete(int id)
    {

      Contractor contractor = GetById(id);
      _repo.Delete(id);
      return contractor;
    }

    internal IEnumerable<Contractor> GetContractorsByJobId(int jobId)
    {
      Job exists = _jrepo.GetById(jobId);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return _repo.GetContractorsByJobId(jobId);
    }
  }
}