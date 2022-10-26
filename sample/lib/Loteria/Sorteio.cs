public class Sorteio {
    public decimal valorDoPremio;
    public Sorteio(decimal valor){
       if(valor <= 0){
            throw new Exception("Um sorteio não pode ser iniciado com o valor igual ou inferior a 0");
       }
       this.valorDoPremio = valor;
    }
}