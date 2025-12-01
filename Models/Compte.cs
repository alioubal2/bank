namespace bank.Models;

public class Compte
{
    private int _code;
    private double _solde;

    public int Code
    {
        get => _code;
        private set => _code = value;
    }

    public double Solde
    {
        get => _solde;
        private set => _solde = value;
    }

    // Relation : 1 client → 1 compte
    public string ClientNumero { get; set; } = null!;
    public Client Client { get; set; } = null!;

    public Compte(double soldeInitial = 0)
    {
        _solde = soldeInitial;
    }

    private Compte() { }

    public virtual void Depot(double montant)
    {
        if (montant <= 0)
            throw new ArgumentException("Le montant doit être positif.");

        _solde += montant;
    }

    public virtual void Retrait(double montant)
    {
        if (montant <= 0)
            throw new ArgumentException("Le montant doit être positif.");

        _solde -= montant;
    }

    public virtual void Virement(Compte destination, double montant)
    {
        if (destination == null)
            throw new ArgumentNullException(nameof(destination));

        Retrait(montant);
        destination.Depot(montant);
    }

    public void Consulter()
    {
        Console.WriteLine($"Solde du compte {Code} : {_solde} GNF");
    }

    public virtual void Historique()
    {
        // sera géré via OperationService + table Operation
    }

    public virtual void Affichage()
    {
        Console.WriteLine($"Code : {_code}");
        Console.WriteLine($"Solde : {_solde}");
    }
}
