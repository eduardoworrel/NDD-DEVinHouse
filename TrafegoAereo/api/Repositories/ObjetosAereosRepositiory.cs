class ObjetosAereosRepositiory{
    public static List<ObjetoAereo> GetAll(){
        return new List<ObjetoAereo>{
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
            new ObjetoAereo{
                Id = 3,
                Latitude = 30.897548,
                Longitude =  -65.009726,
                Altitude = 1000
            },
        };
    }
}