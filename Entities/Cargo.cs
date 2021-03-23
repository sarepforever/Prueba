using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Entities
{
    public partial class Cargo
    {
        public Cargo()
        {
            Contratoslaborales = new HashSet<Contratoslaborale>();
        }

        public int Idcargo { get; set; }
        public string Nombre { get; set; }
        public string Usuariocreacion { get; set; }
        public DateTime? Fechacreacion { get; set; }

        public virtual ICollection<Contratoslaborale> Contratoslaborales { get; set; }
    }
}
