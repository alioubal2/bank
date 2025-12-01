namespace bank.Models;

public class CompteEpargne : Compte
{
    private double _tauxInteret;

    public double TauxInteret
    {
        get => _tauxInteret;
        set => _tauxInteret = value;
    }

    public CompteEpargne(double soldeInitial, double tauxInteret = 5)
        : base(soldeInitial)
    {
        _tauxInteret = tauxInteret;
    }

    private CompteEpargne() { }

    public double CalculInteret()
    {
        return (Solde * _tauxInteret) / 100;
    }

    public void Maj()
    {
        double interet = CalculInteret();
        typeof(Compte)
            .GetField("_solde", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(this, Solde + interet);
    }

    public override void Affichage()
    {
        base.Affichage();
        Console.WriteLine($"Taux d'intérêt : {_tauxInteret}%");
    }
}
