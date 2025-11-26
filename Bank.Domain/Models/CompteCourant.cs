class CompteCourant : Compte
{
    private double _decouvert;
    public CompteCourant(int code, double solde, double decouvert)
        : base(code, solde)
    {
        _decouvert = decouvert;
    }
}