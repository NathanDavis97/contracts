using System.Collections.Generic;
using System.Data;
using contracts.Models;
using Dapper;

namespace contracts.Repositories
{
    public class JobsRepository
    {
        private readonly IDbConnection _db;

       public JobsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Job> GetAll()
    {
      string sql = "SELECT * FROM jobs;";
      return _db.Query<Job>(sql);
    }

    internal Job GetById(int id)
    {
      string sql = "SELECT * FROM jobs WHERE id = @id;";
      return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }

    internal Job Create(Job newJob)
    {
      string sql = @"
      INSERT INTO jobs
      (title, pay)
      VALUES
      (@Title, @Pay);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newJob);
      newJob.Id = id;
      return newJob;
    }

    internal Job Edit(Job update)
    {
      string sql = @"
      UPDATE FROM jobs
      SET
       dimensions = @Dimensions,
       title = @Title,
       pay = @Pay
      WHERE id = @Id";
      _db.Execute(sql, update);
      return update;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM jobs WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
    }
}