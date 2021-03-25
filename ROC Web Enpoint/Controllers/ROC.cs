using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROC_Web_Enpoint.Controllers
{
    [Route("")]
    [ApiController]
    public class ROC : ControllerBase
    {
        [HttpPost]
        public byte[] Post()
        {
            var path = Path.Combine("C:\\ROC", $"{DateTime.Now:yyyy-MM-dd HHmmss-fff}.txt");

            byte[] data;
            using (var ms = new MemoryStream(2048))
            {
                Request.Body.CopyToAsync(ms);
                data = ms.ToArray();  // returns base64 encoded string JSON result
            }

            using StreamWriter outputFile10 = new StreamWriter(path);
            outputFile10.Write(Encoding.UTF8.GetString(data));

            return Encoding.UTF8.GetBytes("Success");
        }
    }
}
