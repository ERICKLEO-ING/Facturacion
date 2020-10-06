namespace FacturacionElectronica.Controllers.FactElec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using FacturacionElectronica.Models;
    using FacturacionElectronica.Models.FactElect;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    //using NSwag.Annotations;
    using FacturacionElectronica.Clases.FactElec;
    using Newtonsoft.Json;

    //[OpenApiTag("Facturacion Electronica",
    //            Description = "Apis para proceso de facturacion electronica",
    //            DocumentationDescription = "Link de documentación",
    //            DocumentationUrl = "http://rafaelacosta.net/pais-doc.pdf")]
    [Route("api/[controller]")]
    [ApiController]
    public class FacturacionElectronicaController : ControllerBase
    {
        // GET: api/<FacturacionElectronicaController>
        //[HttpGet]
        //[SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<Documentos>), Description = "Documentos.")]
        //[SwaggerResponse(HttpStatusCode.NotFound, typeof(int), Description = "Documentos not found.")]
        //[SwaggerResponse(HttpStatusCode.InternalServerError, typeof(string), Description = "Internal server error.")]
        //[ProducesResponseType(typeof(IEnumerable<Documentos>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        //public IEnumerable<Documentos> Get(DateTime Fecha)
        //{
        //    using PosDbContext context = new PosDbContext();
        //    var Documentos = context.Documentos //Indicamos la tabla
        //        .Where(x=> x.FechaRegistro.Date == Fecha.Date)
        //        .ToList(); //Seleccionamos el primero
        //    return Documentos;
        //}

        // GET api/<FacturacionElectronicaController>/5
        [HttpGet("{id}")]
        public Documentos Get(Guid id)
        {
            using PosDbContext context = new PosDbContext();
            var Documento = context.Documentos //Indicamos la tabla
                .Where(x => x.IdDocumento == id)
                .First(); //Seleccionamos el primero
            return Documento;
        }

        // GET api/<FacturacionElectronicaController>/5
        [HttpGet]
        public string Get()
        {
            FactElectronica Fact = new FactElectronica();
            //var json = JsonConvert.SerializeObject(Fact.GeneraFacturaBoletaEjemploXML());
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            //return JsonConvert.DeserializeObject<InvoiceType>(json, settings);
            return JsonConvert.SerializeObject(Fact.GeneraFacturaBoletaEjemploXML(),Formatting.None, settings);
        }

        // POST api/<FacturacionElectronicaController>
        [HttpPost]
        public Response<Documentos> Post(InvoiceType Documento)
        {
            FactElectronica Fact = new FactElectronica();
            var Res = Fact.GeneraDocumentoElectronicoXML(Documento);
            if (Res.CodResponse=="0")
            {
                using (PosDbContext context = new PosDbContext())
                {
                    context.Add(Res.Data);
                    //Guardamos los cambios
                    context.SaveChanges();
                }
            }
            Res.Data.IdTramaNavigation.Documentos = null;
            return Res;
        }

        // PUT api/<FacturacionElectronicaController>/5
        //[HttpPut("{id}")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<FacturacionElectronicaController>/5
        //[HttpDelete("{id}")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        //public void Delete(int id)
        //{
        //}
    }
}
