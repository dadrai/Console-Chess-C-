using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Vibor_figuri(out int yi, out int yj, int kyi, int kyj, out string[,] array, string[,] array1, string[,] cvet, string chto, string kto_hod, int nomer_raund,string[,] vibor_yach)
        {
            array = array1;
            yi = kyi;
            yj = kyj;
            
            string kto;
            if (kto_hod == "r") { kto = "Krasnie"; }
            else kto = "Sinie";
            while (cvet[yi, yj] != kto_hod)
            {
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    Console.Clear();
                    vibor_yach[yi, yj] = null;
                    Vivod_Doska(array, cvet);
                    Console.WriteLine("Raund {0}  Hodyat {1}", nomer_raund, kto + "\n" + "Viberite " + chto);
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.LeftArrow:
                            {
                                if (yj - 1 >= 0) { yj--; }
                                else break;
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                if (yj + 1 < 8) { yj++; }
                                break;
                            }
                        case ConsoleKey.UpArrow:
                            {
                                if (yi - 1 >= 0) { yi--; }
                                else break;
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                if (yi + 1 < 8) { yi++; }
                                else break;
                                break;
                            }
                        default:
                            break;
                    }
                    Console.Clear();
                    vibor_yach[yi, yj] = "*";
                    Vivod_Doska_dlua_fibora(array, cvet,vibor_yach);
                    Console.WriteLine("i = {0}  j ={1}", yi, yj);
                    Console.WriteLine("Nazhmite ENTER chtobi vibrat");
                }
            }
            vibor_yach[yi, yj] = null;
        }
        static void Vibor_Hoda(out int yi, out int yj, int kyi, int kyj, out string[,] array, string[,] array1, string[,] cvet, string chto, string[,] vibor_yach)
        {
            array = array1;
            yi = kyi;
            yj = kyj;
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.Clear();
                vibor_yach[yi, yj] = null;
                Vivod_Doska(array, cvet);
                Console.WriteLine("Viberite " + chto);
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (yj - 1 >= 0) { yj--; }
                            else break;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (yj + 1 < 8) { yj++; }

                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (yi - 1 >= 0) { yi--; }
                            else break;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (yi + 1 < 8) { yi++; }
                            else break;
                            break;
                        }
                    default:
                        break;
                }
                vibor_yach[yi, yj] = "*";
                Vivod_Doska_dlua_fibora(array, cvet, vibor_yach);
                Console.WriteLine("i = {0}  j ={1}", yi, yj);
                Console.WriteLine("Nazhmite ENTER chtobi vibrat");
            }
            vibor_yach[yi, yj] = null;
        }
        static void Variant_Hoda(out int yi, out int yj, int vremenI, int vremenJ, out string figura, out string[,] array, string[,] array1, out string[,] cvet, string[,] cvet1, string[,] vibor_yach)
        {
            cvet = cvet1;
            yi = vremenI;
            yj = vremenJ;
            array = array1;
            figura = array[yi, yj];
            switch (array[yi, yj])
            {
                case "P":
                    {
                        Console.WriteLine("Kuda poidem?: ");
                        bool dvoinoi_hod = false;
                        if (yi == 1 || yi == 6)
                        {
                            dvoinoi_hod = true;
                        }
                        bool rubit = false;
                        if ((cvet[yi, yj] == "r" && ((yj - 1 >= 0 && (cvet[yi + 1, yj - 1] == "b")) || (yj + 1 < 8 && (cvet[yi + 1, yj + 1] == "b")))) ||
                            (cvet[yi, yj] == "b" && ((cvet[yi - 1, yj - 1] == "r") || (cvet[yi - 1, yj + 1] == "r"))))
                        {
                            rubit = true;
                        }
                        int predI = yi;
                        int predJ = yj;
                        bool HOD = false;
                        while (HOD == false)
                        {
                            Vibor_Hoda(out yi, out yj, yi, yj, out array, array1, cvet, "Kuda shodit", vibor_yach);

                            if (rubit == true && predJ != yj)
                            {
                                if ((cvet[predI, predJ] == "r") && (((predI + 1 == yi) && (predJ - 1 == yj) && cvet[yi, yj] == "b") ||
                                    ((predI + 1 == yi) && (predJ + 1 == yj) && cvet[yi, yj] == "b"))) { HOD = true; }
                                else
                                {
                                    if ((cvet[predI, predJ] == "b") && (((predI - 1 == yi) && (predJ - 1 == yj) && cvet[yi, yj] == "r") ||
                                    ((predI - 1 == yi) && (predJ + 1 == yj) && cvet[yi, yj] == "r"))) { HOD = true; }
                                    else { HOD = false; Console.WriteLine("Nepravilni Hod!" + "\n" + "Shodite snova1 predI = {0} yi = {1}", predI, yi); }
                                }
                            }
                            else
                            {
                                if ((rubit == true) || (rubit == false))
                                {


                                    if ((cvet[yi, yj] != cvet[predI, predJ]) && yj == predJ)
                                    {


                                        if (dvoinoi_hod == true)
                                        {

                                            if ((cvet[predI, predJ] == "r") && ((predI + 1 == yi) || ((predI + 2 == yi) && ((cvet[predI + 1, yj] != "r") && (cvet[predI + 1, yj] != "b")))) && (cvet[yi, yj] != "b"))
                                            { HOD = true; }
                                            else
                                            {
                                                if (cvet[predI, predJ] == "b" && ((predI - 1 == yi) || ((predI - 2 == yi) && ((cvet[predI - 1, yj] != "r") && (cvet[predI - 1, yj] != "b")))) && (cvet[yi, yj] != "r"))
                                                { HOD = true; }
                                                else { HOD = false; Console.WriteLine("Nepravilni Hod!" + "\n" + dvoinoi_hod + "Shodite snova1 predI = {0} yi = {1}", predI, yi); }
                                            }
                                        }
                                        else
                                        {
                                            if ((cvet[predI, predJ] == "r") && (predI + 1 == yi) && (cvet[yi, yj] != "b")) { HOD = true; }
                                            else
                                            {
                                                if (cvet[predI, predJ] == "b" & (predI - 1 == yi) && (cvet[yi, yj] != "r")) { HOD = true; }
                                                else { HOD = false; Console.WriteLine("Nepravilni Hod!" + "\n" + "Shodite snova2"); }
                                            }
                                        }

                                    }
                                    else { HOD = false; Console.WriteLine("Nepravilni Hod!" + "\n" + "Shodite snova3" + rubit); }
                                }
                            }
                        }
                        string vremfig = array[predI, predJ];
                        array[predI, predJ] = null;
                        if (yi == 0 || yi == 7)
                        {
                            array[yi, yj] = "W";
                        }
                        else { array[yi, yj] = vremfig; }
                        string vremcolor = cvet[predI, predJ];
                        cvet[predI, predJ] = null;
                        cvet[yi, yj] = vremcolor;

                        break;
                    }
                case "L":
                    {
                        Console.WriteLine("Kuda poidem?: ");
                        int predI = yi;
                        int predJ = yj;
                        bool HOD = false;
                        while (HOD == false)
                        {
                            Vibor_Hoda(out yi, out yj, yi, yj, out array, array1, cvet, "Kuda shodit", vibor_yach);

                            if ((cvet[yi, yj] != cvet[predI, predJ]) && (((predI == yi) && (predJ != yj)) || ((predI != yi) && (predJ == yj))))
                            {
                                bool chisti_put = true;
                                int a = 0, b = 0;
                                if (predJ == yj) // если иду по вертикали 
                                {
                                    for (int i = predI + 1; i < yi; i++)
                                    {
                                        if (cvet[i, yj] == "r" || cvet[i, yj] == "b") { chisti_put = false; a++; break; }
                                        else { chisti_put = true; b++; }
                                    }
                                }
                                else // если иду по горизонтали
                                {
                                    for (int j = predJ + 1; j < yj; j++)
                                    {
                                        if (cvet[yi, j] == "r" || cvet[yi, j] == "b") { chisti_put = false; a++; break; }
                                        else { chisti_put = true; b++; }
                                    }
                                }
                                if (chisti_put == true)
                                {
                                    HOD = true;
                                }
                                else
                                {
                                    HOD = false; Console.WriteLine("Nepravilni Hod!" + "\n" + "Shodite snova1 a = {0} b = {1}", a, b + " " + chisti_put);
                                }


                            }
                            else { HOD = false; Console.WriteLine("Nepravilni Hod!" + "\n" + "Shodite snova2"); }
                        }

                        string vremfig = array[predI, predJ];
                        array[predI, predJ] = null;
                        array[yi, yj] = vremfig;
                        string vremcolor = cvet[predI, predJ];
                        cvet[predI, predJ] = null;
                        cvet[yi, yj] = vremcolor;

                        break;
                    }

                case "R":
                    {
                        Console.WriteLine("Kuda poidem?: ");
                        int predI = yi;
                        int predJ = yj;
                        bool HOD = false;
                        while (HOD == false)
                        {
                            Vibor_Hoda(out yi, out yj, yi, yj, out array, array1, cvet, "Kuda shodit",vibor_yach);
                            if (
                                (cvet[yi, yj] != cvet[predI, predJ]) &&
                                    (
                                        ((predI - 2 >= 0) && (predJ + 1 < 8) && (predI - 2 == yi) && (predJ + 1 == yj)) ||
                                        ((predI - 2 >= 0) && (predJ - 1 >= 0) && (predI - 2 == yi) && (predJ - 1 == yj)) ||
                                        ((predI + 2 < 8) && (predJ + 1 < 8) && (predI + 2 == yi) && (predJ + 1 == yj)) ||
                                        ((predI + 2 < 8) && (predJ - 1 >= 0) && (predI + 2 == yi) && (predJ - 1 == yj)) ||
                                        ((predI - 1 >= 0) && (predJ - 2 >= 0) && (predI - 1 == yi) && (predJ - 2 == yj)) ||
                                        ((predI - 1 >= 0) && (predJ + 2 < 8) && (predI - 1 == yi) && (predJ + 2 == yj)) ||
                                        ((predI + 1 < 8) && (predJ - 2 >= 0) && (predI + 1 == yi) && (predJ - 2 == yj)) ||
                                        ((predI + 1 < 8) && (predJ + 2 < 8) && (predI + 1 == yi) && (predJ + 2 == yj))
                                    )

                               )
                            {
                                HOD = true;
                            }
                            else
                            {
                                HOD = false; Console.WriteLine("Nepravilni Hod!" + "\n" + "Shodite snova2");
                            }
                        }

                        string vremfig = array[predI, predJ];
                        array[predI, predJ] = null;
                        array[yi, yj] = vremfig;
                        string vremcolor = cvet[predI, predJ];
                        cvet[predI, predJ] = null;
                        cvet[yi, yj] = vremcolor;
                        break;
                    }

                case "F":
                    {
                        Console.WriteLine("Kuda poidem?: ");
                        int predI = yi;
                        int predJ = yj;
                        bool HOD = false;
                        while (HOD == false)
                        {
                            Vibor_Hoda(out yi, out yj, yi, yj, out array, array1, cvet, "Kuda shodit", vibor_yach);
                            if ((cvet[yi, yj] != cvet[predI, predJ]) && (predI != yi) && (predJ != yj) && (Math.Abs(predI - yi) == Math.Abs(predJ - yj)))
                            {
                                bool chisti_put = true;
                                if (predI - yi > 0 && predJ - yj > 0)
                                {
                                    for (int i = predI - 1, j = predJ - 1; i > yi & j > yj; i--, j--)
                                    {
                                        if (cvet[i, j] == "r" || cvet[i, j] == "b") { chisti_put = false; break; }
                                        else { chisti_put = true; }
                                    }
                                }
                                else
                                {
                                    if (predI - yi > 0 && predJ - yj < 0)
                                    {
                                        for (int i = predI - 1, j = predJ + 1; i > yi & j < yj; i--, j++)
                                        {
                                            if (cvet[i, j] == "r" || cvet[i, j] == "b") { chisti_put = false; break; }
                                            else { chisti_put = true; }
                                        }
                                    }
                                    else
                                    {
                                        if (predI - yi < 0 && predJ - yj < 0)
                                        {
                                            for (int i = predI + 1, j = predJ + 1; i < yi & j < yj; i++, j++)
                                            {
                                                if (cvet[i, j] == "r" || cvet[i, j] == "b") { chisti_put = false; break; }
                                                else { chisti_put = true; }
                                            }
                                        }
                                        else
                                        {
                                            if (predI - yi < 0 && predJ - yj > 0)
                                            {
                                                for (int i = predI + 1, j = predJ - 1; i < yi & j > yj; i++, j--)
                                                {
                                                    if (cvet[i, j] == "r" || cvet[i, j] == "b") { chisti_put = false; break; }
                                                    else { chisti_put = true; }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (chisti_put == true)
                                {
                                    HOD = true;
                                }
                                else
                                {
                                    HOD = false; Console.WriteLine("Nepravilni Hod!" + "\n" + "Shodite snova1 a = {0} b = {1}" + chisti_put);
                                }
                            }
                            else { HOD = false; Console.WriteLine("Nepravilni Hod!" + "\n" + "Shodite snova3"); }
                        }
                        string vremfig = array[predI, predJ];
                        array[predI, predJ] = null;
                        array[yi, yj] = vremfig;
                        string vremcolor = cvet[predI, predJ];
                        cvet[predI, predJ] = null;
                        cvet[yi, yj] = vremcolor;
                        break;
                    }
                case "Q":
                    {
                        Console.WriteLine("Kuda poidem?: ");
                        int predI = yi;
                        int predJ = yj;
                        bool HOD = false;
                        while (HOD == false)
                        {
                            Vibor_Hoda(out yi, out yj, yi, yj, out array, array1, cvet, "Kuda shodit", vibor_yach);
                            if ((cvet[yi, yj] != cvet[predI, predJ]) && (predI != yi) && (predJ != yj) && (Math.Abs(predI - yi) == Math.Abs(predJ - yj)))
                            {
                                bool chisti_put = true;
                                if (predI - yi > 0 && predJ - yj > 0)
                                {
                                    for (int i = predI - 1, j = predJ - 1; i > yi & j > yj; i--, j--)
                                    {
                                        if (cvet[i, j] == "r" || cvet[i, j] == "b") { chisti_put = false; break; }
                                        else { chisti_put = true; }
                                    }
                                }
                                else
                                {
                                    if (predI - yi > 0 && predJ - yj < 0)
                                    {
                                        for (int i = predI - 1, j = predJ + 1; i > yi & j < yj; i--, j++)
                                        {
                                            if (cvet[i, j] == "r" || cvet[i, j] == "b") { chisti_put = false; break; }
                                            else { chisti_put = true; }
                                        }
                                    }
                                    else
                                    {
                                        if (predI - yi < 0 && predJ - yj < 0)
                                        {
                                            for (int i = predI + 1, j = predJ + 1; i < yi & j < yj; i++, j++)
                                            {
                                                if (cvet[i, j] == "r" || cvet[i, j] == "b") { chisti_put = false; break; }
                                                else { chisti_put = true; }
                                            }
                                        }
                                        else
                                        {
                                            if (predI - yi < 0 && predJ - yj > 0)
                                            {
                                                for (int i = predI + 1, j = predJ - 1; i < yi & j > yj; i++, j--)
                                                {
                                                    if (cvet[i, j] == "r" || cvet[i, j] == "b") { chisti_put = false; break; }
                                                    else { chisti_put = true; }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (chisti_put == true)
                                {
                                    HOD = true;
                                }
                                else
                                {
                                    HOD = false; Console.WriteLine("Nepravilni Hod!" + "\n" + "Shodite snova1 a = {0} b = {1}" + chisti_put);
                                }
                            }
                            else
                            {
                                if ((cvet[yi, yj] != cvet[predI, predJ]) && (((predI == yi) && (predJ != yj)) || ((predI != yi) && (predJ == yj))))
                                {
                                    bool chisti_put = true;
                                    int a = 0, b = 0;
                                    if (predJ == yj) // если иду по вертикали 
                                    {
                                        for (int i = predI + 1; i < yi; i++)
                                        {
                                            if (cvet[i, yj] == "r" || cvet[i, yj] == "b") { chisti_put = false; a++; break; }
                                            else { chisti_put = true; b++; }
                                        }
                                    }
                                    else // если иду по горизонтали
                                    {
                                        for (int j = predJ + 1; j < yj; j++)
                                        {
                                            if (cvet[yi, j] == "r" || cvet[yi, j] == "b") { chisti_put = false; a++; break; }
                                            else { chisti_put = true; b++; }
                                        }
                                    }
                                    if (chisti_put == true)
                                    {
                                        HOD = true;
                                    }
                                    else
                                    {
                                        HOD = false; Console.WriteLine("Nepravilni Hod!" + "\n" + "Shodite snova1 a = {0} b = {1}", a, b + " " + chisti_put);
                                    }
                                }
                            }
                        }
                        string vremfig = array[predI, predJ];
                        array[predI, predJ] = null;
                        array[yi, yj] = vremfig;
                        string vremcolor = cvet[predI, predJ];
                        cvet[predI, predJ] = null;
                        cvet[yi, yj] = vremcolor;
                        break;
                    }
                case "W":
                    {
                        Console.WriteLine("Kuda poidem?: ");
                        int predI = yi;
                        int predJ = yj;
                        bool HOD = false;
                        while (HOD == false)
                        {
                            Vibor_Hoda(out yi, out yj, yi, yj, out array, array1, cvet, "Kuda shodit", vibor_yach);
                            if ((cvet[yi, yj] != cvet[predI, predJ]) && (predI != yi) && (predJ != yj) && (Math.Abs(predI - yi) == Math.Abs(predJ - yj)))
                            {
                                bool chisti_put = true;
                                if (predI - yi > 0 && predJ - yj > 0)
                                {
                                    for (int i = predI - 1, j = predJ - 1; i > yi & j > yj; i--, j--)
                                    {
                                        if (cvet[i, j] == "r" || cvet[i, j] == "b") { chisti_put = false; break; }
                                        else { chisti_put = true; }
                                    }
                                }
                                else
                                {
                                    if (predI - yi > 0 && predJ - yj < 0)
                                    {
                                        for (int i = predI - 1, j = predJ + 1; i > yi & j < yj; i--, j++)
                                        {
                                            if (cvet[i, j] == "r" || cvet[i, j] == "b") { chisti_put = false; break; }
                                            else { chisti_put = true; }
                                        }
                                    }
                                    else
                                    {
                                        if (predI - yi < 0 && predJ - yj < 0)
                                        {
                                            for (int i = predI + 1, j = predJ + 1; i < yi & j < yj; i++, j++)
                                            {
                                                if (cvet[i, j] == "r" || cvet[i, j] == "b") { chisti_put = false; break; }
                                                else { chisti_put = true; }
                                            }
                                        }
                                        else
                                        {
                                            if (predI - yi < 0 && predJ - yj > 0)
                                            {
                                                for (int i = predI + 1, j = predJ - 1; i < yi & j > yj; i++, j--)
                                                {
                                                    if (cvet[i, j] == "r" || cvet[i, j] == "b") { chisti_put = false; break; }
                                                    else { chisti_put = true; }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (chisti_put == true)
                                {
                                    HOD = true;
                                }
                                else
                                {
                                    HOD = false; Console.WriteLine("Nepravilni Hod!" + "\n" + "Shodite snova1 a = {0} b = {1}" + chisti_put);
                                }
                            }
                            else
                            {
                                if ((cvet[yi, yj] != cvet[predI, predJ]) && (((predI == yi) && (predJ != yj)) || ((predI != yi) && (predJ == yj))))
                                {
                                    bool chisti_put = true;
                                    int a = 0, b = 0;
                                    if (predJ == yj) // если иду по вертикали 
                                    {
                                        for (int i = predI + 1; i < yi; i++)
                                        {
                                            if (cvet[i, yj] == "r" || cvet[i, yj] == "b") { chisti_put = false; a++; break; }
                                            else { chisti_put = true; b++; }
                                        }
                                    }
                                    else // если иду по горизонтали
                                    {
                                        for (int j = predJ + 1; j < yj; j++)
                                        {
                                            if (cvet[yi, j] == "r" || cvet[yi, j] == "b") { chisti_put = false; a++; break; }
                                            else { chisti_put = true; b++; }
                                        }
                                    }
                                    if (chisti_put == true)
                                    {
                                        HOD = true;
                                    }
                                    else
                                    {
                                        HOD = false; Console.WriteLine("Nepravilni Hod!" + "\n" + "Shodite snova1 a = {0} b = {1}", a, b + " " + chisti_put);
                                    }
                                }
                            }
                        }
                        string vremfig = array[predI, predJ];
                        array[predI, predJ] = null;
                        array[yi, yj] = vremfig;
                        string vremcolor = cvet[predI, predJ];
                        cvet[predI, predJ] = null;
                        cvet[yi, yj] = vremcolor;
                        break;
                    }
                case "K":
                    {
                        Console.WriteLine("Kuda poidem?: ");
                        int predI = yi;
                        int predJ = yj;
                        bool HOD = false;
                        while (HOD == false)
                        {
                            Vibor_Hoda(out yi, out yj, yi, yj, out array, array1, cvet, "Kuda shodit", vibor_yach);

                            if (
                                (cvet[yi, yj] != cvet[predI, predJ]) &&
                                (
                                    (Math.Abs(predI - yi) == 1 && Math.Abs(predJ - yj) == 1) ||
                                    (Math.Abs(predI - yi) == 0 && Math.Abs(predJ - yj) == 1) ||
                                    (Math.Abs(predI - yi) == 1 && Math.Abs(predJ - yj) == 0)
                                )
                               )
                            {

                                HOD = true;
                            }
                            else
                            {
                                HOD = false; Console.WriteLine("Nepravilni Hod!" + "\n" + "Shodite snova2");
                            }
                        }
                        string vremfig = array[predI, predJ];
                        array[predI, predJ] = null;
                        array[yi, yj] = vremfig;
                        string vremcolor = cvet[predI, predJ];
                        cvet[predI, predJ] = null;
                        cvet[yi, yj] = vremcolor;
                        break;
                    }
                default:
                    {

                        Console.WriteLine("DEF");
                        break;
                    }

            }
        }

        static void Vivod_Doska(string[,] doska1, string[,] cvet)
        {
            Console.Clear();
            Console.Write("\t");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("j{0}", i + "\t");
            }
            Console.WriteLine("\n" + "\n" + "\n");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("i{0}", i + "\t");
                for (int j = 0; j < 8; j++)
                {
                    if (doska1[i, j] == "P" || doska1[i, j] == "L" || doska1[i, j] == "K" || doska1[i, j] == "F" || doska1[i, j] == "R" || doska1[i, j] == "Q" || doska1[i, j] == "W")
                    {
                        if (cvet[i, j] == "b")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(doska1[i, j] + "\t");
                            Console.ResetColor();
                        }
                        else if (cvet[i, j] == "r")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(doska1[i, j] + "\t");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.Write("-" + "\t");
                    }
                }
                Console.Write("i{0}", i + "\t");
                Console.WriteLine("\n" + "\n" + "\n");
            }
            Console.Write("\t");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("j{0}", i + "\t");
            }
            Console.WriteLine("\n" + "\n" + "\n");
        }
        static void Vivod_Doska_dlua_fibora (string[,] doska1, string[,] cvet, string[,] fibor)
        {
            Console.Clear();
            Console.Write("\t");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("j{0}", i + "\t");
            }
            Console.WriteLine("\n" + "\n" + "\n");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("i{0}", i + "\t");
                for (int j = 0; j < 8; j++)
                {
                    if (doska1[i, j] == "P" || doska1[i, j] == "L" || doska1[i, j] == "K" || doska1[i, j] == "F" || doska1[i, j] == "R" || doska1[i, j] == "Q" || doska1[i, j] == "W")
                    {
                        if (cvet[i, j] == "b")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            if (fibor[i, j] == "*")
                            {
                                Console.BackgroundColor = ConsoleColor.Gray;
                            }
                            Console.Write(doska1[i, j]);
                            Console.ResetColor();
                            Console.Write("\t");
                        }
                        else if (cvet[i, j] == "r")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            if (fibor[i, j] == "*")
                            {
                                Console.BackgroundColor = ConsoleColor.Gray;
                            }
                            Console.Write(doska1[i, j]);
                            Console.ResetColor();
                            Console.Write("\t");

                        }
                    }
                    else
                    {
                        if (fibor[i, j] == "*")
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write("-");
                            Console.ResetColor();
                            Console.Write("\t");
                        }
                        else Console.Write("-" + "\t");
                    }

                }
                Console.Write("i{0}", i + "\t");
                Console.WriteLine("\n" + "\n" + "\n");
            }
            Console.Write("\t");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("j{0}", i + "\t");
            }
            Console.WriteLine("\n" + "\n" + "\n");
        }
        static void Proverka_mat(string[,] doska1, out bool mat)
        {
            mat = false;
            int a = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (doska1[i, j] == "K") { a++; }
                }
            }
            if (a != 2) { mat = true; }
        }
        static void Raund(out int nomer, int vremnomer, out string kto_hod, string vrem_kto)
        {
            nomer = vremnomer;
            kto_hod = vrem_kto;
            if (nomer % 2 == 0) { kto_hod = "b"; }
            else { kto_hod = "r"; }
        }
        static void Main(string[] args)
        {
            string[,] cvet = new string[8, 8];
            string[,] doska = new string[8, 8];
            string[,] vibor_yacheiki = new string[8, 8];

            bool MAT = false;
            string cvett = "r";
            doska[0, 0] = "L"; doska[0, 7] = "L";
            doska[7, 0] = "L"; doska[7, 7] = "L";
            doska[0, 1] = "R"; doska[0, 6] = "R";
            doska[7, 1] = "R"; doska[7, 6] = "R";
            doska[0, 2] = "F"; doska[0, 5] = "F";
            doska[7, 2] = "F"; doska[7, 5] = "F";
            doska[0, 2] = "F"; doska[0, 5] = "F";
            doska[7, 2] = "F"; doska[7, 5] = "F";
            doska[0, 3] = "K"; doska[0, 4] = "Q";
            doska[7, 3] = "K"; doska[7, 4] = "Q";
            for (int i = 1; i <= 6; i += 5)
            {
                for (int j = 0; j < 8; j++)
                {
                    doska[i, j] = "P";
                }
            }
            for (int i = 0; i < 8; i += 6)
            {
                for (int j = 0; j < 8; j++)
                {
                    cvet[i, j] = cvett;
                    cvet[i + 1, j] = cvett;
                }
                cvett = "b";
            }
            int yi, yj;
            int nomer_raunda = 1;
            string kto_hod = "r";
            Console.WriteLine("NAZHMITE NE ENTER CHTOBI IGRAT");
            while (MAT == false)
            {
                Raund(out nomer_raunda, nomer_raunda, out kto_hod, kto_hod);
                yi = 4; yj = 3;
                Vibor_figuri(out yi, out yj, yi, yj, out doska, doska, cvet, "Figuru", kto_hod, nomer_raunda,vibor_yacheiki);
                Variant_Hoda(out yi, out yj, yi, yj, out doska[yi, yj], out doska, doska, out cvet, cvet, vibor_yacheiki);
                Vivod_Doska(doska, cvet);
                Console.WriteLine("SHODIL i = {0} j = {1}", yi, yj);
                Proverka_mat(doska, out MAT);
                nomer_raunda++;
            }
            string kto;
            if (kto_hod == "r") { kto = "Krasnie"; }
            else kto = "Sinie";
            Console.WriteLine("GAME OVER"+"\n"+"POBEDILI "+kto + "\n"+"IGRA DLILAS {0} RAUNDOV",nomer_raunda-1);
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.ReadKey();
        }
    }
}