using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using volvo.Data;
using volvo.Models;

namespace volvoTest
{
    public static class ConfigVolvoTest
    {
        public static async Task<ApplicationDbContext> GetDatabaseMockContext()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Caminhao.CountAsync() <= 0)
            {
                for (int i = 1; i <= 50; i++)
                {
                    databaseContext.Caminhao.Add(new Caminhao()
                    {
                        ModeloId = 1,
                        AnoFabricacao = 2020,
                        AnoModelo = 2021
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }
    }
}
