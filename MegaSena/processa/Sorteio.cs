using System;
public class Sorteio
{
    public double valorDoPremio { get; set; }
    private List<Bilhete> bilhetes = new();
    private List<Bilhete> premiados6 = new();
    private List<Bilhete> premiados5 = new();
    private List<Bilhete> premiados4 = new();
    private IGeradorDeNumeros _gerador;
    public int QuantidadeDeBilhetes()
    {
        return bilhetes.Count();
    }
    public Sorteio(double valor, IGeradorDeNumeros gerador)
    {
        this._gerador = gerador;
        this.valorDoPremio = valor;

    }
    public int QuantosAcertaram6(){
        return premiados6.Count();
    }
    public int[] GetQuantidadeDePremiados(){
        return new int[]{
            premiados6.Count(),
            premiados5.Count(),
            premiados4.Count(),
        };
    }

    public void DivideOPremio(){
        double valorParaQuemAcertou6 = 0;
        double valorParaQuemAcertou5 = 0;
        double valorParaQuemAcertou4 = 0;


        var OitentaPorCento = this.valorDoPremio * 0.8;
        valorParaQuemAcertou6 = OitentaPorCento / premiados6.Count();

       var QuinzePorCento = this.valorDoPremio * 0.15;
        valorParaQuemAcertou5 = OitentaPorCento / premiados6.Count();

       var CincoPorCento = this.valorDoPremio * 0.05;
        valorParaQuemAcertou4 = OitentaPorCento / premiados6.Count();

        

    }

    public void RealizaSorteio(){

        var numerosPremiados = _gerador.getNumerosSorteados();

        foreach(var bilhete in bilhetes){

            int quantidadeDeAcertos = ConfereNumeroDeAcertos(bilhete.Numeros, numerosPremiados);

            switch(quantidadeDeAcertos){
                case 6:
                    premiados6.Add(bilhete);
                break;
                case 5:
                    premiados5.Add(bilhete);
                break;
                case 4:
                    premiados4.Add(bilhete);
                break;
            }
   
        }
    }
    private int ConfereNumeroDeAcertos(int[] jogoASerConferido,int[] numerosPremiados){
        int qt = 0;
        foreach(var numero in jogoASerConferido){

            foreach(var premiado in numerosPremiados){

                if(numero == premiado){
                    qt++;
                }
            }
        }
        return qt;
    }
    public void Jogar(Bilhete bilhete)
    {
        if (bilhete.Numeros?.Length == 6)
        {
            if(bilhete.Numeros.Any((item) => { return item > 60; })){
                 throw new Exception("Existe números maiores que 60");
            }
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