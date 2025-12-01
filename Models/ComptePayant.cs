namespace bank.Models;

public class ComptePayant : Compte
{
    private const double _fraisOperation = 15;

    public double FraisOperation => _fraisOperation;

    public ComptePayant(double soldeInitial = 0)
        : base(soldeInitial)
    {
    }

    private ComptePayant() { }

    public override void Depot(double montant)
    {
        if (montant <= 0)
            throw new ArgumentException("Le montant doit être positif.");

        double net = montant - _fraisOperation;

        if (net <= 0)
            throw new InvalidOperationException(
                "Le montant est insuffisant pour couvrir les frais de 15 GNF.");

        base.Depot(net);
    }

    public override void Retrait(double montant)
    {
        if (montant <= 0)
            throw new ArgumentException("Le montant doit être positif.");

        double total = montant + _fraisOperation;

        if (Solde < total)
            throw new InvalidOperationException("Solde insuffisant pour couvrir le retrait + frais.");

        base.Retrait(total);
    }

    public override void Affichage()
    {
        base.Affichage();
        Console.WriteLine($"Frais par opération : {_fraisOperation} GNF");
    }
}
