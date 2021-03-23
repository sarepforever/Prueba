using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Entities
{
    public partial class Estado
    {
        public Estado()
        {
            Contratoslaborales = new HashSet<Contratoslaborale>();
        }

        public int Idestado { get; set; }
        public string Nombre { get; set; }
        public string Usuariocreacion { get; set; }
        public DateTime? Fechacreacion { get; set; }

        public virtual ICollection<Contratoslaborale> Contratoslaborales { get; set; }
    }
}
