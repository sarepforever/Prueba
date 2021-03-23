using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Entities
{
    public partial class Contratoslaborale
    {
        public Contratoslaborale()
        {
            Novedadesnominas = new HashSet<Novedadesnomina>();
        }

        public int Idcontrato { get; set; }
        public int? Idestado { get; set; }
        public int? Idarl { get; set; }
        public int? Idcargo { get; set; }
        public int? Idtipodocumento { get; set; }
        public decimal? Numerodocumento { get; set; }
        public string Primerapellido { get; set; }
        public string Segundoapellido { get; set; }
        public string Primernombre { get; set; }
        public string Segundonombre { get; set; }
        public DateTime? Fechainicio { get; set; }
        public DateTime? Fechafin { get; set; }
        public decimal? Salario { get; set; }
        public string Usuariocreacion { get; set; }
        public DateTime? Fechacreacion { get; set; }

        public virtual Arl IdarlNavigation { get; set; }
        public virtual Cargo IdcargoNavigation { get; set; }
        public virtual Estado IdestadoNavigation { get; set; }
        public virtual Tipodocumento IdtipodocumentoNavigation { get; set; }
        public virtual ICollection<Novedadesnomina> Novedadesnominas { get; set; }
    }
}
