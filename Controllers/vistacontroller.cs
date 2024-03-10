using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json; // Necesitas agregar esta referencia
using System.Xml;

namespace Api2.Controllers
{
    [ApiController]
    [Route("usuario/[controller]")]
    public class TuController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public TuController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            // Hacer la solicitud GET a la API1
            var response = await _httpClient.GetAsync("https://localhost:7173/api/libros");

            // Verificar si la solicitud fue exitosa
            if (response.IsSuccessStatusCode)
            {
                // Leer el contenido de la respuesta
                var content = await response.Content.ReadAsStringAsync();

                // Deserializar el contenido a un objeto anónimo
                var responseObject = new { respuesta = new object(), mensaje = "" };
                responseObject = JsonConvert.DeserializeAnonymousType(content, responseObject);

                // Serializar el objeto con formato JSON
                var formattedJson = JsonConvert.SerializeObject(responseObject, Newtonsoft.Json.Formatting.Indented);

                // Devolver el contenido formateado como ActionResult
                return Content(formattedJson, "application/json");
            }
            else
            {
                // Si la solicitud no fue exitosa, devolver el código de estado y la razón
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }

        [HttpGet("{dato}")]
        public async Task<ActionResult> Get(string dato)
        {
            // Hacer la solicitud GET a la API1
            var response = await _httpClient.GetAsync($"https://localhost:7173/api/libros/Busqueda/{dato}");

            // Verificar si la solicitud fue exitosa
            if (response.IsSuccessStatusCode)
            {
                // Leer el contenido de la respuesta
                var content = await response.Content.ReadAsStringAsync();

                // Deserializar el contenido a un objeto anónimo
                var responseObject = new { respuesta = new object(), mensaje = "" };
                responseObject = JsonConvert.DeserializeAnonymousType(content, responseObject);

                // Serializar el objeto con formato JSON
                var formattedJson = JsonConvert.SerializeObject(responseObject, Newtonsoft.Json.Formatting.Indented);

                // Devolver el contenido formateado como ActionResult
                return Content(formattedJson, "application/json");
            }
            else
            {
                // Si la solicitud no fue exitosa, devolver el código de estado y la razón
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }

    }
}
