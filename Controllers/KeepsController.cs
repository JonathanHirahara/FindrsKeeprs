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
    [Authorize]
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
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_repo.GetAllKeeps());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpGet("user")]
    public ActionResult<Keep> Get(string user)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetKeepsByUserId(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{Id}")]
    public ActionResult<Keep> Get(int Id)
    {
      try
      {
        return Ok(_repo.GetKeepByKeepId(Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }







}