using System.Data;
using contracts.Models;
using Dapper;

namespace contracts.Repositories
{
    public class ContractsRepository
    {
    private readonly IDbConnection _db;

    public ContractsRepository(IDbConnection db)
    {
      _db = db;
    }

    public int Create(Contract NewContract)
    {
      string sql = @"
        INSERT INTO contracts
        (jobId, contractorId)
        VALUES
        (@JobId, @ContractorId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, NewContract);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM contracts WHERE id = @id;";
      _db.Execute(sql, new { id });
    }
  }
}