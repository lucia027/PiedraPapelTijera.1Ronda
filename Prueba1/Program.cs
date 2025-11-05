using static System.Console;

WriteLine("Vamos a jugar al piedra papel o tijera");
int maquina = ObtenerJugadaAleatoria();
int jugador =  PreguntarJugada();
DeterminarGanador(maquina: maquina, jugador: jugador);
//Fin del main


// Intento fallido de hacerlo con estructuras.
//    struct Jugadas {
//        public int Piedra = 1;
//        public int Tijera = 2;
//       public int Papel = 3;
//    }
//
//   struct Ganador {
//        public int Jugador = 1;
//        public int Empate =  0;
//        public int Maquina = -1;
//    }

//Constantes de las posibles jugadas.
const int Piedra = 1;
const int Tijera = 2;
const int Papel = 3;

//Constantes de los posibles resultados de la partida.
const int Jugador = 1;
const int Empate =  0;
const int Maquina = -1;

//Funcion que obtiene una jugada aleatoria por parte de la maquina
int ObtenerJugadaAleatoria() {
    var res = 0;
    bool isCorrecto = true;

    do {
        var random = new Random();
        switch (random.Next(1, 3)) {
            case 1:
                res = Piedra;
                break;
            case 2:
                res = Tijera;
                break;
            case 3:
                res = Papel;
                break;
            default:
                isCorrecto = false;
                break;
        }
    } while (!isCorrecto);

    return res;
}

//Funcion que pregunta ola jugada del usuario
int PreguntarJugada() {
    int res = 0;
    bool isCorrecto = true;
    
    do {
        WriteLine("Ingrese su jugada, Piedra/Papel/Tijera");
        string input = ReadLine()!.ToLower();
        if (input != "piedra" && input != "papel" && input != "tijera") {
            isCorrecto = false;
        }

        switch (input) {
            case "piedra": 
                res = Piedra; 
                break;
            case "papel":
                res = Papel;
                break;
            case "tijera":
                res = Tijera;
                break;
            default:
                isCorrecto = false;
                break;
        }
        
    } while (!isCorrecto);
    return res;
}

//Procedimiento que determina quien es el gandor o si hay un posible empate
void DeterminarGanador(int maquina, int jugador) {
    if (jugador == maquina) {
        WriteLine("Has quedado empate con la maquina");
    } else if ((jugador == Piedra && maquina == Tijera) || (jugador == Tijera && maquina == Papel) || (jugador == Papel && maquina == Piedra)) {
        WriteLine("Has ganado");
    }
    else {
        WriteLine("Has perdido");
    }
}
