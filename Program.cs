// See https://aka.ms/new-console-template for more information
List<String> map = new List<string> {
    "1", "2", "3",
    "4", "5", "6",
    "7", "8", "9"
};

void Play() {
    while(true) {
        Console.WriteLine(ShowMap());
        string value = "";
        int position = 0;
        foreach(int turn in GenerateTurn(9)) {
            if(!(turn % 2 == 0)) {
                Console.WriteLine("Jugador 1 - X");
                Console.WriteLine("Escribe una posicion: ");
                position = Int32.Parse(Console.ReadLine())-1;
                value = "X";
            } else {
                Console.WriteLine("Jugador 2 - O");
                Console.WriteLine("Escribe una posicion: ");
                position = Int32.Parse(Console.ReadLine())-1;
                value = "O";
            }
            if (map[position] == "X" || map[position] == "O") {
                Console.WriteLine("La posicion ya esta ocupada");
                break;
            }
            UpdateMap(position, value);
            Console.WriteLine(ShowMap());
        }
        if(WhoWin()) {
            Console.WriteLine("Ya gano alguien");
            break;
        } else {
            Console.WriteLine("No gano nadie");
            break;
        }
    }
}

IEnumerable<int> GenerateTurn(int range) {
    for(int i = 1; i <= range; i++)
        yield return i;
}

string ShowMap() {
    string result = "";
    for (int i = 0; i < map.Count; i++) {
        if(i % 3 == 0) {
            result += "\n";
        }
        result += String.Concat(map[i], "|");
    }
    return result;
}

void UpdateMap(int position, string value) {
    map[position] = value;
}

bool WhoWin() {
    int index = 0;
    int countX = 0;
    int countO = 0;
    map.ForEach((item) => {
        switch(map[index]) {
            case "X":
                countX += 1;
                break;
            case "O":
                countO += 1;
                break;
        }
        index += 1;
    });
    if(map[0] == "X" && map[1] == "X" && map[2] == "X" && countX >= 3 || map[0] == "O" && map[1] == "O" && map[2] == "O" && countO >= 3) {
        return true;
    } 
    if(map[3] == "X" && map[4] == "X" && map[5] == "X" && countX >= 3 || map[3] == "O" && map[4] == "O" && map[5] == "O" && countO >= 3) {
        return true;
    } 
    if(map[6] == "X" && map[7] == "X" && map[8] == "X" && countX >= 3 || map[6] == "O" && map[7] == "O" && map[8] == "O" && countO >= 3) {
        return true;
    } 
    if(map[0] == "X" && map[3] == "X" && map[6] == "X" && countX >= 3 || map[0] == "O" && map[3] == "O" && map[6] == "O" && countO >= 3) {
        return true;
    } 
    if(map[1] == "X" && map[4] == "X" && map[7] == "X" && countX >= 3 || map[1] == "O" && map[4] == "O" && map[7] == "O" && countO >= 3) {
        return true;
    } 
    if(map[2] == "X" && map[5] == "X" && map[8] == "X" && countX >= 3 || map[2] == "O" && map[5] == "O" && map[8] == "O" && countO >= 3) {
        return true;
    }
    if(map[1] == "X" && map[4] == "X" && map[8] == "X" && countX >= 3 || map[1] == "O" && map[4] == "O" && map[8] == "O" && countO >= 3) {
        return true;
    }
    return false;
}

Play();