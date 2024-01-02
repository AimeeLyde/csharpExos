using System.Runtime.CompilerServices;
namespace ExosCs;



public class Article
{
    public string designation;
    public double prix;

    public Article(string designation, double prix)
    {
        this.designation = designation;
        this.prix = prix;
    }

    public string Designation
    {
        get { return designation; }
    }

    public double Prix
    {
        get { return prix; }
    }
    public override string ToString()
    {
        return $"Designation : {designation}, Prix : {prix}";
    }

    public void Acheter() { }



}

public class Livre : Article
{
    public string isbn;
    public int nbPages;
    public int dateDePublication;

    public Livre(string designation, double prix, string isbn, int nbPages, int dateDePublication)
        : base(designation, prix)
    {
        this.isbn = isbn;
        this.nbPages = nbPages;
        this.dateDePublication = dateDePublication;
    }
}

//public class Poche : Livre
//{
//    public string categorie;

//    public Poche(string categorie, string designation, double prix, string isbn, int nbPages) : base(designation, prix, isbn, nbPages)
//    {
//        this.categorie = categorie;
//    }
//}

public class Disque : Article
{
    public string label;
    public string genre;

    public Disque(string designation, double prix, string label, string genre)
        : base(designation, prix)
    {
        this.label = label;
        this.genre = genre;
    }

    public void Ecouter()
    {
        Console.WriteLine("Ecoute de la vidéo");
    }
}

public class Video : Article
{
    public int duree;

    public Video(string designation_constr, double prix_constr, int duree) : base(designation_constr,
        prix_constr)
    {
        this.duree = duree;
    }

    public void Afficher()
    {
        Console.WriteLine("Affichage de la vidéo");
    }
}

//public class Broche : Livre
//{
//    public Broche(string designation, double prix, string isBn, int nbPages) : base(designation, prix, isBn, nbPages)
//    {

//    }
//}










