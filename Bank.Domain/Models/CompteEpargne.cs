class CompteEpargne : Compte
{
    private double _tauxInteret;
    public CompteEpargne(int code, double solde, double tauxInteret)
        : base(code, solde)
    {
        _tauxInteret = tauxInteret;
    }
    public void calculInteret()
    {
        
    }
    public void maj()
    {
        
    }
}