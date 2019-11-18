namespace bugtraq.API.Models
{
  public class Developer
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string Department { get; set; }
    public int TaskId { get; set; }
    public string CurrentTask { get; set; }
  }
}