namespace test;
using lib;
public class TestSoma
{


    public void BooleanValidators()
    {
        bool b = true;
        Assert.False(b);
        Assert.True(b);
    }
    public void NumericValidators()
    {
        
        double d = 0.909;
        Assert.Zero(d);
        Assert.NotZero(d);
        
        Assert.Negative(d);
        Assert.Positive(d);

        Assert.LessOrEqual(d,0);
        Assert.Less(d,0);
        Assert.GreaterOrEqual(d,0);
        Assert.Greater(d,0);

        Assert.IsNaN(d);
        
    }
    [Test]
    public void SystemValidators()
    {
        Object obj = null;

        Assert.IsNotNull(obj);
        Assert.IsNull(obj);

        Assert.Catch(()=>{
            throw new Exception();
        });
        Assert.DoesNotThrow(()=>{
           var sum = 1 + 1;
           sum++;
        });
        
        Assert.IsInstanceOf<Object>(obj);
        Assert.IsNotInstanceOf<String>(obj);
        
    }
    public void ObjectValidators()
    {
        Object obj = new Object{};
        string obj2 = new string(new char[]{'a','b'});
        string obj3 = "ab";

        Assert.AreEqual(obj2,obj3);
        Assert.AreNotEqual(obj,obj2);

        Assert.AreSame(obj2,obj3);
        Assert.AreNotSame(obj2,obj3);

        Assert.IsEmpty(obj2);    // Somente para string
        Assert.IsNotEmpty(obj3); // Somente para string
        
    }

    public void TestComValorValido(int valor1, int valor2, int resultadoEsperado)
    {
        Assert.AreEqual(Class1.sumTwo(valor1,valor2),resultadoEsperado);
    }
   
}