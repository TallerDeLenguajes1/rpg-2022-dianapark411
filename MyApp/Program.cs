// See https://aka.ms/new-console-template for more information
List<personaje> PersonajesEnJuego = new List<personaje>();

//QUIERO QUE SE CARGUEN EN LA LISTA TODOS LOS PERSONAJES
//LA CANTIDAD DE PERSONAJES DEBE CORRESPONDER A POTENCIA DE 2, PARA QUE SE ARME UNA ESPECIE DE FIGSTURE DE LA PELEA
//SI SE AUMENTAN PERSONAJES SE DEBE MODIFICAR LA CLASE DATOS, PORQUE CADA TIPO TIENE UN NOMBRE PREDETERMINADO
int cantPersonajes = 8;

Console.WriteLine("\n------PERSONAJES DISPONIBLES------");
for (int i = 0; i < cantPersonajes; i++){

    datos datos = new datos(i+1);
    caracteristicas caracteristicas = new caracteristicas();
    personaje player = new personaje(datos, caracteristicas);
    PersonajesEnJuego.Insert(i, player);

    Console.WriteLine($"\n----INFORMACION DEL PERSONAJE [{i}]----");
    player.mostrarUnPersonaje(PersonajesEnJuego[i]);
    
}

List<personaje> personajesGanadores = new List<personaje>();
string[] personajesQueSeEnfrentan;
List<string> parejas = new List<string>();

//nueva variable, por las dudas para no modificar la original
int cantPersj = cantPersonajes;

int p1, p2, ganador, perdedor;
int ronda = 1;
Combate pelea;

//creo el archivo csv para agregarle desp los ganadores
string ruta = @"C:\DIANA\Facultad\3er ANIO\1er Cuatrimestre\Taller de Lenguajes I\RPG\rpg-2022-dianapark411";
crearCSV(ruta);

//Hasta 2 personajes para hacer la final por separado
while (cantPersj>2){   

    //Con esta funcion se eligen aleatoriamente las parejas para que peleen
    parejas = emparejamiento(cantPersj);
    
    //Como las peleas son entre dos personajes, para que peleen todos, hay que hacer cantPersonajes/2 veces lo mismo
    for (int k= 0; k < cantPersj/2; k++)
    {
        personajesQueSeEnfrentan = parejas[k].Split("-");
        p1 = Convert.ToInt32(personajesQueSeEnfrentan[0]);
        p2 = Convert.ToInt32(personajesQueSeEnfrentan[1]);

        (ganador,perdedor) = enfrentamiento(p1,p2);

        Console.WriteLine("\n---GANADOR DE LA BATALLA---");
        PersonajesEnJuego[ganador].mostrarUnPersonaje(PersonajesEnJuego[ganador]);

        Console.WriteLine("\n---PERDEDOR DE LA BATALLA---");
        Console.WriteLine("\n---no podra volver a jugar---");
        PersonajesEnJuego[perdedor].mostrarUnPersonaje(PersonajesEnJuego[perdedor]);

    }
    //Elimino todos los personajes de la lista y agrego solamente los ganadores
    //Hago esto al final para evitar problemas con los indices
    PersonajesEnJuego.Clear();
    for (int j = 0; j < cantPersj/2; j++)
    {
        PersonajesEnJuego.Add(personajesGanadores[j]);
    }  

    escribirGanadoresCSV(ruta, personajesGanadores, ronda);

    personajesGanadores.Clear();
    cantPersj = cantPersj/2;
    ronda = ronda+1;
    Console.WriteLine("\n¡¡¡¡¡SIGUIENTE RONDA!!!!!");

}

Console.WriteLine("\n¡¡¡¡¡LA GRAN FINAL!!!!!");
parejas = emparejamiento(cantPersj);

//indice 0 porque solo quedan 2 personajes asi que sera un elemento de la lista
personajesQueSeEnfrentan = parejas[0].Split("-");
p1 = Convert.ToInt32(personajesQueSeEnfrentan[0]);
p2 = Convert.ToInt32(personajesQueSeEnfrentan[1]);

