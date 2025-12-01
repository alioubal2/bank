namespace bank.Models;

public class CompteCourant : Compte
{
    private double _decouvert;

    public double Decouvert
    {
        get => _decouvert;
        set => _decouvert = value;
    }

    private CompteCourant() { }

    public CompteCourant(double soldeInitial, double decouvert)
        : base(soldeInitial)
    {
        _decouvert = decouvert;
    }

    public override void Retrait(double montant)
    {
        if (montant <= 0)
            throw new ArgumentException("Le montant doit être positif.");

        if (Solde - montant < -_decouvert)
            throw new InvalidOperationException("Retrait impossible : découvert dépassé.");

        base.Retrait(montant);
    }

    public override void Affichage()
    {
        base.Affichage();
        Console.WriteLine($"DécouvertSolde autorisé : {Decouvert} GNF");
    }
}
