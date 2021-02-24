using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiSupport.Models.DTO;

namespace WebApiSupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string apiBaseUrl;
        public CommentController(IConfiguration configuration)
        {
            _configuration = configuration;

            apiBaseUrl = _configuration.GetValue<string>("WebAPIClientBaseUrl");

        }
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetByReport(int id)
        {

            ObjectResult result = null;
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using var client = new HttpClient(clientHandler);
            using var Response = await client.GetAsync(apiBaseUrl + "comment/comments/"+id);
            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = Ok(JsonConvert.DeserializeObject<List<CommentDTO>>
                    (await Response.Content.ReadAsStringAsync()));
            }
            else
            {
                result = Conflict(Response.RequestMessage);
            }
            return result;

        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> PostComment(CommentDTO comment)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            ObjectResult result = null;
            using HttpClient client = new HttpClient(clientHandler);
            StringContent content = new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8,
                "application/json");
            using (var Response = await client.PostAsync(apiBaseUrl + "comment/add", content))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return Ok(JsonConvert.DeserializeObject<CommentDTO>
                    (await Response.Content.ReadAsStringAsync()));
                }
                else
                {
                    result = Conflict(Response.RequestMessage);
                }
            }
            return result;
        }

        [Route("[action]/{Id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            ObjectResult result = null;
            using var client = new HttpClient();
            using var Response = await client.DeleteAsync(apiBaseUrl + "comment/delete/" + Id);
            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = Ok(1);
            }
            else
            {
                result = Conflict(Response.RequestMessage);
            }
            return result;

        }

        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> Update(CommentDTO comment)
        {
            ObjectResult result = null;
            using HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8,
                "application/json");
            using (var Response = await client.PutAsync(apiBaseUrl + "comment/update", content))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = Ok(1);
                }
                else
                {
                    result = Conflict(Response.RequestMessage);
                }
            }
            return result;
        }
    }
}