(ganador,perdedor) = enfrentamiento(p1,p2);

escribirGanadoresCSV(ruta,personajesGanadores, ronda);
personajesGanadores.Clear();

Console.WriteLine("\n---¡¡¡¡¡GANADOR DEL TRONO!!!!!---");
PersonajesEnJuego[ganador].mostrarUnPersonaje(PersonajesEnJuego[ganador]);

Console.WriteLine("\n---Desea recordar los ganadores en cada ronda?---");
Console.WriteLine("\n---Ingrese 1 para si 0 para no---");
int opcion = Convert.ToInt32(Console.ReadLine());
if(opcion == 1){
    leerGanadoresCSV(ruta);
}



//OTRAS FUNCIONES

List<string> emparejamiento(int cantPersj){
    List<string> parejas = new List<string>();
    List<int> yaElegidos = new List<int>();

    for (int i = 0; i < cantPersj/2; i++)
    {
        Random random = new Random();
        int p1 = random.Next(0,cantPersj);
        
        while(yaElegidos.Contains(p1)){
            p1 = random.Next(0,cantPersj);
        }
        //Console.WriteLine($"p1: {p1}");
        yaElegidos.Add(p1);

        int p2 = random.Next(0,cantPersj);
        while(yaElegidos.Contains(p2)){
            p2 = random.Next(0,cantPersj);
        }
        //Console.WriteLine($"p2: {p2}");
        yaElegidos.Add(p2);

        parejas.Add(p1+"-"+p2);
    }

    yaElegidos.Clear();

    return parejas;
}


(int, int) enfrentamiento(int p1, int p2){

    pelea  = new Combate();
    Console.WriteLine($"\nENFRENTAMIENTO ENTRE {PersonajesEnJuego[p1].dat.Apodo} Y {PersonajesEnJuego[p2].dat.Apodo}");
    
    //xq el perdedor? no hay xq
    perdedor = pelea.combate(PersonajesEnJuego[p1], PersonajesEnJuego[p2], p1,p2);

    //Quiero el indice del ganador para agregarlo a la lista de ganadores y que no vuelva a pelear por el momento
    ganador = p1;
    if(ganador == perdedor){
        ganador = p2;
    }
    personajesGanadores.Add(PersonajesEnJuego[ganador]);

    return (ganador, perdedor);
}


void crearCSV(string ruta){
    
    if(Directory.Exists(ruta)){
        FileStream fileStream;

        if(!File.Exists(ruta + @"\ganadores.csv")){
            Console.WriteLine("Creando archivo ganadores.csv");
            fileStream = File.Create(ruta + @"\ganadores.csv");
            fileStream.Close();
        }

        var archivo = new FileStream(ruta + @"\ganadores.csv", FileMode.Truncate);
        string cadena = "RONDA;APODO DEL GANADOR;SALUD\n";

        StreamWriter escribir = new StreamWriter(archivo);
        escribir.Write(cadena);
        escribir.Close();
        archivo.Close();
        
    }
    else{
        Console.WriteLine("La ruta ingresada no existe");
    }
}

void escribirGanadoresCSV(string ruta, List<personaje> personajesGanadores, int ronda){
    if(File.Exists(ruta + @"\ganadores.csv")){
        StreamWriter file = new StreamWriter(ruta + @"\ganadores.csv", true);
        foreach (var ganador in personajesGanadores)
        {
            file.WriteLine($"{ronda};{ganador.dat.Apodo};{ganador.dat.Salud}");
        }

        file.Close();   
    }
}

void leerGanadoresCSV(string ruta){
    if(File.Exists(ruta + @"\ganadores.csv")){
        StreamReader file = new StreamReader(ruta + @"\ganadores.csv");
        string line = "";
        Console.WriteLine("GANADORES EN CADA ENFRENTAMIENTO");
        //Lee linea por linea hasta que termina el archivo
        while ((line = file.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
        file.Close();   
    }
}
