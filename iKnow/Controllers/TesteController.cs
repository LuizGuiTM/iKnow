using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using iKnow.Models;

namespace iKnow.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            TesteViewModel model = new TesteViewModel();
            return View(model);
        }

        public async Task<IActionResult> PegaQRCodeAsync(TesteViewModel teste)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://3.129.210.114:1026/v2/entities/urn:ngsi-ld:entity:esp_iknow/attrs/qrcode/value");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            teste.QRcode = await response.Content.ReadAsStringAsync();
            return View(teste);

        }
    }
}
