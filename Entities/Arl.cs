using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Entities
{
    public partial class Arl
    {
        public Arl()
        {
            Contratoslaborales = new HashSet<Contratoslaborale>();
        }

        public int Idarl { get; set; }
        public decimal? Valor { get; set; }
        public string Usuariocreacion { get; set; }
        public DateTime? Fechacreacion { get; set; }
        public bool? Habilitado { get; set; }

        public virtual ICollection<Contratoslaborale> Contratoslaborales { get; set; }
    }
}
