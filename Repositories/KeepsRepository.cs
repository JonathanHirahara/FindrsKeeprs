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
      int id = _db.ExecuteScalar<int>(@"INSERT INTO keeps (name,img, description, userId, isprivate)
      VALUES (@Name,@Img, @Description,@UserId,@IsPrivate);
      SELECT LAST_INSERT_ID();", keep);
      keep.Id = id;
      return keep;

    }
    public IEnumerable<Keep> GetAllPublicKeeps(int isprivate)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate=@IsPrivate", new { isprivate });
    }

    public IEnumerable<Keep> GetKeepsByUserId(string userId)
    {
      try
      {
        return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @UserId", new { userId });
      }
      catch (Exception e)
      {

        throw new Exception("Keeps not found");
      }
    }
    public Keep GetKeepById(int id, int isprivate)
    {
      try
      {
        //FIXME dont allow users to get keeps by id if the keep is private
        //NOTE only allowed isPrivate=0 keeps to be accessed
        var keep = _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id=@Id AND isPrivate=@IsPrivate", new { id, isprivate });
        if (keep != null)
        {
          //TODO UPDATE THE KEEP VIEWS
          keep.Views++;


        }
        return keep;
      }
      catch (Exception e)
      {
        throw new Exception("Keep not found");
      }
    }

    public bool DeleteKeepById(int id, string userId)
    {
      //FIXME only the creator of the keep should be able to delete the keep
      //NOTE added userId
      int success = _db.Execute("DELETE FROM keeps WHERE id=@Id AND userId=@UserID", new { id, userId });
      return success > 0;
    }

    public bool UpdateKeepViewsCount(int id, int views)
    {
      //FIXME mysql statement is wrong
      int success = _db.Execute("UPDATE keeps SET views=@Views WHERE id=@Id", new { id, views });
      return success > 0;
    }
    public bool UpdateKeptKeepsCount(int id, int keeps)
    {
      //FIXME mysql statement is wrong
      int success = _db.Execute("UPDATE keeps SET keeps=@Keeps WHERE id=@Id", new { id, keeps });
      return success > 0;
    }
  }
}