public class Combate{
    public Double PD {get; set;}   //poder de disparo
    public Double ED {get; set;}   //efectividad de disparo ES UN PORCENTAJE
    public Double VA {get; set;}   //valor de ataque
    public Double PDEF {get; set;}   //poder de defensa
    public Double MDP {get; set;}   //maximo daño provocable
    public Double DP {get; set;}   //daño provocado


    public int combate(personaje p1, personaje p2, int indiceP1, int indiceP2){
        
        for (int i = 0; i < 3; i++){
            //PRIMERO ATACA P1 Y DEFIENDE P2
            //ATAQUE
            //Console.WriteLine("\n-----PERSONAJE 1 ATACA ------");
            PD = p1.carac.Destreza * p1.carac.Fuerza * p1.carac.Nivel;
            //Console.WriteLine("\nPoder de disparo: {0}", PD);

            Random random = new Random();
            ED = random.Next(1,100);
            //Console.WriteLine("\nEfectividad de disparo: {0}", ED);

            VA = (PD * ED)/100; //Dividido en 100 porque ED es un porcentaje
            //Console.WriteLine("\nValor de ataque: {0}", VA);

            //DEFENSA
            PDEF = p2.carac.Armadura * p2.carac.Velocidad;
            //Console.WriteLine("\nPoder de defensa: {0}", PDEF);

            //RESULTADO
            MDP = 5000;  //la mitad de la salud

            DP = (((VA * ED)-PDEF)/MDP )*100;
            //Console.WriteLine("\nDanio provocado: {0}", DP);

            //Console.WriteLine("\nSalud del p2 antes del ataque: {0}", p2.dat.Salud);
            p2.dat.Salud = p2.dat.Salud - (int)DP;
            //Console.WriteLine("\nSalud del p2 luego del ataque: {0}", p2.dat.Salud);


            //DESPUES ATACA P2 Y DEFIENDE P1
            //ATAQUE
            //Console.WriteLine("\n-----PERSONAJE 2 ATACA ------");
            PD = p2.carac.Destreza * p2.carac.Fuerza * p2.carac.Nivel;
            //Console.WriteLine("\nPoder de disparo: {0}", PD);

            ED = random.Next(1,100);
            //Console.WriteLine("\nEfectividad de disparo: {0}", ED);

            VA = (PD * ED)/100; //Dividido en 100 porque ED es un porcentaje
            //Console.WriteLine("\nValor de ataque: {0}", VA);

            //DEFENSA
            PDEF = p1.carac.Armadura * p1.carac.Velocidad;
            //Console.WriteLine("\nPoder de defensa: {0}", PDEF);

            //RESULTADO
            MDP = 5000;  //la mitad de la salud

            DP = (((VA * ED)-PDEF)/MDP )*100;
            //Console.WriteLine("\nDanio provocado: {0}", DP);

            //Console.WriteLine("\nSalud del p1 antes del ataque: {0}", p1.dat.Salud);
            p1.dat.Salud = p1.dat.Salud - (int)DP;
            //Console.WriteLine("\nSalud del p1 luego del ataque: {0}", p1.dat.Salud);
        }

        //UNA VEZ QUE YA SE ATACARON MUTUAMENTE COMPARO LA SALUD PARA VER EL GANADOR
        if(p1.dat.Salud >= 0  &&  p2.dat.Salud >= 0){
            if(p1.dat.Salud > p2.dat.Salud){    //gana el primer personaje
                mejora(p1);
                return indiceP2; 
            }else{  //gana el segundo personaje
                mejora(p2);
                return indiceP1; 
            }
        }else{  //alguno o ambos tienen salud 0 o menor, pierde
            if(p1.dat.Salud == 0  &&  p2.dat.Salud == 0){   //hay un empate, se hace una batalla nuevamente
                return combate(p1,p2, indiceP1, indiceP2);
            }else{
                if(p1.dat.Salud <= 0){  //gana el segundo
                    mejora(p2);
                    return indiceP1; 
                }else{ //gana el primero
                    mejora(p1);
                    return indiceP2; 
                }
            }
        }
    }

    public void mejora(personaje ganador){
        //se mejoran algunas caracteristicas del ganador
        ganador.carac.Armadura = ganador.carac.Armadura + 1; 
        ganador.carac.Fuerza = ganador.carac.Fuerza + 1;
        ganador.carac.Velocidad = ganador.carac.Velocidad + 1;
    }
}