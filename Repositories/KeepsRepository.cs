using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using FindrsKeeprs.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindrsKeeprs.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public Keep CreateKeep(Keep keep)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO keeps (name, description)
      VALUES (@Name, @Description);
      SELECT LAST_INSERT_ID();", keep);
      keep.Id = id;
      return keep;

    }
    public IEnumerable<Keep> GetKeeps()
    {
      return _db.Query<Keep>("SELECT * FROM keeps;");
    }

    public ActionResult<Keep> GetKeepsByUserId(int userId)
    {
      try
      {
        return _db.QueryFirst<Keep>("SELECT * FROM keeps WHERE id = @userId", new { userId });
      }
      catch (Exception e)
      {

        throw new Exception("Keeps not found");
      }
    }
  }
}