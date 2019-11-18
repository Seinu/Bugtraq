using System.Threading.Tasks;
using bugtraq.API.Models;

namespace bugtraq.API.Data
{
  public interface IAuthRepository
  {
    Task<Developer> Register(Developer developer, string password, string firstname, string lastname, string department);
    Task<Developer> Login(string email, string password);
    Task<bool> EmailExists(string email);
  }
}