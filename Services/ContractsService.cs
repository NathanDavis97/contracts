using contracts.Models;
using contracts.Repositories;

namespace contracts.Service
{
    public class ContractsService
    {
    private readonly ContractsRepository _repo;

    public ContractsService(ContractsRepository repo)
    {
      _repo = repo;
    }

    public Contract Create(Contract newContract)
    {
      int id = _repo.Create(newContract);
      newContract.Id = id;
      return newContract;
    }

    internal string Delete(int id)
    {
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}