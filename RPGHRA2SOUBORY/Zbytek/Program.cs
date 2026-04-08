using System;
using System.Reflection.Metadata.Ecma335;

namespace RPGHra2
{

    class Program
    {
        static void Main()
        {
            Character vybranyHrdina = null;
            bool konecHry = false;
            while (!konecHry)
            {


                string[] menuPrvni = { "Play", "Choose a Character", "Exit" };
                int volbaPohyb = RPGHra2.Moznosti.VykresliMoznosti(menuPrvni, "Vítej!");
                switch (volbaPohyb)
                {
                    case 0:
                        Console.Clear();
                        if (vybranyHrdina == null)
                        {
                            Console.WriteLine("Napred si vyber hrdinu!");
                            Console.WriteLine("\nStiskni libovolnou klávesu pro návrat do menu...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.WriteLine($"Máš vybraného: {vybranyHrdina.GetType().Name}!");
                            Console.WriteLine("Hra běží...");
                            int Hrabezi1 = 2;
                            switch (Hrabezi1)
                            {
                                case 0:
                                    return;
                                    
                                case 1: 
                                return;
                            }
                            
                        }
                       
                        break;

                    case 1:
                        vybranyHrdina = RPGHra2.HrdinaLogika.VyberPostavu();
                        Console.WriteLine($"Vybral sis hrdinu: {vybranyHrdina}!");
                        break;
                    case 2:
                        Console.WriteLine("Konec");
                        konecHry = true;
                        break;
                }
                
                
                
                
            }
        }
    }   
       
    }
