using System;
using bank.Models;

namespace bank.Models;

public class Operation
{
    public int Id { get; set; }

    public string Type { get; set; } = null!; 

    public DateTime Date { get; set; }

    public double Montant { get; set; }

    public int CompteSourceId { get; set; }
    public Compte CompteSource { get; set; } = null!;

    public int? CompteDestinationId { get; set; }
    public Compte? CompteDestination { get; set; }
}
