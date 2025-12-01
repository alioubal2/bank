namespace bank.Models;

public class Agence
{
    private string _code = null!;
    private string _nom = null!;
    private string _adresse = null!;

    public string Code
    {
        get => _code;
        private set => _code = value;
    }

    public string Nom
    {
        get => _nom;
        set => _nom = value;
    }

    public string Adresse
    {
        get => _adresse;
        set => _adresse = value;
    }

    // Relation EF Core : Une agence possède plusieurs clients
    public List<Client> Clients { get; set; } = new();

    public Agence(string code, string nom, string adresse)
    {
        _code = code;
        _nom = nom;
        _adresse = adresse;
    }

    private Agence() { }

    public void Affichage()
    {
        Console.WriteLine($"Code : {_code}");
        Console.WriteLine($"Nom : {_nom}");
        Console.WriteLine($"Adresse : {_adresse}");
    }
}
