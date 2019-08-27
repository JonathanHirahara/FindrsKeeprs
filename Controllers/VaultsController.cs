using System;
using System.Security.Claims;
using FindrsKeeprs.Models;
using FindrsKeeprs.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindrsKeeprs.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]

  public class VaultsController : ControllerBase
  {
    private readonly VaultsRepository _repo;

    public VaultsController(VaultsRepository repo)
    {
      _repo = repo;
    }

    [HttpPost]
    public ActionResult<Vault> Post([FromBody]Vault vault)
    {
      try
      {
        vault.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.CreateVault(vault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Vault> Get()
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetVaultsByUserId(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{vaultId}")]
    public ActionResult<Vault> Delete(int vaultId)
    {
      try
      {
        return Ok(_repo.DeleteVaultById(vaultId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}