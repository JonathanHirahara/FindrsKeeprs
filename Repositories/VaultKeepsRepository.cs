using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Dapper;
using FindrsKeeprs.Models;

namespace FindrsKeeprs.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db; public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public VaultKeep CreateVaultsKeeps(VaultKeep vaultKeep)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO vaultkeeps (keepId, vaultId, userId)VALUES (@KeepId, @VaultId, @UserId);
     SELECT LAST_INSERT_ID();", vaultKeep);
      vaultKeep.Id = id;
      return vaultKeep;
    }

    public IEnumerable<Keep> GetVaultKeeps(int vaultId, string userId)
    {
      //FIXME pass in the userId again here so I can only get my vaultkeeps
      //NOTE added userId
      return _db.Query<Keep>(@"
      SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId 
      WHERE (vaultId = @vaultId AND vk.userId = @userId) ", new { vaultId, userId });
    }

    public bool DeleteVaultKeepById(VaultKeep vaultKeep)
    {
      int success = _db.Execute(@"
      DELETE FROM vaultkeeps WHERE 
      vaultId = @VaultId AND 
      keepId = @KeepId AND 
      userId = @UserId", new { vaultKeep });
      return success > 0;
    }
  }
}