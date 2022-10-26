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

    [TestCase(10)]
    [TestCase(900)]
    [TestCase(1)]
    [TestCase(60000)]
    public void GaranteSorteioArmazenaBilhetes(int quantidadeDeBilhetes){
        var sorteio = new Sorteio(10000);

        Assert.Zero(sorteio.QuantidadeDeBilhetes());

        for(int i = 1; i <= quantidadeDeBilhetes; i++){
            sorteio.Jogar(new Bilhete{
                Id = sorteio.QuantidadeDeBilhetes(),
                Nome = "Fulano",
                CPF = "000.000.000-00",
                Numeros = new int[]{1,5,6,7,8,9}
            });
        }

        Assert.AreEqual(sorteio.QuantidadeDeBilhetes(),quantidadeDeBilhetes);
    }

    [Test]
    public void VerificaRepeteNumeros ()
    {
        var sorteio = new Sorteio(10000);
        Assert.Catch(()=>{
            sorteio.Jogar(new Bilhete{
                    Id = 1,
                    Nome = "Fulano",
                    CPF = "000.000.000-00",
                    Numeros = new int[]{1,1,6,6,6,6}
            });
        });
        Assert.DoesNotThrow(()=>{
            sorteio.Jogar(new Bilhete{
                    Id = 1,
                    Nome = "Fulano",
                    CPF = "000.000.000-00",
                    Numeros = new int[]{1,2,3,7,6,0}
            });
        });
    }

    [Test]
    public void GaranteBloqueioQuandoNumerosNegativos ()
    {
        var sorteio = new Sorteio(10000);
        Assert.Catch(()=>{
            
            sorteio.Jogar(new Bilhete{
                    Id = 1,
                    Nome = "Fulano",
                    CPF = "000.000.000-00",
                    Numeros = new int[]{-1,2,5,8,6,-6}
            });
        });
        Assert.DoesNotThrow(()=>{
            sorteio.Jogar(new Bilhete{
                    Id = 1,
                    Nome = "Fulano",
                    CPF = "000.000.000-00",
                    Numeros = new int[]{1,2,3,7,6,0}
            });
        });
    }
    [TestCase(new int[]{1})]
    [TestCase(new int[]{1,2,3,4,5,6,7,8})]
    public void GaranteBloqueioQuandoQuantidadeInvalida (int[] numerosInvalidos)
    {
        var sorteio = new Sorteio(10000);
        Assert.Catch(()=>{
            sorteio.Jogar(new Bilhete{
                    Id = 1,
                    Nome = "Fulano",
                    CPF = "000.000.000-00",
                    Numeros = numerosInvalidos
            });
        });
        Assert.DoesNotThrow(()=>{
            sorteio.Jogar(new Bilhete{
                    Id = 1,
                    Nome = "Fulano",
                    CPF = "000.000.000-00",
                    Numeros = new int[]{1,2,3,7,6,0}
            });
        });
    }
}