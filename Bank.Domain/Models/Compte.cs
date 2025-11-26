class Compte
{
    protected int _code;
    protected double _solde;

    public Compte(int code, double solde)
    {
        _code = code;
        _solde = solde;
    }
    public void affichage()
    {
        Console.WriteLine($"Votre code est {_code}");
        Console.WriteLine($"Votre solde est {_solde}");
    }
    public int getCode()
    {
        return _code;
    }
    public double getSolde()
    {
        return _solde;
    }
    public void depot(double montant)
    {
        
    }
    public void retrait(double montant)
    {
        
    }
    public void virement(double montant)
    {
        
    }
    public void consulter(double montant)
    {
        
    }
    public void historique()
    {
        
    }
}