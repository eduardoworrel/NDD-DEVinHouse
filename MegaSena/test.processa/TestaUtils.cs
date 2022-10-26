using System.Reflection;
namespace test.processa;

public class TestaUtils
{
    [TestCase("","","")]
    [TestCase("abc","def","abcdef")]
    public void ConcatenacaoDeDoisFuncionaComoEsperado(string txt1,string txt2, string resultadoEsperado)
    {
        var resultado = Utils.junta2Textos(txt1,txt2);
        Assert.AreEqual(resultado,resultadoEsperado);
    }
    [TestCase("qwert",true)]
    [TestCase("a",false)]
    [TestCase("11111",true)]
    public void ConcatenacaoDeDoisFuncionaComoEsperado(string txt1, bool resultadoEsperado)
    {
        var resultado = Utils.Possui5Caracteres(txt1);
        Assert.AreEqual(resultado,resultadoEsperado);
    }
}