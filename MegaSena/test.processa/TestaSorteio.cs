using System.Reflection;
using Moq;
namespace test.processa;

public class TestaSorteio
{
    private GeradorDeNumeros _gerador;
    public TestaSorteio(){
        _gerador = new GeradorDeNumeros();
    }

    [Test]
    public void TestaHouveVencedoresComAcertos()
    {

        var mock = new Mock<IGeradorDeNumeros>();

        mock.Setup((i)=>i.getNumerosSorteados())
            .Returns(new int[]{0,1,2,3,4,5});

        var gerador = mock.Object;

        var sorteio = new Sorteio(100000,gerador);

        sorteio.Jogar(new Bilhete{
            Numeros = new int[]{0,1,2,3,4,5}
        });
          sorteio.Jogar(new Bilhete{
            Numeros = new int[]{0,1,2,3,4,5}
        });
        
        sorteio.Jogar(new Bilhete{
            Numeros = new int[]{0,10,2,3,4,5}
        });

        sorteio.Jogar(new Bilhete{
            Numeros = new int[]{0,1,20,3,4,5}
        });
        
        sorteio.Jogar(new Bilhete{
            Numeros = new int[]{0,10,2,3,4,50}
        });
        
        sorteio.Jogar(new Bilhete{
            Numeros = new int[]{51,10,2,3,4,50}
        });

        sorteio.RealizaSorteio();

        var result = sorteio.GetQuantidadeDePremiados();

        Assert.AreEqual(result[0],2);
        Assert.AreEqual(result[1],2);
        Assert.AreEqual(result[2],1);


    }

    [Test]
    public void BilhetePodeSerPemiado()
    {
        var mock = new Mock<IGeradorDeNumeros>();
        
        mock.Setup((i)=>i.getNumerosSorteados())
            .Returns(new int[]{0,1,2,3,4,5});
        
        var _gerador = mock.Object;

        Bilhete b = new Bilhete{
            Numeros=new int[]{0,1,2,3,4,5}
        };

        Assert.AreEqual(b.Numeros, _gerador.getNumerosSorteados());
    }

    [Test]
    public void SorteioIniciaComValor()
    {
        var sorteio = new Sorteio(10000,_gerador);
        Assert.NotNull(sorteio.valorDoPremio);
    }

    [TestCase(10)]
    [TestCase(900)]
    [TestCase(1)]
    [TestCase(60000)]
    public void GaranteSorteioArmazenaBilhetes(int quantidadeDeBilhetes){
        var sorteio = new Sorteio(10000,_gerador);

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
        var sorteio = new Sorteio(10000,_gerador);
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
        var sorteio = new Sorteio(10000,_gerador);
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
        var sorteio = new Sorteio(10000,_gerador);
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
    
    [Test]
    public void GaranteBloqueioQuandoNumerosMaioresQue60 ()
    {
        var sorteio = new Sorteio(10000,_gerador);
        Assert.Catch(()=>{
            sorteio.Jogar(new Bilhete{
                    Id = 1,
                    Nome = "Fulano",
                    CPF = "000.000.000-00",
                    Numeros = new int[]{1,2,5,8,6,6000}
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