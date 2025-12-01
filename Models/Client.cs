namespace bank.Models;

public enum Genre
{
    Homme,
    Femme
}

public class Client
{
    private string _numero = null!;
    private string _nom = null!;
    private string _prenom = null!;
    private Genre _genre;
    private string _telephone = null!;

    public string Numero
    {
        get => _numero;
        private set => _numero = value;
    }

    public string Nom
    {
        get => _nom;
        set => _nom = value;
    }

    public string Prenom
    {
        get => _prenom;
        set => _prenom = value;
    }

    public Genre Genre
    {
        get => _genre;
        set => _genre = value;
    }

    public string Telephone
    {
        get => _telephone;
        set => _telephone = value;
    }

    // Relation 1 client → 1 compte
    public Compte? Compte { get; set; }

    public Client(string numero, string nom, string prenom, Genre genre, string telephone)
    {
        _numero = numero;
        _nom = nom;
        _prenom = prenom;
        _genre = genre;
        _telephone = telephone;
    }

    private Client() { }

    public void Affichage()
    {
        Console.WriteLine($"Numéro : {_numero}");
        Console.WriteLine($"Nom : {_nom}");
        Console.WriteLine($"Prénom : {_prenom}");
        Console.WriteLine($"Genre : {_genre}");
        Console.WriteLine($"Téléphone : {_telephone}");
    }
}
