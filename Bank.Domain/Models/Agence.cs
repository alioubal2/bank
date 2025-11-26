class Agence
{
    private string _code;
    private string _nom;
    private string _adress;

    public Agence(string code, string nom, string adress)
    {
        _code = code;
        _nom = nom;
        _adress = adress;
    }

    public void affichage()
    {
        Console.WriteLine($"Votre code est {_code}");
        Console.WriteLine($"Votre nom est {_nom}");
        Console.WriteLine($"Votre adresse est {_adress}");
    }
}