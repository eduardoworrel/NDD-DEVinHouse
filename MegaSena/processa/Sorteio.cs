using System;
public class Sorteio
{
    public double valorDoPremio { get; set; }
    private List<Bilhete> bilhetes = new();
    public int QuantidadeDeBilhetes()
    {
        return bilhetes.Count();
    }
    public Sorteio(double valor)
    {
        this.valorDoPremio = valor;
    }
    public void Jogar(Bilhete bilhete)
    {

        if (bilhete.Numeros?.Length == 6)
        {
            if (!bilhete.Numeros.Any((item) => { return item < 0; }))
            {

                if (bilhete.Numeros.Distinct().Count() == bilhete.Numeros.Count())
                {
                    bilhetes.Add(bilhete);
                }
                else
                {
                    throw new Exception("Existe números repetidos!");
                }


            }
            else
            {
                throw new Exception("Existe número negativo!");
            }
        }
        else
        {
            throw new Exception("Quantidade inválida!");
        }
    }

}