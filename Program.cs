using System;
using System.Collections.Generic;
using System.Linq;

namespace Jeu_Pendu
{

    /*Règles

Exercice : Le mot mystère

1)  L'ordinateur joue contre l'utilisateur
2)  L'ordinateur demande au joueur de choisir une lettre afin de deviner un mot de x lettres
3)  Le mot proposé est sélectionné parmi une liste au hasard
4)  Le joueur dispose de x tentatives pour trouver le mot mystère
5)  A chaque tentative, le joueur propose une lettre afin de trouver le mot mystère
6)  Le jeu s'arrête lorsque le joueur :
        a) A trouvé le mot mystère => c'est gagné
        b) A épuisé toutes ses chances "chances"
        c) Décide de quitter le jeu en appuyant sur la touche "echap" du clavier.



*/
    public class Program
    {
        public static List<char> LettresMot = new List<char>();
        public static List<char> LettresTrouvesv2 = new List<char>();
        public static string motmystere = "";
        public static string ready = "";
        public static void Main(string[] args)
        {
            Console.Title = "Le jeu du pendu";
            //Console.BackgroundColor = ConsoleColor.Blue;

            Menu();

        }


        public static void VerifierReponse()
        {
            if(LettresMot.Count == LettresTrouvesv2.Count)
            {
                Console.WriteLine("Waaaaaaaaaow vous avez gagné!!!!!! Vous avez trouvé le mot : " + motmystere);
                Console.WriteLine(); 
                Console.WriteLine("Appuyez sur n'importe quelle touche pour recommencer, sinon appuyez sur n pour quitter \n");

                ready = Console.ReadKey().Key.ToString().ToLower();
                if (ready == "n")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Good Bye Marylou");
                    Environment.Exit(0);
                }
                else
                {
                    Menu();
                }

            }
        }

        public static void DisplayWord()
        {
            Console.WriteLine("Le mot à trouver : ");
            foreach (char car in LettresMot)

            {
                    if (LettresTrouvesv2.Contains(car))
                    {
                        Console.Write(car);
                    }
                    else
                    {
                        Console.Write("_");
                    }
            }
        }
        
        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Bienvenue au jeu du pendu ! ");
            Console.WriteLine("Le jeu consiste à deviner un mot en proposant des lettres.");
            Console.WriteLine("Les règles sont simples\n");
            Console.WriteLine("Vous avez 5 vies\n");
            Console.WriteLine("Appuyez sur Escape pour quitter à tout moment\n");

            Console.WriteLine("Appuyez sur n'importe quelle touche pour commencer, sinon appuyez sur n pour quitter \n");

            ready = Console.ReadKey().Key.ToString().ToLower();
            LettresTrouvesv2.Clear();
            StartGame();

        }


        private static void StartGame()
        {
            string[] listing = new string[6];

            listing[0] = "java";
            listing[1] = "internet";
            listing[2] = "data";
            listing[3] = "language";
            listing[4] = "csharp";
            listing[5] = "php";

            var rand = new Random();

            string motcache;

            int vies = 0;
            //string trouve = "false";
            char lettre;
            if (ready == "n")
            {
                Console.WriteLine("");
                Console.WriteLine("Good Bye Marylou");
                Environment.Exit(0);
            }

            else
            {
                Console.WriteLine();
                //On choisi un des mots du tableau
                motmystere = "";
                motmystere = listing[rand.Next(listing.Length)];
                LettresMot.Clear();
                //Console.WriteLine("Le mot mystère à trouver est :" + motmystere);

                //on ajoute chaque lettre dans une liste
                for (int i = 0; i < motmystere.Length; i++)
                {
                    LettresMot.Add(motmystere[i]);
                }


                Console.WriteLine("-----------------------------------------------------------------------------------------");

                //Cacher le mot
                int howManyTimes = motmystere.Length;
                Char charToSend = '_';
                motcache = new string(charToSend, howManyTimes);

                Console.WriteLine("le mot mystère est composé de " + motcache.Length + " caractères : " + motcache);
                Console.WriteLine("Vous avez 5 vies");


                do
                {

                    VerifierReponse();
                    DisplayWord();
                    Console.WriteLine();
                    Console.WriteLine("Entrez une lettre");
                    lettre = Console.ReadKey().KeyChar;
                    Console.WriteLine("");


                    if (motmystere.Contains(lettre))
                    {
                        if (LettresTrouvesv2.Contains(lettre))
                        {
                            Console.WriteLine("Vous avez déjà entrer cette lettre !");
                        }
                        else
                        {
                            //Le joueur a trouvé une lettre
                            Console.WriteLine("Vous avez trouvé la lettre  \"" + lettre + "\" Bravo !");
                            foreach (char c in LettresMot)
                            {
                                if (c == lettre)
                                {
                                    LettresTrouvesv2.Add(lettre);
                                }
                            }

                            Console.WriteLine("-----------------------------------------------------------------------------------------");

                        }


                    }
                    else
                    {
                        vies++;
                        Console.WriteLine("Vous avez perdu une vie, il vous reste : " + (5 - vies));
                    }


                } while (vies < 5 && lettre != Convert.ToChar(ConsoleKey.Escape));
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("Vous avez perdu, le mot mystère était :" + motmystere);
                Console.WriteLine();
                Console.WriteLine("Appuyez sur n'importe quelle touche pour recommencer, sinon appuyez sur n pour quitter \n");

                ready = Console.ReadKey().Key.ToString().ToLower();
                if (ready == "n")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Good Bye Marylou");
                    Environment.Exit(0);
                }
                else
                {
                    Menu();
                }
            }

        }

    }
}


//while (lettre != Convert.ToChar(ConsoleKey.Escape) &&  !FoundWord()) && nbTentative>0);



