using System.Text.Json.Serialization;

public class personaje{
    public datos dat {get;set;}
    public caracteristicas carac {get;set;}
    
    public personaje(datos _dat, caracteristicas _carac){
        dat = _dat; 
        carac = _carac;
    }
    public personaje(){
    }

    public void mostrarUnPersonaje(personaje _personaje){
        //Console.WriteLine("\n--------DATOS DEL PERSONAJE--------");
        Console.WriteLine($"Tipo: {_personaje.dat.Tipo}");
        Console.WriteLine($"Nombre: {_personaje.dat.Nombre}");
        Console.WriteLine($"Apodo: {_personaje.dat.Apodo}");
        Console.WriteLine($"Fecha de nacimiento: {_personaje.dat.FechaNacimiento.ToShortDateString()}");
        Console.WriteLine($"Edad: {_personaje.dat.Edad}");
        Console.WriteLine($"Salud: {_personaje.dat.Salud}");

        //Console.WriteLine("\n----CARACTERISTICAS DEL PERSONAJE----");
        Console.WriteLine($"Velocidad: {_personaje.carac.Velocidad}");
        Console.WriteLine($"Destreza: {_personaje.carac.Destreza}");
        Console.WriteLine($"Fuerza: {_personaje.carac.Fuerza}");
        Console.WriteLine($"Nivel: {_personaje.carac.Nivel}");
        Console.WriteLine($"Armadura: {_personaje.carac.Armadura}");
    }
}

public enum Tipo{ Brujo, Hechicera, Princesa, Curandera, Soldado, Arquero, Incendiario, Hacker, Transformer, Cientifico, Vaquero}

public class datos{
    [JsonConverter(typeof(JsonStringEnumConverter))] //sino se pone el entero que le corresponde al string
    public Tipo Tipo {get;set;}
    public string Nombre {get;set;}
    public string Apodo {get;set;}
    public DateTime FechaNacimiento {get;set;}
    public int Edad {get;set;}
    public int Salud {get;set;}

    DateTime fechaActual = DateTime.Today;
    public int edad = 0;
    public int calcularEdad(DateTime FechaNacimiento){
        edad = fechaActual.Year - FechaNacimiento.Year;
        if(FechaNacimiento.Month > fechaActual.Month){
            edad = edad-1;
        }
        return edad;
    }
    public DateTime RandomDay() {
        DateTime start = new DateTime(1722, 1, 1); 
        Random gen = new Random(); 
        int range = (DateTime.Today - start).Days; 
        return start.AddDays(gen.Next(range)); 
    }

    public datos(int tipo, List<string> nombres, List<string> apodos){
                
        switch (tipo){
            case 0:
                Tipo = Tipo.Hacker;
                Nombre = nombres[tipo];
                Apodo = apodos[tipo];
                break;
            case 1:
                Tipo = Tipo.Soldado;
                Nombre = nombres[tipo];
                Apodo = apodos[tipo];
                break;
            case 2:
                Tipo = Tipo.Princesa;
                Nombre = nombres[tipo];
                Apodo = apodos[tipo];
                break;
            case 3:
                Tipo = Tipo.Cientifico;
                Nombre = nombres[tipo];
                Apodo = apodos[tipo];
                break;
            case 4:
                Tipo = Tipo.Transformer;
                Nombre = nombres[tipo];
                Apodo = apodos[tipo];
                break;
            case 5:
                Tipo = Tipo.Soldado;
                Nombre = nombres[tipo];
                Apodo = apodos[tipo];
                break;
            case 6:
                Tipo = Tipo.Vaquero;
                Nombre = nombres[tipo];
                Apodo = apodos[tipo];
                break;
            case 7:
                Tipo = Tipo.Arquero;
               Nombre = nombres[tipo];
                Apodo = apodos[tipo];
                break;
            default:
                break;
        }

        FechaNacimiento = RandomDay();

        Edad = calcularEdad(FechaNacimiento);

        Salud = 1000;
    }

    public datos(){}
}

public class caracteristicas{
    public int Velocidad {get;set;}
    public int Destreza {get;set;}
    public int Fuerza {get;set;}
    public int Nivel {get;set;}
    public int Armadura {get;set;}

    public caracteristicas(){
        Random random = new Random();

        Velocidad = random.Next(1,10);
        Destreza = random.Next(1,5);
        Fuerza = random.Next(1,10);
        Armadura = random.Next(1,10);
        Nivel = random.Next(1,10);
    }

}

