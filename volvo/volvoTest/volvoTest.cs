using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using volvo.Data;
using volvo.Models;
using Xunit;

namespace volvoTest
{
    public class volvoTest
    {
        [Fact]
        public async Task test_caminhao_index()
        {
            //Index
            var dadosTest = await ConfigVolvoTest.GetDatabaseMockContext();

            var caminhoesControllerTest = new volvo.Controllers.CaminhoesController(dadosTest);

            var caminhaoIndexTest = await caminhoesControllerTest.Index();
            Assert.NotNull(caminhaoIndexTest);
            
        }

        [Fact]
        public async Task test_caminhao_delete()
        {
            //Delete
            var dadosTest = await ConfigVolvoTest.GetDatabaseMockContext();

            var caminhoesControllerTest = new volvo.Controllers.CaminhoesController(dadosTest);

            var caminhaoIndexTest = await caminhoesControllerTest.DeleteConfirmed(dadosTest.Caminhao.FirstOrDefaultAsync().Id);
            Assert.NotNull(caminhaoIndexTest);

        }

        [Fact]
        public async Task test_caminhao_edit()
        {
            //Edit
            var dadosTest = await ConfigVolvoTest.GetDatabaseMockContext();

            var caminhoesControllerTest = new volvo.Controllers.CaminhoesController(dadosTest);

            Caminhao caminhao = new Caminhao();
            caminhao.Id = dadosTest.Caminhao.FirstOrDefaultAsync().Id;
            caminhao.ModeloId = 2;
            caminhao.AnoModelo = 2020;
            caminhao.AnoFabricacao = 2020;
          
            var caminhaoIndexTest = await caminhoesControllerTest.Edit(dadosTest.Caminhao.FirstOrDefaultAsync().Id, caminhao);
            Assert.NotNull(caminhaoIndexTest);

        }
    }
}
