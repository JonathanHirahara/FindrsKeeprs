using System;
using System.Collections.Generic;
using System.Security.Claims;
using FindrsKeeprs.Models;
using FindrsKeeprs.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindrsKeeprs.Controllers
{

  [Route("api/[controller]")]
  [ApiController]

  public class KeepsController : ControllerBase
  {
    private readonly KeepsRepository _repo;

    public KeepsController(KeepsRepository repo)
    {
      _repo = repo;
    }
    // [Authorize]
    [HttpPost]
    public ActionResult<Keep> Post([FromBody]Keep keep)
    {
      try
      {
        keep.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.CreateKeep(keep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Keep>> GetPublicKeeps()
    {
      try
      {
        int isprivate = 0;
        return Ok(_repo.GetAllPublicKeeps(isprivate));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      try
      {
        int isprivate = 0;
        return Ok(_repo.GetKeepById(id, isprivate));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetKeepsByUserId(string userId)
    {
      try
      {
        string UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetKeepsByUserId(UserId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<Keep> Delete(int id)
    {
      try
      {
        //FIXME PASS IN THE USERID
        //NOTE added userId to controller
        string userId = HttpContext.User.FindFirstValue("Id");

        return Ok(_repo.DeleteKeepById(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{id}/view")]
    public ActionResult<Keep> ViewCount(int id, Keep keep)
    {
      try
      {
        //FIXME PASS IN THE USERID
        //Find the keep
        keep.Views++;
        return Ok(_repo.UpdateKeepViewsCount(id, keep.Views));

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}/kept")]
    public ActionResult<Keep> KeptCount(int id, Keep keep)
    {
      try
      {
        //FIXME PASS IN THE USERID
        //Find the keep
        keep.Keeps++;
        return Ok(_repo.UpdateKeptKeepsCount(id, keep.Keeps));

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}







