namespace test.api;
using service;

public class TesteRiscos
{
    private List<ObjetoAereo> doisObjetos = new List<ObjetoAereo>{
            new ObjetoAereo{
                Id = 1,
                Latitude = 32.887548,
                Longitude =  -65.009726,
                Altitude = 1000
            },
            new ObjetoAereo{
                Id = 2,
                Latitude =  32.897206,
                Longitude = -65.010466,
                Altitude = 900
            },
       };

    private List<ObjetoAereo> objetosGrudades = new List<ObjetoAereo>{
            new ObjetoAereo{
                Id = 1,
                Latitude = 32.887548,
                Longitude =  -65.009726,
                Altitude = 1000
            },
            new ObjetoAereo{
                Id = 2,
                 Latitude = 32.887548,
                Longitude =  -65.009726,
                Altitude = 900
            },
       };

    [Test]
    public void GaranteFalhaAoNaoEncontrarObjeto()
    {
      Assert.Catch(()=>{
        var risco = RiscoService.getRiscoFrom(3,doisObjetos);
      });
    }

    [Test]
    public void GaranteQueRiscoEstaDentroDoEsperado()
    {
        int riscoComDoisObjetos = RiscoService.getRiscoFrom(1,doisObjetos);
        int riscoComObjetosGrudados = RiscoService.getRiscoFrom(1,objetosGrudades);
        
        
        Assert.GreaterOrEqual(riscoComDoisObjetos,0);
        Assert.LessOrEqual(riscoComDoisObjetos,100);

        Assert.Positive(riscoComObjetosGrudados);
        Assert.AreEqual(riscoComObjetosGrudados,100);
    }
}