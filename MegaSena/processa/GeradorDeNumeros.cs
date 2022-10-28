public class GeradorDeNumeros : IGeradorDeNumeros{
    private static Random r = new Random();

    public int[] getNumerosSorteados(){
        var resultado = new int[6];
        while(resultado.Distinct().Count() != 6){
            resultado = new int[6]{
                getNumeroAleatorio(),
                getNumeroAleatorio(),
                getNumeroAleatorio(),
                getNumeroAleatorio(),
                getNumeroAleatorio(),
                getNumeroAleatorio()
            };
        }
        return resultado;
    }
    
    public int getNumeroAleatorio(){
        return r.Next(0,60);
    }

    public int Sum(int a, int b){
        return a + b;
    }
}