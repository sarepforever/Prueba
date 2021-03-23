using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.DTOs
{
    public class ContratoDTO
    {
    }

    public class GETContratoDTO
    {
        public int idtipodocumento { get; set; }

        public string tipodocuemnto { get; set; }

        public decimal numerodocumento { get; set; }

        public string primerapellido { get; set; }

        public string segundoapellido { get; set; }

        public string primernombre { get; set; }

        public string segundonombre { get; set; }

        public int idcontrato { get; set; }

        public string cargo { get; set; }

        public decimal riegolaboral { get; set; }

        public string Fechainicio { get; set; }

        public string Fechafin { get; set; }

        public decimal Salario { get; set; }
    }

    public class POSTPeriodoLaboralDTO
    {     

        public string Periodolaborado { get; set; }

        public decimal? Horaslaboradas { get; set; }

        public decimal? Horaextradiurna { get; set; }

        public decimal? Horaextranocturna { get; set; }

        public decimal? Horaextradominical { get; set; }

        public decimal? Horaextrafestiva { get; set; }

        public decimal? Descuentos { get; set; }
    }

    public class GETAportesDTO
    {

        public string aporte { get; set; }

        public decimal? porcentajeEmpleador { get; set; }

        public decimal? valorEmpleador { get; set; }

        public decimal? procentajeTrabajador { get; set; }

        public decimal? valorTrabajador { get; set; }

    }
    public class GETSalarioDTO
    {

        public decimal? salario { get; set; }

        public decimal? descuentos { get; set; }

        public decimal? valorPago { get; set; }


    }
}
