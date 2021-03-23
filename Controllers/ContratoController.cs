using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.DTOs;
using Prueba.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly pruebatecnicaContext _context;
        private readonly IMapper _mapper;

        public ContratoController(pruebatecnicaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET api/<ContratoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ICollection<GETContratoDTO>>> GetId(int id)
        {
            return await (from s in _context.Contratoslaborales
                          where s.Numerodocumento==id
                          select new GETContratoDTO
                          {
                              tipodocuemnto = s.IdtipodocumentoNavigation.Nombre,
                              numerodocumento = s.Numerodocumento.Value,
                              primerapellido =s.Primerapellido,
                              segundoapellido = s.Segundoapellido,
                              primernombre  = s.Primerapellido,
                              segundonombre = s.Segundonombre,
                              idcontrato = s.Idcontrato,
                              cargo =s.IdcargoNavigation.Nombre,
                              riegolaboral =s.IdarlNavigation.Valor.Value,
                              Fechainicio = s.Fechainicio.Value.ToString("dd/MM/yyyy"),
                              Fechafin = (s.Fechafin!=null)? s.Fechafin.Value.ToString("dd/MM/yyyy"):"No Aplica",
                              Salario =s.Salario.Value,
                          }).ToListAsync();
        }
        // POST api/<ContratoController>/5
        [HttpPost("{id}")]
        public async Task<ActionResult> Post(int id, [FromBody] POSTPeriodoLaboralDTO periodo)
        {
            var contrato = await _context.Contratoslaborales.FirstOrDefaultAsync(s=>s.Numerodocumento==id);

            if (contrato == null)
                return NotFound("numero de documento no encontrado");

            var novedadesnomina = _mapper.Map<Novedadesnomina>(periodo);
            novedadesnomina.Idcontrato = contrato.Idcontrato;
            await _context.AddAsync(novedadesnomina);
            await _context.SaveChangesAsync();
                     
            return Ok();
        }

        // GetAportes api/<ContratoController>/4
        [HttpGet("Aportes/{id}")]
        public async Task<ActionResult<ICollection<GETAportesDTO>>> GetAportes(int id)
        {
            var contrato = await _context.Contratoslaborales.FirstOrDefaultAsync(s => s.Numerodocumento == id);

            if (contrato == null)
                return NotFound("numero de documento no encontrado");

            var valoresSeguridadSocial = new List<GETAportesDTO>();

            var salario = Convert.ToDouble(contrato.Salario.Value);
            valoresSeguridadSocial.Add(new GETAportesDTO()
            {

                aporte = "Salud",
                porcentajeEmpleador = Convert.ToDecimal(12.5),
                valorEmpleador = Convert.ToDecimal(salario * 12.5 / 100.0),
                procentajeTrabajador = Convert.ToDecimal(4.0),
                valorTrabajador = Convert.ToDecimal(salario * 4.0 / 100.0),
            });
            valoresSeguridadSocial.Add(new GETAportesDTO()
            {

                aporte = "Pensión",
                porcentajeEmpleador = Convert.ToDecimal(16.0),
                valorEmpleador = Convert.ToDecimal(salario * 16.0 / 100.0),
                procentajeTrabajador = Convert.ToDecimal(4.0),
                valorTrabajador = Convert.ToDecimal(salario * 4.0 / 100.0),
            });
            return valoresSeguridadSocial;
        }

        // GetAportes api/<ContratoController>/4
        [HttpGet("Salario/{id}")]
        public async Task<ActionResult<GETSalarioDTO>> GetSalario(int id)
        {
            var contrato = await _context.Contratoslaborales.FirstOrDefaultAsync(s => s.Numerodocumento == id);

            if (contrato == null)
                return NotFound("numero de documento no encontrado");

            var valoresSeguridadSocial = new List<GETAportesDTO>();

            var salario = Convert.ToDouble(contrato.Salario.Value);
            var descuento = Convert.ToDecimal(salario * 8 / 100.0);
           
            return new GETSalarioDTO()
            {
                descuentos = descuento,
                salario = contrato.Salario.Value,
                valorPago =  contrato.Salario.Value-descuento,

            };
        }


    }
}
