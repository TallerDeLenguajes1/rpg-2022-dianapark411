
public enum Tipo{ 
    Brujo, 
    Hechicera, 
    Princesa, 
    Elfo,
    Dragon,
}

public enum Nombre{
    GeraltDeRivia,
    YenneferDeVenderberg,
    CirillaDeCintra,
    FilavandrelAénFidháil,
    Villentretenmerth, 
}
public enum Apodo{
    Geralt,
    Yennefer,
    Ciri,
    Filavandrel,
    Borch, 
}
public class personaje{
    public class datos{
        public Tipo tipo;
        public Nombre Nombre;
        public Apodo Apodo;
        public DateTime FechaNacimiento {get;set;}
        public int Edad {get;set;}
        public int Salud {get;set;}
    }

    DateTime fechaActual = DateTime.Today;
    public int edad = 0;
    public int calcularEdad(DateTime FechaNacimiento){
        edad = fechaActual.Year - FechaNacimiento.Year;
        if(FechaNacimiento.Month > fechaActual.Month){
            edad = edad-1;
        }
        return edad;
    }
    public class caracteristicas{
        public int Velocidad {get;set;}
        public int Destreza {get;set;}
        public int Fuerza {get;set;}
        public int Nivel {get;set;}
        public int Armadura {get;set;}
    }

}