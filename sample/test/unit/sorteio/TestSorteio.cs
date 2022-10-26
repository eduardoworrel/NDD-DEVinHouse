namespace test;
using lib;
public class TestSorteio
{


    [TestCase(0)]
    [TestCase(-0.50)]
    public void TestSemValorValido(decimal value)
    {

        Assert.Catch(()=>{
            new Sorteio(value);
        });

    }
    
    [TestCase(1)]
    [TestCase(0.01)]
    public void TestComValorValido(decimal value)
    {

        var sorteio = new Sorteio(value);

        Assert.NotZero(sorteio.valorDoPremio);
        Assert.Greater(sorteio.valorDoPremio,0);
    
    }
}