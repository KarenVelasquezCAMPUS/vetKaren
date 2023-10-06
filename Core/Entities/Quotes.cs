using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Core.Entities;
public class Quotes : BaseEntity
{
    public int PetId { get; set; }
    public Pet Pet { get; set; }
    public int VetId { get; set; }
    public Vet Vet { get; set; }
    public DateTime Date { get; set; }
    public string Hour { get; set; }
    public string Reason { get; set; }
}
