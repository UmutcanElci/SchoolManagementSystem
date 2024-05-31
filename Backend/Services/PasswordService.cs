using System.Text;
using Backend.Context;
using Backend.Migrations;
using Microsoft.Data.SqlClient;

namespace Backend.Services;

public class PasswordService
{
    private readonly MyDbContext _context;

    public PasswordService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<int> GenerateAndStorePasswordAsync()
    {
        // Generate a random 8-character password
        var password = GenerateRandomPassword(8);

        // Store the password in the Passwords table
        var passwordEntity = new Password
        {
            LoginPassword = password
        };

        _context.Passwords.Add(passwordEntity);
        await _context.SaveChangesAsync();

        // Return the ID of the newly created password record
        return passwordEntity.Id;
    }

    private string GenerateRandomPassword(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var password = new StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            password.Append(chars[random.Next(chars.Length)]);
        }

        return password.ToString();
    }
}