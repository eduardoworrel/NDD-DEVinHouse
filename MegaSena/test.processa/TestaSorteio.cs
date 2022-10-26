using System.Reflection;
namespace test.processa;

public class TestaSorteio
{
    [Test]
    public void SorteioIniciaComValor()
    {
        var sorteio = new Sorteio(10000);
        Assert.NotNull(sorteio.valorDoPremio);
    }
}