using Backend.Migrations;
using Microsoft.Data.SqlClient;

namespace Backend.Services;

public class RegistrationService
{
     private readonly string _connectionString;

        public RegistrationService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> RegisterStudentAsync(RegisterDto registerDto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                       
                        var parentId = await InsertParentAsync(registerDto, connection, transaction);

                        
                        var studentId = await InsertStudentAsync(registerDto, parentId, connection, transaction);

                       
                        await UpdateStudentWithParentIdAsync(studentId, parentId, connection, transaction);

                      
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private async Task<int> InsertParentAsync(RegisterDto registerDto, SqlConnection connection, SqlTransaction transaction)
        {
            var query = @"
                INSERT INTO Parents (FatherName, MotherName, Address, Email, Surname, IdentityId,PhoneNumber)
                OUTPUT INSERTED.Id
                VALUES (@FatherName, @MotherName, @Address, @Email, @Surname, @IdentityId,@PhoneNumber)";

            using (var command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@FatherName", registerDto.FatherName);
                command.Parameters.AddWithValue("@MotherName", registerDto.MotherName);
                command.Parameters.AddWithValue("@Address", registerDto.Address);
                command.Parameters.AddWithValue("@Email", registerDto.Email);
                command.Parameters.AddWithValue("@Surname", registerDto.StudentSurname);
                command.Parameters.AddWithValue("@IdentityId", registerDto.IdentityId);
                command.Parameters.AddWithValue("@PhoneNumber", registerDto.PhoneNumber);

                return (int)await command.ExecuteScalarAsync();
            }
        }

        private async Task<int> InsertStudentAsync(RegisterDto registerDto, int parentId, SqlConnection connection, SqlTransaction transaction)
        {
            var query = @"
                INSERT INTO Students (Name, Surname, DateOfBirth, Address, Email, Gender, ParentId,Age,Grade)
                OUTPUT INSERTED.Id
                VALUES (@Name, @Surname, @DateOfBirth, @Address, @Email, @Gender, @ParentId,@Age,@Grade)";

            using (var command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Name", registerDto.StudentName);
                command.Parameters.AddWithValue("@Surname", registerDto.StudentSurname);
                command.Parameters.AddWithValue("@DateOfBirth", registerDto.DateOfBirth);
                command.Parameters.AddWithValue("@Address", registerDto.Address);
                command.Parameters.AddWithValue("@Email", registerDto.Email);
                command.Parameters.AddWithValue("@Gender", registerDto.Gender);
                command.Parameters.AddWithValue("@Age", registerDto.Age);
                command.Parameters.AddWithValue("@Grade", registerDto.Grade);
                command.Parameters.AddWithValue("@ParentId", parentId);

                return (int)await command.ExecuteScalarAsync();
            }
        }

        private async Task UpdateStudentWithParentIdAsync(int studentId, int parentId, SqlConnection connection, SqlTransaction transaction)
        {
            var query = @"
                UPDATE Students
                SET ParentId = @ParentId
                WHERE Id = @StudentId";

            using (var command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@ParentId", parentId);
                command.Parameters.AddWithValue("@StudentId", studentId);

                await command.ExecuteNonQueryAsync();
            }
        }
}