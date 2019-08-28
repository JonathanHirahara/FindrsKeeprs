using System;
using System.Collections;
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

    public IEnumerable GetVaultKeeps(int id)
    {
      return _db.Query<VaultKeep>("SELECT * FROM vaultkeeps WHERE id = @Id", new { id });
    }

    public bool DeleteVaultKeepById(VaultKeep vaultKeep)
    {
      int success = _db.Execute("DELETE FROM vaultkeeps Where id = @ID,vaultId = @VaultId, keepId = @KeepId, userId = @UserID", new { vaultKeep });
      return success > 0;
    }
  }
}