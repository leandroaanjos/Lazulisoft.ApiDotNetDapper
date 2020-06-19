using Dapper;
using Dapper.Contrib.Extensions;
using Lazulisoft.ApiDotNetDapper.Api.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Lazulisoft.ApiDotNetDapper.Api.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connString;

        public HeroRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = _configuration.GetConnectionString("DefaultConnection");            
        }

        public async Task<int> Add(Hero entity)
        {   
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                var id = await connection.InsertAsync<Hero>(entity);
                return id;
            }
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Hero WHERE Id = @Id;";
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
                return affectedRows;
            }
        }

        public async Task<Hero> Get(int id)
        {
            var sql = "SELECT * FROM Hero WHERE Id = @Id;";
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Hero>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Hero>> GetAll()
        {
            var sql = "SELECT * FROM Hero;";
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Hero>(sql);
                return result;
            }
        }

        public async Task<Hero> GetHeroByName(string name)
        {
            var sql = "SELECT * FROM Hero WHERE Name = @Name;";
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Hero>(sql, new { Name = name });
                return result.FirstOrDefault();
            }
        }

        public async Task<int> Update(Hero entity)
        {
            var sql = "UPDATE Hero SET Name = @Name, Publisher = @Publisher, AlterEgo = @AlterEgo, HasSuperPower = @hasSuperPower, Abilities = @Abilities WHERE Id = @Id;";
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }
    }
}
