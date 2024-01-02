using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace ExosCs
{
	public class ArticleDAO
	{
        private List<Article> articles;
        public ArticleDAO()
		{
			articles = new List<Article>();
		}

 
        public void Save(string path, List<Article> articleSaved)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (var article in articleSaved)
                    {
                        writer.WriteLine(article.ToString());
                        //writer.Write(article.designation + article.prix);
                    }

                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                throw;
            }
        }

        public void SupprimerFichier(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine("Fichier supprimé avec Succès !");
            }
        }
        
        static void Main()
        {
            Article article2 = new Article("NOM", 3.3);
            Article article3 = new Article("LIVRE2", 9.3);
            Article article4 = new Article("Petit Canari", 58.99);

            // LINK - Exploration des Fichiers
            List<Article> articles = new List<Article>();
            articles.Add(article2);
            articles.Add(article3);
            var livresRecents = articles.Where(livre => livre.prix > 5);
            foreach (var l in livresRecents)
            {
                Console.WriteLine("Livres dont le prix est supérieur à 5 : "+l);
            }

            // LINK - Sélection
            var livresTitres = from l in articles select l.designation;
            foreach (var l in livresTitres)
            {
                Console.WriteLine("Le titre des livres  : " + l);
            }

            // Link - Durée des vidéos.
            Video video1 = new Video("video1", 4.5, 45);
            Video video2 = new Video("video2", 5.5, 65);
            List<Video> listvideos = new List<Video>();
            listvideos.Add(video1);
            listvideos.Add(video2);
            var videosTitres = from v in listvideos select v.designation;
            foreach (var v in videosTitres)
            {
                Console.WriteLine("Le titre des vidéos  : " + v);
            }

            // Link - Filtrage -- Livres publiés après 2010
            Livre livre1 = new Livre("Enfant Grand", 4.5, "isbn", 78, 2020);
            Livre livre2 = new Livre("Grand Jus", 5.9, "isbn", 78, 2010);
            Livre livre3 = new Livre("EggMarron", 9.3, "isbn", 88, 2015);
            List<Livre> listeDeLivres = new List<Livre>();
            listeDeLivres.Add(livre1);
            listeDeLivres.Add(livre2);
            listeDeLivres.Add(livre3);
            var livresPubliés = listeDeLivres.Where(livre => livre.dateDePublication > 2010);
            foreach (var l in livresPubliés)
            {
                Console.WriteLine("Le titre des livres  : " + l);
            }

            // Tri - ordre alphabétique
            var livreOrdreAlphabétique = listeDeLivres.OrderBy(livre => livre.designation).ToList();
            Console.WriteLine("Livres par ordre alphabétique  : " );
            foreach (var l in livreOrdreAlphabétique)
            {
                Console.WriteLine(l);
            }

            // Jointure entre Livres et Disques

            var joinLivreArticle = from a in articles
                                   join l in listeDeLivres
                                   on (string)a.designation equals (string)l.designation
                                   select a;
            foreach (var j in joinLivreArticle)
            {
                Console.WriteLine("Jointures entres les livres et les articles  : " + j);
            }
            //Création de Fichier
            List<Article> list = new List<Article>();
            list.Add(article2);
            list.Add(article3);
            list.Add(article4);
            ArticleDAO articleDao = new ArticleDAO();
            articleDao.Save(@"/Users/aimeedaisy/Documents/articles.txt", list);

            //Connexion à la Base de données
            Connexion conn = new Connexion();
            conn.ConnectToDB();
            //conn.CreateTable("CREATE TABLE contact (id INT PRIMARY KEY NOT NULL,name VARCHAR(100),tel VARCHAR(10))");
            
            
        }
    }
}

