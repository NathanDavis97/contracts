using System;
using System.Collections.Generic;
using System.Data;
using contracts.Models;
using Dapper;

namespace contracts.Repositories
{
    public class ContractorsRepository
    {
        private readonly IDbConnection _db;

       public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Contractor> GetAll()
    {
      string sql = "SELECT * FROM contractors;";
      return _db.Query<Contractor>(sql);
    }

    internal Contractor GetById(int id)
    {
      string sql = "SELECT * FROM contractors WHERE id = @id;";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }

    internal Contractor Create(Contractor newContractor)
    {
      string sql = @"
      INSERT INTO contractors
      (name, yearsInProf)
      VALUES
      (@Name, @YearsInProf);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newContractor);
      newContractor.Id = id;
      return newContractor;
    }

    internal Contractor Edit(Contractor update)
    {
      string sql = @"
      UPDATE FROM contractors
      SET
       dimensions = @Dimensions,
       name = @Name,
       yearsInProf = @Pay
      WHERE id = @Id";
      _db.Execute(sql, update);
      return update;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM contractors WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }

    internal IEnumerable<Contractor> GetContractorsByJobId(int jobId)
    {
       string sql = @"
      SELECT con.*,
      c.id as ContractId 
      FROM contracts c
      JOIN contractors con ON con.id = c.contractorId
      WHERE jobId = @jobId";

      return _db.Query<ContractViewModel>(sql, new { jobId });
    }
  }
}