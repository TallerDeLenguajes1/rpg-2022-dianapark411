// See https://aka.ms/new-console-template for more information

personaje personaje = new personaje();
personaje.datos datos = cargarDatos();
personaje.caracteristicas caracteristicas = cargarCaracteristicas();

mostrarDatos(datos);
mostrarCaracteristicas(caracteristicas);

personaje.datos cargarDatos(){

    personaje.datos datos = new personaje.datos();

    Console.WriteLine("\nINGRESE SU NOMBRE: ");
    datos.Nombre = Console.ReadLine();

    Console.WriteLine("\nINGRESE SU APODO: ");
    datos.Apodo = Console.ReadLine();

    
    Random random = new Random();
    int tipo = random.Next(1,5);

    switch (tipo){
        case 1:
            datos.tipo = Tipo.Hada;
            break;
        case 2:
            datos.tipo = Tipo.Duende;
            break;
        case 3:
            datos.tipo = Tipo.Dragon;
            break;
        case 4:
            datos.tipo = Tipo.Caballero;
            break;
        case 5:
            datos.tipo = Tipo.Brujo;
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