using System;
using Aggregation;
using Heritage;
using Association;
using System.Collections.Generic;
using Reflexive;
using Composition;

namespace Exemples_rélations_en_code_C_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exemples de rélations");
            Console.WriteLine("---------------------");

            // heritage 
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Heritage:");
            Console.WriteLine("---------");

            Chien laika = new Chien();
            laika.seDeplacer();
            laika.manger();
            Vache maVache = new Vache();
            maVache.seDeplacer();
            maVache.manger();


            // association
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Association (plusieurs à plusieurs)");
            Console.WriteLine("-------------------");

            Personnage p1 = new Personnage();
            p1.Nom = "Gerald";
            Arme a1 = new Arme();
            a1.Nom = "epée";
            Arme a2 = new Arme();
            a2.Nom = "epée magique";
            // rajouter les armes au personnage p1
            p1.addArme(a1);
            p1.addArme(a2);
            p1.afficherArmes();

            // établir quel est le personnage porteur de cette arme (le lien dans l'autre sens)
            a1.addPersonnage(p1);
            a2.addPersonnage(p1);
            // on aurait pu créer un code dans Personnage capable de créer le lien dans les deux sens
            a1.afficherPersonnages();



            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Aggregation");
            Console.WriteLine("-------------------");
            VideoProjecteur vp = new VideoProjecteur();
            List<PC> pcs = new List<PC>();
            for (int i = 0; i < 15; i++)
            {
                pcs.Add(new PC("code" + (i + 1)));
            }
            Local l = new Local(vp, pcs);
            l.afficherPCs();
            Console.WriteLine();
            Console.WriteLine("On met à null le local mais les pcs continuent leur vie");
            l = null;
            Console.WriteLine("Ex: le PC numéro 2, voici son code: " + pcs[1].Code);



            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Composition");
            Console.WriteLine("-----------");
            Tableau tableau = new Tableau("tableau 1");
            // les pions et les chevaux existent uniquement à l'interieur du tableau
            Console.WriteLine(tableau.pions.Count);
            Console.WriteLine(tableau.pions);

            Console.WriteLine(tableau.chevaux.Count);
            Console.WriteLine(tableau.chevaux);

            tableau = null; // le garbage collector effacera tout





            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Assoc. Reflexive");
            Console.WriteLine("----------------");

            Personne parent = new Personne("Anakin");
            Personne f1 = new Personne("Luke");
            Personne f2 = new Personne("Leia");

            parent.addEnfant(f1);
            parent.addEnfant(f2);

            parent.afficheEnfants();


        }
    }
}
