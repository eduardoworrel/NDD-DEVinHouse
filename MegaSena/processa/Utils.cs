public class Utils{
    public static string junta2Textos(string txt1, string txt2){
        return txt1 + txt2;
    }
    public static string juntaTextos(string[] txts){
        return string.Join(string.Empty,txts);
    }
    public static bool Possui5Caracteres(string txt){
        return txt.Count() == 5;
    }
}