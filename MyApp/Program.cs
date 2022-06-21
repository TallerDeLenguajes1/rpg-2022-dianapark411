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

int[] personajesElegidos = new int[cantPersonajes/2];

//Como las peleas son entre dos personajes, para que peleen todos, hay que hacer cantPersonajes/2 veces lo mismo
for (int i = 0; i < cantPersonajes/2; i++)
{
    Random random = new Random();
    int p1 = random.Next(1,cantPersonajes);
    while(personajesElegidos.Contains(p1)){
        p1 = random.Next(1,cantPersonajes);
    }
    
    int p2 = random.Next(1,cantPersonajes);
    while(personajesElegidos.Contains(p2) || p2==p1){
        p2 = random.Next(1,cantPersonajes);
    }

    Combate pelea  = new Combate();
    Console.WriteLine($"\nENFRENTAMIENTO ENTRE {PersonajesEnJuego[p1].dat.Apodo} Y {PersonajesEnJuego[p2].dat.Apodo}");
    //Devuelvo unicamente el indice del perdedor  en la lista asi lo elimino
    int perdedor = pelea.combate(PersonajesEnJuego[p1], PersonajesEnJuego[p2], p1,p2);

    //Quiero el indice del ganador para que no vuelva a pelear por el momento
    int ganador = p1;
    if(ganador == perdedor){
        ganador = p2;
    }
    personajesElegidos.Append(ganador);

    Console.WriteLine("\nPersonaje ganador: ");
    PersonajesEnJuego[ganador].mostrarUnPersonaje(PersonajesEnJuego[ganador]);

    Console.WriteLine("\nPersonaje perdedor ¡SERA ELIMINADO!");
    PersonajesEnJuego[perdedor].mostrarUnPersonaje(PersonajesEnJuego[perdedor]);

    //Elimino el personaje perdedor de la lista 
    PersonajesEnJuego.RemoveAt(perdedor);
    cantPersonajes --;
}