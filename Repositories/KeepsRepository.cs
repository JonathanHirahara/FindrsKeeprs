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
      int id = _db.ExecuteScalar<int>(@"INSERT INTO keeps (name, description, userId)
      VALUES (@Name, @Description,@UserId);
      SELECT LAST_INSERT_ID();", keep);
      keep.Id = id;
      return keep;

    }
    public IEnumerable<Keep> GetAllKeeps()
    {
      return _db.Query<Keep>("SELECT * FROM keeps");
    }

    public ActionResult<Keep> GetKeepsByUserId(string userId)
    {
      try
      {
        return _db.QueryFirst<Keep>("SELECT * FROM keeps WHERE userId = @userId", new { userId });
      }
      catch (Exception e)
      {

        throw new Exception("Keeps not found");
      }
    }
    public Keep GetKeepByKeepId(int Id)
    {
      try
      {

        return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id=@Id", new { Id });
      }
      catch (Exception e)
      {
        throw new Exception("Keep not found");
      }
    }
  }
}