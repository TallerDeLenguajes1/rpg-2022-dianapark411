// See https://aka.ms/new-console-template for more information

personaje personaje = new personaje();
personaje.datos datos = cargarDatos();
personaje.caracteristicas caracteristicas = cargarCaracteristicas();

mostrarDatos(datos);
mostrarCaracteristicas(caracteristicas);

personaje.datos cargarDatos(){

    personaje.datos datos = new personaje.datos();
    
    Random random = new Random();
    int tipo = random.Next(1,5);

    switch (tipo){
        case 1:
            datos.tipo = Tipo.Brujo;
            datos.Nombre = Nombre.GeraltDeRivia;
            datos.Apodo = Apodo.Geralt;
            break;
        case 2:
            datos.tipo = Tipo.Hechicera;
            datos.Nombre = Nombre.YenneferDeVenderberg;
            datos.Apodo = Apodo.Yennefer;
            break;
        case 3:
            datos.tipo = Tipo.Princesa;
            datos.Nombre = Nombre.CirillaDeCintra;
            datos.Apodo = Apodo.Ciri;
            break;
        case 4:
            datos.tipo = Tipo.Elfo;
            datos.Nombre = Nombre.FilavandrelAénFidháil;
            datos.Apodo = Apodo.Filavandrel;
            break;
        case 5:
            datos.tipo = Tipo.Dragon;
            datos.Nombre = Nombre.Villentretenmerth;
            datos.Apodo = Apodo.Borch;
            break;
        default:
            break;
    }

    datos.FechaNacimiento = RandomDay();

    datos.Edad = personaje.calcularEdad(datos.FechaNacimiento);

    datos.Salud = 100;

    return datos;
}

DateTime RandomDay() {
    DateTime start = new DateTime(1722, 1, 1); 
    Random gen = new Random(); 
    int range = (DateTime.Today - start).Days; 
    return start.AddDays(gen.Next(range)); 
}

personaje.caracteristicas cargarCaracteristicas(){
    
    personaje.caracteristicas caracteristicas = new personaje.caracteristicas();

    Random random = new Random();

    caracteristicas.Velocidad = random.Next(1,10);
    caracteristicas.Destreza = random.Next(1,5);
    caracteristicas.Fuerza = random.Next(1,10);
    caracteristicas.Armadura = random.Next(1,10);
    caracteristicas.Nivel = random.Next(1,10);

    return caracteristicas;
}

void mostrarDatos(personaje.datos datos){
    Console.WriteLine("\n-------DATOS DEL PERSONAJE-------");
    Console.WriteLine($"Tipo: {datos.tipo}");
    Console.WriteLine($"Nombre: {datos.Nombre}");
    Console.WriteLine($"Apodo: {datos.Apodo}");
    Console.WriteLine($"Fecha de nacimiento: {datos.FechaNacimiento.ToShortDateString()}");
    Console.WriteLine($"Edad: {datos.Edad}");
    Console.WriteLine($"Salud: {datos.Salud}");
}

void mostrarCaracteristicas(personaje.caracteristicas caracteristicas){
    Console.WriteLine("\n-----CARACTERISTICAS DEL PERSONAJE-----");
    Console.WriteLine($"Velocidad: {caracteristicas.Velocidad}");
    Console.WriteLine($"Destreza: {caracteristicas.Destreza}");
    Console.WriteLine($"Fuerza: {caracteristicas.Fuerza}");
    Console.WriteLine($"Nivel: {caracteristicas.Nivel}");
    Console.WriteLine($"Armadura: {caracteristicas.Armadura}");
}