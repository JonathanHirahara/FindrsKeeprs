using System;
using FindrsKeeprs.Models;
using FindrsKeeprs.Repositories;
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

    [HttpGet]
    public ActionResult<Keep> Get()
    {
      try
      {
        return Ok(_repo.GetKeeps());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Keep> Post([FromBody]Keep keep)
    {
      try
      {
        return Ok(_repo.CreateKeep(keep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }







}