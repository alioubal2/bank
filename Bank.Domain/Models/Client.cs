class Client
{
    private string _numero;
    private string _nom;
    private string _prenom;
    private Enum _genre;
    private string _numeroDate;

    public Client(string numero, string nom, string prenom, Enum genre, string numeroDate)
    {
        _numero = numero;
        _nom = nom;
        _prenom = prenom;
        _genre = genre;
        _numeroDate = numeroDate;
    }
    public void affichage()
    {
        Console.WriteLine($"Votre numero est {_numero}");
        Console.WriteLine($"Votre nom est {_nom}");
        Console.WriteLine($"Votre prenom est {_prenom}");
        Console.WriteLine($"Votre genre est {_genre}");
        Console.WriteLine($"Votre numeroDate est {_numeroDate}");
    }
}