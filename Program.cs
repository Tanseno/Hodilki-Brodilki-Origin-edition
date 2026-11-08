
using System;
using System.Linq;
using System.Collections.Generic;

namespace HelloWorld;

public static class Program
{
    public static void Main()
    {
        bool game_working = true; 
        bool working_bot = false; // бот

        int balance = 0;

        bool error_map = false;

        Random random = new Random();



        int a = 0; // для сканера (for scanner)
        int b = 0; //
        int c = 0; //



        int XD = 0; // позиция двери x y (x position door and y position door)
        int YD = 0;
        string door = "";

        int XB = 0; //позиция кнопки y x (x position button and y position button)
        int YB = 0;

        int X_bot = 6; // позиция бота y x (x position bot and y position button)
        int Y_bot = 6;

        int X_portal1 = 0; // позиция портала 1
        int Y_portal1 = 0;

        int X_portal2 = 0; // позиция портала 2
        int Y_portal2 = 0;

        int X_box = 0;
        int Y_box = 0;

        int x = 7; // позиция x для человечка (Y Position of the man)
        int y = 7; // позиция y для человечка (Y Position of the man)



        string man = "@";

// памятка ()
// ■ - барьер (border)
// . - пустая клетка(empty) 
// $ - монета (coin)    (gem) 💎
// @ - человек (man) 🕺
// B - кнопка (button)
// - или | - дверь (do)
// λ или G - Гордон Фримен (Gorgon Freeman)
// 1 - бот (bot)
// 0 - портал (portal)


        string[,] place ={                          // карта (map)
            {"■", "■", "■", "■", "■", "■", "■", "■", "■", "■", "■", "■", "■", "■", "■"}, 
            {"■", ".", ".", ".", ".", "■", ".", ".", ".", ".", "$", "$", "$", "$", "■"},
            {"■", ".", "0", ".", ".", "■", ".", "0", ".", ".", "$", "$", "$", "$", "■"},
            {"■", ".", ".", ".", ".", "■", ".", ".", ".", ".", "$", "$", "$", "$", "■"},
            {"■", ".", ".", ".", ".", "■", ".", ".", ".", ".", "$", "$", "$", "$", "■"},
            {"■", "■", "B", "■", "-", "■", "■", "■", "■", "■", "■", "■", "■", "■", "■"},
            {"■", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "■"},
            {"■", ".", ".", ".", ".", ".", ".", man, ".", ".", ".", ".", ".", ".", "■"},
            {"■", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "■"},
            {"■", ".", ".", "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "■"},
            {"■", "■", "■", ".", "■", "■", ".", ".", ".", ".", ".", ".", ".", ".", "■"},
            {"■", "$", "$", "$", "$", "■", ".", ".", ".", ".", ".", ".", ".", ".", "■"},
            {"■", "$", "$", "$", "$", "■", ".", ".", ".", ".", ".", ".", ".", ".", "■"},
            {"■", "$", "$", "$", "$", "■", ".", ".", ".", ".", ".", ".", ".", ".", "■"},
            {"■", "■", "■", "■", "■", "■", "■", "■", "■", "■", "■", "■", "■", "■", "■"},  
            };
            
        



        foreach(string el in place)
        {
                b++;            //не трогать!!!!
                if(b == 14)
                {
                    b = 0;
                    a++;  
                }
                if (a == 15)
                {
                    a = 14;
                }               //не трогать!!!!


                if(place[a, b] == "-" || place[a, b] == "|")
                {
                    YD = a;
                    XD = b;
                    door = place[a, b];
                }
                if(place[a, b] == "B")
                {
                    YB = a;
                    XB = b;
                }
                if(place[a, b] == "0" && balance == 0)
                {
                    Y_portal1 = a;
                    X_portal1 = b;
                    balance = 1;
                }
                if(place[a, b] == "0" && balance == 1)
                {
                    Y_portal2 = a;
                    X_portal2 = b;
                }
                if(place[a, b] == "#")
                {
                    Y_box = a;
                    X_box = b;
                }
                
            }
        balance = 0;


        if(Y_portal1 == 1 || Y_portal1 == 13 || X_portal2 == 1 || X_portal2 == 13) // проверка порталов
            {
                error_map = true;
            }
        if(error_map == true)
        {
            game_working = false;
            System.Console.WriteLine("ошибка размещения объектов");
        }
        else
        {
            Console.WriteLine("добро пожаловать в  С# ходилку-бродилку Beta, напишите help чтобы узнать как пользоваться программой");
            gam(place, balance);
        }

    
        while (game_working)
        {



            String? word = Console.ReadLine();
            word = word.ToLower();
            word = word.Trim();

/*

    1. Check the length of word
    2. If length > 1 => checks for commands (switch)
    3. If lenght = 1 => checks for moves (switch)
    4. render in the end of switch for moves


    if(word.lenght > 1){
        switch(word){
            case: ""
                // do something
                break;
            default: ""
                // do something                
        }
    } else if(word.length = 1){
        switch(word){
            case: ""
                // do something
                break;
            default: ""
                // do something                
        }
            place[y, x] = ".";
            place[y, x] = man;            
            gam(place, balance);      
    }

*/
            if (word.Length == 1){
                place[y, x] = ".";

                switch(word){
                    


                    case "d": 
                        if(place[y, x + 1] != "■" && place[y, x + 1] != "B" && place[y, x + 1] != "-" && place[y, x + 1] != "|" && place[y, x + 1] != "1")
                        {
                            if(place[y, x + 1] == "$")
                            {
                                balance++;
                                x = x + 1;
                            }
                            else if(place[y, x + 1] == ".")
                            {
                                x = x + 1;
                            }
                            else if(place[y, x + 1] == "0")
                            {
                                if(y == Y_portal1 && x + 1 == X_portal1)
                                {
                                    y = Y_portal2;
                                    x = X_portal2 + 1;
                                }
                                else
                                {
                                    y = Y_portal1;
                                    x = X_portal1 + 1;
                                }
                            }
                            else if(place[y, x + 1] == "#")
                            {
                            if(place[Y_box, X_box + 1] == ".")
                                {
                                    x = x + 1;
                                    place[Y_box, X_box] = ".";
                                    X_box = X_box + 1;
                                    place[Y_box, X_box] = "#";
                                }
                            }
                        }
                        break;



                    case "a": 
                        if(place[y, x - 1] != "■" && place[y, x - 1] != "B" && place[y, x - 1] != "-" && place[y, x - 1] != "|" && place[y, x - 1] != "1")
                        {
                            if(place[y, x - 1] == "$")
                            {
                                balance++;
                                x = x - 1;
                            }
                            else if(place[y, x - 1] == ".")
                            {
                                x = x - 1;
                            }
                            else if(place[y, x - 1] == "0")
                            {
                                if(y == Y_portal1 && x - 1 == X_portal1)
                                {
                                    y = Y_portal2;
                                    x = X_portal2 - 1;
                                }
                                else
                                {
                                    y = Y_portal1;
                                    x = X_portal1 - 1;
                                }
                            }
                            else if(place[y, x - 1] == "#")
                            {
                            if(place[Y_box, X_box - 1] == ".")
                                {
                                    x = x - 1;
                                    place[Y_box, X_box] = ".";
                                    X_box = X_box - 1;
                                    place[Y_box, X_box] = "#";
                                }
                            }
                                      
                        }
                        break;



                    case "w": 
                        if(place[y - 1, x] != "■" && place[y - 1, x] != "B" && place[y - 1, x] != "-" && place[y - 1, x] != "|" && place[y - 1, x] != "1")
                        {
                            if(place[y - 1, x] == "$") // получение монет
                            {
                                balance++;
                                y = y - 1;
                            }
                            else if(place[y - 1, x] == ".") // передвижение
                            {
                                y = y - 1;
                            }
                            else if(place[y - 1, x] == "0") // порталы
                            {
                                if(y - 1 == Y_portal1 && x == X_portal1)
                                {
                                    y = Y_portal2 - 1;
                                    x = X_portal2;
                                }
                                else
                                {
                                    y = Y_portal1 - 1;
                                    x = X_portal1;
                                }
                            }
                            else if(place[y - 1, x] == "#") // коробка
                            {
                                if(place[Y_box - 1, X_box] == ".")
                                {
                                    y = y - 1;
                                    place[Y_box, X_box] = ".";
                                    Y_box = Y_box - 1;
                                    place[Y_box, X_box] = "#";
                                }                                
                            }
                                                   
                        }
                        break;



                    case "s": 
                        if(place[y + 1, x] != "■" && place[y + 1, x] != "B" && place[y + 1, x] != "-" && place[y + 1, x] != "|" && place[y + 1, x] != "1")
                        {
                            if(place[y + 1, x] == "$")
                            {
                                balance++;
                                y = y + 1;
                            }
                            else if(place[y + 1, x] == ".")
                            {
                                y = y + 1;
                            }
                            else if(place[y + 1, x] == "0")
                            {
                                if(y + 1 == Y_portal1 && x == X_portal1)
                                {
                                    y = Y_portal2 + 1;
                                    x = X_portal2;
                                }
                                else
                                {
                                    y = Y_portal1 + 1;
                                    x = X_portal1;
                                }
                            }
                            else if(place[y + 1, x] == "#")
                            {
                            if(place[Y_box + 1, X_box] == ".")
                                {
                                    y = y + 1;
                                    place[Y_box, X_box] = ".";
                                    Y_box = Y_box + 1;
                                    place[Y_box, X_box] = "#";
                                }
                            }
                        }
                        break;


                    case "e": 
                        if((x == XB && y == YB - 1) || (x == XB + 1 && y == YB) || (x == XB && y == YB + 1) || (x == XB - 1 && y == YB) && (x != XD || y != YD)){
                            if(place[YD, XD] != "."){
                                place[YD, XD] = ".";
                            }
                            else
                            {
                                place[YD, XD] = door;
                            }
                        }
                        break;



                    default: 
                        System.Console.WriteLine();
                        break;
                }

               
                place[y, x] = man;              
                gam(place, balance); 

            }

            else if (word.Length == 0){
                gam(place, balance);
            }

            else{
                switch(word){



                    case "stop":
                        Console.WriteLine("ваш счëт: {0}", balance); 
                        game_working = false;
                        break;



                    case "help": 
                        help_user();
                        break;



                    case "position":
                        Console.WriteLine("\nкоординаты (y x):" + y + " " + x + "\n");
                        gam(place, balance);
                        System.Console.WriteLine("{0} {1} {2} {3}", Y_portal1, X_portal1, Y_portal2, X_portal2);
                        break;



                    case "half life2":
                        man = "G";
                        easter_egg();
                        break;



                    case "!bot":
                    if(working_bot == false){
                        working_bot = true;
                        gam(place, balance);
                        System.Console.WriteLine("бот включён");
                    }
                    else{
                        place[Y_bot, X_bot] = ".";
                        working_bot = false;
                        System.Console.WriteLine("бот выключен");
                    }
                        break;



                    default:
                        System.Console.WriteLine("error\n");
                        break;
                }
            }
            if(working_bot == true){
                place[Y_bot, X_bot] = "1";
                c = random.Next(1, 5);
                place[Y_bot, X_bot] = ".";
                switch(c){
                    case 1:
                        if(place[Y_bot - 1, X_bot] != "■" && place[Y_bot - 1, X_bot] != "B" && place[Y_bot - 1, X_bot] != "-" && place[Y_bot - 1, X_bot] != "|" && place[Y_bot - 1, X_bot] != "@" && place[Y_bot - 1, X_bot] != "0" && place[Y_bot - 1, X_bot] != "#")
                        {
                            Y_bot = Y_bot - 1;
                        }
                    break;



                    case 2:
                        if(place[Y_bot + 1, X_bot] != "■" && place[Y_bot + 1, X_bot] != "B" && place[Y_bot + 1, X_bot] != "-" && place[Y_bot + 1, X_bot] != "|" && place[Y_bot + 1, X_bot] != "@" && place[Y_bot + 1, X_bot] != "0" && place[Y_bot + 1, X_bot] != "#")
                        {
                            Y_bot = Y_bot + 1;
                        }
                    break;



                    case 3:
                        if(place[Y_bot, X_bot - 1] != "■" && place[Y_bot, X_bot - 1] != "B" && place[Y_bot, X_bot - 1] != "-" && place[Y_bot, X_bot - 1] != "|" && place[Y_bot, X_bot - 1] != "@" && place[Y_bot, X_bot - 1] != "0" && place[Y_bot, X_bot - 1] != "#")
                        {
                            X_bot = X_bot - 1;          
                        }
                    break;



                    case 4:
                        if(place[Y_bot, X_bot + 1] != "■" && place[Y_bot, X_bot + 1] != "B" && place[Y_bot, X_bot + 1] != "-" && place[Y_bot, X_bot + 1] != "|" && place[Y_bot, X_bot + 1] != "@" && place[Y_bot, X_bot + 1] != "0" && place[Y_bot, X_bot + 1] != "#")
                        {
                            X_bot = X_bot + 1;
                        }
                    break;
                }
                place[Y_bot, X_bot] = "1";
            }
        }
    }

    public static void gam(string[,] pla, int Game_score) // функция отображение карты (map display function) и функция отображения счёта (score display function)
    {
        Console.WriteLine("\n{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}", pla[0, 0], pla[0, 1], pla[0, 2], pla[0, 3], pla[0, 4], pla[0, 5], pla[0, 6], pla[0, 7], pla[0, 8], pla[0, 9], pla[0, 10], pla[0, 11], pla[0, 12], pla[0, 13], pla[0, 14]);
        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}", pla[1, 0], pla[1, 1], pla[1, 2], pla[1, 3], pla[1, 4], pla[1, 5], pla[1, 6], pla[1, 7], pla[1, 8], pla[1, 9], pla[1, 10], pla[1, 11], pla[1, 12], pla[1, 13], pla[1, 14]);
        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}", pla[2, 0], pla[2, 1], pla[2, 2], pla[2, 3], pla[2, 4], pla[2, 5], pla[2, 6], pla[2, 7], pla[2, 8], pla[2, 9], pla[2, 10], pla[2, 11], pla[2, 12], pla[2, 13], pla[2, 14]);
        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}", pla[3, 0], pla[3, 1], pla[3, 2], pla[3, 3], pla[3, 4], pla[3, 5], pla[3, 6], pla[3, 7], pla[3, 8], pla[3, 9], pla[3, 10], pla[3, 11], pla[3, 12], pla[3, 13], pla[3, 14]);
        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}", pla[4, 0], pla[4, 1], pla[4, 2], pla[4, 3], pla[4, 4], pla[4, 5], pla[4, 6], pla[4, 7], pla[4, 8], pla[4, 9], pla[4, 10], pla[4, 11], pla[4, 12], pla[4, 13], pla[4, 14]);
        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}", pla[5, 0], pla[5, 1], pla[5, 2], pla[5, 3], pla[5, 4], pla[5, 5], pla[5, 6], pla[5, 7], pla[5, 8], pla[5, 9], pla[5, 10], pla[5, 11], pla[5, 12], pla[5, 13], pla[5, 14]);
        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}", pla[6, 0], pla[6, 1], pla[6, 2], pla[6, 3], pla[6, 4], pla[6, 5], pla[6, 6], pla[6, 7], pla[6, 8], pla[6, 9], pla[6, 10], pla[6, 11], pla[6, 12], pla[6, 13], pla[6, 14]);
        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}", pla[7, 0], pla[7, 1], pla[7, 2], pla[7, 3], pla[7, 4], pla[7, 5], pla[7, 6], pla[7, 7], pla[7, 8], pla[7, 9], pla[7, 10], pla[7, 11], pla[7, 12], pla[7, 13], pla[7, 14]);
        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}", pla[8, 0], pla[8, 1], pla[8, 2], pla[8, 3], pla[8, 4], pla[8, 5], pla[8, 6], pla[8, 7], pla[8, 8], pla[8, 9], pla[8, 10], pla[8, 11], pla[8, 12], pla[8, 13], pla[8, 14]);
        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}", pla[9, 0], pla[9, 1], pla[9, 2], pla[9, 3], pla[9, 4], pla[9, 5], pla[9, 6], pla[9, 7], pla[9, 8], pla[9, 9], pla[9, 10], pla[9, 11], pla[9, 12], pla[9, 13], pla[9, 14]);
        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}", pla[10, 0], pla[10, 1], pla[10, 2], pla[10, 3], pla[10, 4], pla[10, 5], pla[10, 6], pla[10, 7], pla[10, 8], pla[10, 9], pla[10, 10], pla[10, 11], pla[10, 12], pla[10, 13], pla[10, 14]);
        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}", pla[11, 0], pla[11, 1], pla[11, 2], pla[11, 3], pla[11, 4], pla[11, 5], pla[11, 6], pla[11, 7], pla[11, 8], pla[11, 9], pla[11, 10], pla[11, 11], pla[11, 12], pla[11, 13], pla[11, 14]);
        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}", pla[12, 0], pla[12, 1], pla[12, 2], pla[12, 3], pla[12, 4], pla[12, 5], pla[12, 6], pla[12, 7], pla[12, 8], pla[12, 9], pla[12, 10], pla[12, 11], pla[12, 12], pla[12, 13], pla[12, 14]);
        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}", pla[13, 0], pla[13, 1], pla[13, 2], pla[13, 3], pla[13, 4], pla[13, 5], pla[13, 6], pla[13, 7], pla[13, 8], pla[13, 9], pla[13, 10], pla[13, 11], pla[13, 12], pla[13, 13], pla[13, 14]);
        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}", pla[14, 0], pla[14, 1], pla[14, 2], pla[14, 3], pla[14, 4], pla[14, 5], pla[14, 6], pla[14, 7], pla[14, 8], pla[14, 9], pla[14, 10], pla[14, 11], pla[14, 12], pla[14, 13], pla[14, 14]);
        Console.WriteLine("счëт: {0}\n", Game_score);
    }

    public static void easter_egg(){
        System.Console.WriteLine("\n-Проснитесь и пойте мистер Фримен, проснитесь и пойте....\n-Нет я не хочу сказать что вы спите на работе.");
        System.Console.WriteLine("-Никто не заслуживает отдыха больше вашего и все усилия мира пропали бы даром пока м... скажем просто что ваш час снова пробил.");
        System.Console.WriteLine("-Нужный человек не в том месте может перевернуть мир.\n-Так проснитесь же мистер Фримен, вас снова ждут великие дела.\n");
    }

    public static void help_user(){
        Console.WriteLine("введите stop, чтобы остановить программу.\n");
        Console.WriteLine("введите букву w, s, a, или d чтобы двигаться.\n");
        Console.WriteLine("собирайте $ чтобы получить +1 балл к счëту.\n");
        Console.WriteLine("также тут есть двери ( | или - ), их можно открыть с помощью кнопки( B ) \n");
        System.Console.WriteLine("чтобы открыть дверь подойдите к кнопке ( B ) и введите e (английскую)\n");
    }
}