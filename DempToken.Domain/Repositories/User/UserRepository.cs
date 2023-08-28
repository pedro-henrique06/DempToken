using Dapper;
using DempToken.Infra;
using DempToken.Model;

namespace DempToken.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {

        private DBSession _dbSession;

        public UserRepository(DBSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<User> GetByLogin(string? email, string? password)
        {
            var userLogin = new User() { Email = email, Password = password};
            using (var db = _dbSession.Connection)
            {
                string query = "Select * from dbo.[User] where Email = @Email and Password = @Password ";
                var users = await db.QueryFirstOrDefaultAsync<User>(sql: query, param: userLogin);
                return users;
            }
        }

        public async Task<User> GetById(int id)
        {
            using (var db = _dbSession.Connection)
            {
                string query = "Select * from dbo.[User] where Id = @id";
                var users = await db.QueryFirstOrDefaultAsync<User>(sql: query, param: new { id });
                return users;
            }
        }

        public async Task<int> Post(User user)
        {
            using (var db = _dbSession.Connection)
            {
                string query = @"
                    INSERT INTO dbo.[User] ([Name] ,[LastName] ,[CPF] ,[PhoneNumber], [Email], [DateOfBirth])
                    VALUES (@Name, @LastName, @CPF, @PhoneNumber, @Email, @DateOfBirth)";

                var users = await db.ExecuteAsync(sql: query, param: user);

                return users;
            }
        }

        public async Task<int> Put(User user)
        {
            using (var db = _dbSession.Connection)
            {
                string query = @"
                    UPDATE dbo.[User]
                    SET [Name] = @Name ,[LastName] = @LastName ,[CPF] = @CPF ,[PhoneNumber] = @PhoneNumber, [Email] = @Email, [DateOfBirth] = @DateOfBirth
                    WHERE Id = @id";

                var users = await db.ExecuteAsync(sql: query, param: user);

                return users;
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var db = _dbSession.Connection)
            {
                string query = @"
                    DELETE FROM dbo.[User] WHERE Id = @id";

                var users = await db.ExecuteAsync(sql: query, param: new { id });

                return users;
            }
        }

        public Task<IEnumerable<User>> Get()
        {
            throw new NotImplementedException();
        }

        //public static User Get(string userName, string password)
        //{
        //    var users = new List<User>()
        //    {
        //        new() { Id = 1, UserName = "batman", Password = "batman", Role = "manager"},
        //        new() { Id = 2, UserName = "robin", Password = "robin", Role = "employee"}
        //    };
        //    return users.Where(x => x.UserName.ToLower() == userName.ToLower() && x.Password == password).FirstOrDefault();

        //}
    }
}
