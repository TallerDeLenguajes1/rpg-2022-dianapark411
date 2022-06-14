// See https://aka.ms/new-console-template for more information
List<personaje> PersonajesEnJuego = new List<personaje>();

//QUIERO QUE SE CARGUEN EN LA LISTA TODOS LOS PERSONAJES
int cantPersonajes = 6;

for (int i = 0; i < cantPersonajes; i++){

    datos datos = new datos(i+1);
    caracteristicas caracteristicas = new caracteristicas();
    personaje player = new personaje(datos, caracteristicas);
    PersonajesEnJuego.Insert(i, player);
}

Console.WriteLine("\n------PERSONAJES DISPONIBLES------");
for (int i = 0; i < cantPersonajes; i++){
    mostrarUnPersonaje(PersonajesEnJuego[i], i);
}

Console.WriteLine("\n---PRIMER ENFRENTAMIENTO---");
Console.WriteLine("\nElija un atacante, ej 1: ");
int atacante = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("\nElija un defensor, ej 3: ");
int defensor = Convert.ToInt32(Console.ReadLine());

combate combat  = new combate(PersonajesEnJuego[atacante], PersonajesEnJuego[defensor]);


void mostrarUnPersonaje(personaje _personaje, int i){
    Console.WriteLine($"\n----INFORMACION DEL PERSONAJE [{i}]----");
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