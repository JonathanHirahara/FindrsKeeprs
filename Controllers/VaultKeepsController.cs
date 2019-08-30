using System;
using System.Collections.Generic;
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

  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsRepository _repo;

    public VaultKeepsController(VaultKeepsRepository repo)
    {
      _repo = repo;
    }
    [HttpPost]
    public ActionResult<VaultKeep> Post([FromBody]VaultKeep vaultKeep)
    {
      try
      {
        vaultKeep.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.CreateVaultsKeeps(vaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Keep>> get(int id)
    {
      try
      {
        //FIXME add the userId
        //NOTE added userId to controller
        string userId = HttpContext.User.FindFirstValue("Id");

        return Ok(_repo.GetVaultKeeps(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]

    public ActionResult<VaultKeepsController> Delete(VaultKeep vaultKeep)
    {
      try
      {
        //FIXME Add the userId to vaultKeep dont trust the frontend
        //NOTE added userId to controller
        vaultKeep.UserId = HttpContext.User.FindFirstValue("Id");

        return Ok(_repo.DeleteVaultKeepById(vaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}