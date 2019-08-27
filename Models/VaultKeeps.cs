using keepr.Models;

namespace FindrsKeeprs.Models
{
  public class VaultKeeps
  {
    public int Id { get; set; }
    public int VaultId { get; set; }
    public int KeepId { get; set; }
    public User UserId { get; set; }

  }
}