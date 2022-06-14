public class combate{
    public int PD {get; set;}   //poder de disparo
    public int ED {get; set;}   //efectividad de disparo ES UN PORCENTAJE
    public int VA {get; set;}   //valor de ataque
    public int PDEF {get; set;}   //poder de defensa
    public int MDP {get; set;}   //maximo daño provocable
    public int DP {get; set;}   //daño provocado


    public combate(personaje atacante, personaje defensor){
        //ATAQUE
        PD = atacante.carac.Destreza * atacante.carac.Fuerza * atacante.carac.Nivel;
        
        Random random = new Random();
        ED = random.Next(1,100);

        VA = (PD * ED)/100; //Dividido en 100 porque ED es un porcentaje
        
        //DEFENSA
        PDEF = defensor.carac.Armadura * defensor.carac.Velocidad;

        //RESULTADO
        MDP = 500;  //la mitad de la salud
    }
}