using System;
using System.Threading.Tasks;
using bugtraq.API.Models;
using Microsoft.EntityFrameworkCore;

namespace bugtraq.API.Data
{
  public class AuthRepository : IAuthRepository
  {
      private readonly DataContext _context;
      public AuthRepository(DataContext context)
      {
          _context = context;
      }
    public async Task<bool> EmailExists(string email)
    {
        if(await _context.Devs.AnyAsync(x => x.Email == email)) {
            return true;
        }
        return false;
    }

    public async Task<Developer> Login(string email, string password)
    {
        var dev = await _context.Devs.FirstOrDefaultAsync(x => x.Email == email);

        if(dev == null) {
            return null;
        }

        if(!VerifyPasswordHash(password, dev.PasswordHash, dev.PasswordSalt)) {
            return null;
        }

        return dev;
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for( int i = 0; i < computedHash.Length; i++) {
                if(computedHash[i] != passwordHash[i]) return false;
            }
        }
        return true;
        
    }

    public async Task<Developer> Register(Developer developer, string password, string firstname, string lastname, string department)
    {
        byte[] passwordHash, passwordSalt;
        CreatePasswordHash(password, out passwordHash, out passwordSalt);
        developer.PasswordHash = passwordHash;
        developer.PasswordSalt = passwordSalt;
        developer.FirstName = firstname;
        developer.LastName = lastname;
        developer.Department = department;

        await _context.Devs.AddAsync(developer);
        await _context.SaveChangesAsync();

        return developer;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512()) {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
        
    }
  }
}