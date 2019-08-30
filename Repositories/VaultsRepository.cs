using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using FindrsKeeprs.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindrsKeeprs.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Vault CreateVault(Vault vault)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO vaults (name, description, userId)
      VALUES (@Name, @Description, @UserId);
      SELECT LAST_INSERT_ID();", vault);

      vault.Id = id;
      return vault;

    }

    public bool DeleteVaultById(int id, string userId)
    {
      //FIXME you need to pass the userId here
      //NOTE added userId in controller
      int success = _db.Execute("DELETE FROM vaults WHERE id = @Id AND userId = @userId", new { id, userId });
      return success > 0;
    }

    public IEnumerable<Vault> GetVaultsByUserId(string userId)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId= @UserId", new { userId });
    }

    public IEnumerable<Vault> GetVaultById(int id)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE id= @Id", new { id });
    }
  }
}
