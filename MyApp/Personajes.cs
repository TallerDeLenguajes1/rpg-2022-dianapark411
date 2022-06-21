public class personaje{
    public datos dat;
    public caracteristicas carac;

    public personaje(datos _dat, caracteristicas _carac){
        dat = _dat; 
        carac = _carac;
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

public enum Tipo{ 
    Brujo, 
    Hechicera, 
    Princesa, 
    Elfo,
    Dragon,
    Demonio,
    Rey,

}
public enum Nombre{
    GeraltDeRivia,
    YenneferDeVenderberg,
    CirillaDeCintra,
    FilavandrelAénFidháil,
    Villentretenmerth, 
    VolethMeir,
    Foltest,
    Vesemir,
}
public enum Apodo{
    Geralt,
    Yennefer,
    Ciri,
    Filavandrel,
    Borch, 
    BabaYaga, 
    Foltest,
    Vesemir,
}

public class datos{
    public Tipo Tipo;
    public Nombre Nombre;
    public Apodo Apodo;
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

    public datos(int tipo){
        // Random random = new Random();
        //int tipo = random.Next(1,5);
        
        switch (tipo){
            case 1:
                Tipo = Tipo.Brujo;
                Nombre = Nombre.GeraltDeRivia;
                Apodo = Apodo.Geralt;
                break;
            case 2:
                Tipo = Tipo.Hechicera;
                Nombre = Nombre.YenneferDeVenderberg;
                Apodo = Apodo.Yennefer;
                break;
            case 3:
                Tipo = Tipo.Princesa;
                Nombre = Nombre.CirillaDeCintra;
                Apodo = Apodo.Ciri;
                break;
            case 4:
                Tipo = Tipo.Elfo;
                Nombre = Nombre.FilavandrelAénFidháil;
                Apodo = Apodo.Filavandrel;
                break;
            case 5:
                Tipo = Tipo.Dragon;
                Nombre = Nombre.Villentretenmerth;
                Apodo = Apodo.Borch;
                break;
            case 6:
                Tipo = Tipo.Demonio;
                Nombre = Nombre.VolethMeir;
                Apodo = Apodo.BabaYaga;
                break;
            case 7:
                Tipo = Tipo.Rey;
                Nombre = Nombre.Foltest;
                Apodo = Apodo.Foltest;
                break;
            case 8:
                Tipo = Tipo.Brujo;
                Nombre = Nombre.Vesemir;
                Apodo = Apodo.Vesemir;
                break;
            default:
                break;
        }

        FechaNacimiento = RandomDay();

        Edad = calcularEdad(FechaNacimiento);

        Salud = 1000;
    }
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
