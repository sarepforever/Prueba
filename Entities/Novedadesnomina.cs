using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Entities
{
    public partial class Novedadesnomina
    {
        public int Idnovedadnomina { get; set; }
        public int? Idcontrato { get; set; }
        public string Periodolaborado { get; set; }
        public decimal? Horaslaboradas { get; set; }
        public decimal? Horaextradiurna { get; set; }
        public decimal? Horaextranocturna { get; set; }
        public decimal? Horaextradominical { get; set; }
        public decimal? Horaextrafestiva { get; set; }
        public decimal? Descuentos { get; set; }
        public string Usuariocreacion { get; set; }
        public DateTime? Fechacreacion { get; set; }

        public virtual Contratoslaborale IdcontratoNavigation { get; set; }
    }
}
