using System;
using System.Threading.Tasks;
using Xunit;

namespace volvoTest
{
    public class volvoTest
    {
        [Fact]
        public async Task test_caminhao()
        {
            var dadosTest = await ConfigVolvoTest.GetDatabaseMockContext();

            var caminhoesControllerTest = new volvo.Controllers.CaminhoesController(dadosTest);

            var caminhao = await caminhoesControllerTest.Index();
            Assert.NotNull(caminhao);

        }
    }
}
