using static System.Console;

WriteLine("Vamos a jugar al piedra papel o tijera");
int maquina = ObtenerJugadaAleatoria();
int jugador =  PreguntarJugada();
DeterminarGanador(maquina: maquina, jugador: jugador);

//Fin del main


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

const int Piedra = 1;
const int Tijera = 2;
const int Papel = 3;

const int Jugador = 1;
const int Empate =  0;
const int Maquina = -1;


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
                isCorrecto = true;
                break;
            case "papel":
                res = Papel;
                isCorrecto = true;
                break;
            case "tijera":
                res = Tijera;
                isCorrecto = true;
                break;
            default:
                isCorrecto = false;
                break;
        }
        
    } while (!isCorrecto);
    return res;
}

void DeterminarGanador(int maquina, int jugador) {
    string maquinaTexto;
    switch (maquina) {
        case 1:
            maquinaTexto = "Piedra";
            break;
        case 2:
            maquinaTexto = "Tijera";
            break;
        case 3:
            maquinaTexto = "Papel";
            break;
        default:
            maquinaTexto = "No valido";
            break;
    }
    
    if (jugador == maquina) {
        WriteLine("Has quedado empate con la maquina");
    } else if ((jugador == Piedra && maquina == Tijera) || (jugador == Tijera && maquina == Papel) || (jugador == Papel && maquina == Piedra)) {
        WriteLine($"Has ganado, la jugada de la maquina era: {maquinaTexto}");
    }
    else {
        WriteLine($"Has perdido, la jugada de la maquina era:  {maquinaTexto}");
    }
}