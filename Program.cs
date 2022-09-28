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
        public static string name = "";
        public static int vies = 0;
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
                Console.WriteLine("Waaaaaaaaaow vous avez gagné!!!!!! "+ name + "! Vous avez trouvé le mot : " + motmystere);
                Console.WriteLine(); 
                Console.WriteLine("Appuyez sur n'importe quelle touche pour recommencer, sinon appuyez sur n pour quitter \n");

                ready = Console.ReadKey().Key.ToString().ToLower();
                if (ready == "n")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Good Bye " + name);
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

            var input = string.Empty;

            do
            {

                Console.WriteLine("Bienvenue au jeu du pendu ! ");
                Console.WriteLine("Le jeu consiste à deviner un mot en proposant des lettres.");
                Console.WriteLine("Les règles sont simples :\n");
                Console.WriteLine("Vous avez un nombre de vies (5,10 ou 15 selon la difficulté)\n");
                Console.WriteLine("Appuyez sur Escape pour quitter à tout moment\n");
                Console.WriteLine();

                Console.WriteLine("[1] Continuer");
                Console.WriteLine("[2] Quitter?");
                Console.WriteLine("");
                Console.Write("Entrez un choix valide: ");

                input = Console.ReadLine();

                if (input == "1" || input == "2")
                {

                    if (input == "1")
                    {
                        Console.Write("Entrez votre nom : ");
                        name = Console.ReadLine();
                        Difficulté();
                    }
                    else
                    {
                        Console.WriteLine("Goodbye !");
                        Environment.Exit(0);
                    }

                    Console.WriteLine("");
                    Console.Write("Press any key to exit... ");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                }
            }
            while (input != "1" && input != "2");
        }

        private static void Difficulté()
        {

            var input = string.Empty;

            do
            {

                Console.WriteLine("Choississez le niveau de difficulté ");
                Console.WriteLine();

                Console.WriteLine("[1] Facile(15 vies)");
                Console.WriteLine("[2] Moyen (10 vies)");
                Console.WriteLine("[3] Difficile (5 vies)");
                Console.WriteLine("");
                Console.Write("Entrez un choix valide: ");

                input = Console.ReadLine();

                if (input == "1" || input == "2" || input =="3")
                {

                    if (input == "1")
                    {
                        vies = 15;
                        StartGame();
                    }
                    else if (input == "2")
                    {
                        vies = 10;
                        StartGame();
                    }
                    else if (input =="3")
                    {
                        vies = 5;
                        StartGame();
                    }
                    Console.WriteLine("");
                    Console.Write("Press any key to exit... ");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                }
            }
            while (input != "1" && input != "2" && input != "3");
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


            //string trouve = "false";
            char lettre;
            if (ready == "n")
            {
                Console.WriteLine("");
                Console.WriteLine("Good Bye " + name);
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
                Console.WriteLine("Vous avez " + vies +" vies");


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
                            Console.WriteLine("Vous avez trouvé la lettre  \"" + lettre + "\" Bravo " + name +" !");
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
                        vies--;
                        Console.WriteLine("Vous avez perdu une vie, il vous reste : " + (vies));
                    }


                } while (vies> 0 && lettre != Convert.ToChar(ConsoleKey.Escape));
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("Vous avez perdu, " + name + " le mot mystère était :" + motmystere);
                Console.WriteLine();
                Console.WriteLine("Appuyez sur n'importe quelle touche pour recommencer, sinon appuyez sur n pour quitter \n");

                ready = Console.ReadKey().Key.ToString().ToLower();
                if (ready == "n")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Good Bye " + name);
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



