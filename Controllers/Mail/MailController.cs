using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GestionDeCitas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionDeCitas.Controllers
{
    [Route("[controller]")]
    public class MailController : Controller
    {
       [HttpPost]
        public async void EnviarCorreo()
        {
            try{
                // URL de destino para la solicitud POST
                string url = "https://api.mailersend.com/v1/email";

                // Token de autorización para la solicitud POST
                string jwtToken = "mlsn.f5d7fa8ee08bbca34247ca5131c7bd825fa15d63e1e854ec7cb02d32ad150208";

                // Crear un objeto EmailMessage para contener los datos del mensaje de correo electrónico
                var emailMessage = new Email
                {
                    from = new From { email = "cosa@trial-pq3enl60088l2vwr.mlsender.net" },
                        to = new[]
                    {
                        new To { email = "davidmonterrosa52@gmail.com" }
                    },
                    subject = "David Monterrosa",
                    text = "Greetingsfromtheteam,yougotthismessagethroughMailerSend.",
                    html = "hey toca melo?"
                };

            // Serializar el objeto EmailMessage en formato JSON
            string jsonBody = JsonSerializer.Serialize(emailMessage);

            // Crear un objeto HttpClient para realizar la solicitud HTTP
            using (HttpClient client = new HttpClient())
            {
                // Configurar el encabezado Content-Type para indicar que el cuerpo es JSON
                client.DefaultRequestHeaders.Add("ContentType", "Application/Json");
                // Configurar el encabezado Authorization para indicar el token de autorización
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");

                // Crear el contenido de la solicitud POST como StringContent
                StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                // Realizar la solicitud POST a la URL especificada
                HttpResponseMessage response = await client.PostAsync(url, content);

                // Verificar si la solicitud fue exitosa (código de estado 200-299)
                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta como una cadena
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Respuesta del servidor:");
                    Console.WriteLine(responseBody);
                }
                else
                {
                    // Si la solicitud no fue exitosa, mostrar el código de estado
                    Console.WriteLine($"La solicitud falló con el código de estado: {response.StatusCode}");
                }
                }
            }
            catch(Exception e){
                Console.WriteLine(e);
            }

        }
    }
}