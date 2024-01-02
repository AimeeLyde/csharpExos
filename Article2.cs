using System;
namespace ExosCs
{
    public class Article2
    {
        public string nom;
        public double prix;
        public int quantite;
        public ArticleType articleType;

        public void Afficher()
        {
            Console.WriteLine("Article :  " + "Nom : " + nom + " Prix : " + prix + " Quantite : " + quantite + articleType);
        }

        public void Ajouter()
        {
            quantite = ++quantite;
            Console.WriteLine(quantite);

        }

        public void Retirer()
        {
            quantite = --quantite;
            Console.WriteLine(quantite);

        }

    }
}

