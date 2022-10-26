namespace service;

public class RiscoService{
   
    public static int getRiscoFrom(int id, List<ObjetoAereo> objetosNoAr){

        var objetoEmQuestao = objetosNoAr.Find((item)=> item.Id == id);

        objetosNoAr = objetosNoAr.Where((item)=> item.Id != id).ToList();

        if(objetoEmQuestao == null){
            throw new Exception("Nenhum objeto encontrado para este id");
        }
        
        int maiorRisco = 0;

        foreach(var item in objetosNoAr){

            var riscoIdentificado = 0;

            double distancia = GetDistanciaEntreDoisPontos(objetoEmQuestao,item);
            riscoIdentificado = IdentificaRiscoPorMetro(distancia);
            
            if(riscoIdentificado > maiorRisco){
               maiorRisco = riscoIdentificado;
            }
        }

        return maiorRisco;
    }

    private static int IdentificaRiscoPorMetro(double distancia)
    {
        var riscoIdentificado = 0;
        if(distancia < 301){ // acoplado
            riscoIdentificado = 100;
        }
        if(distancia > 301 && distancia < 601){
            riscoIdentificado = 50;
        }
        if( distancia > 601){
            riscoIdentificado = 0;
        }
        return riscoIdentificado;
    }

    public static double GetDistanciaEntreDoisPontos(ObjetoAereo obj1,ObjetoAereo obj2){
        // a latitude e longitude é valida?
        var distanceKM = Math.Sqrt((Math.Pow(obj1.Latitude - obj2.Latitude , 2) + Math.Pow(obj1.Longitude  - obj2.Longitude, 2)));
        return (Int32) Math.Round(1000*distanceKM, 0);
    }
}