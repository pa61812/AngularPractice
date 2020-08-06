using System;
using System.Buffers;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Amazon.S3.Model;
using iTextSharp.xmp.options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FrogJump.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BMIController : ControllerBase
    {

        private readonly ILogger<BMIController> _logger;

        public BMIController(ILogger<BMIController> logger)
        {
            _logger = logger;
        }

        //[HttpPost("CalBMI")]
        //public decimal CalBMI(decimal height, decimal weight)
        //{
        //    decimal result = weight / ((height / 100) * (height / 100));
        //    return result;
        //}

        [HttpPost("CalBMI")]
        public decimal CalBMI(BMIDetial bMI)
        {

            decimal height = bMI.height;
            decimal weight = bMI.weight;
            decimal result = weight / ((height / 100) * (height / 100));
           // var result = bMI.weight + bMI.height;
            return result;
        }
    }
    public class BMIDetial
    {
        [JsonConverter(typeof(IntToStringConverter))]
        public decimal height { get; set; }
        [JsonConverter(typeof(IntToStringConverter))]
        public decimal weight { get; set; }
    }

    public class IntToStringConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                ReadOnlySpan<byte> span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;
                if (Utf8Parser.TryParse(span, out int number, out int bytesConsumed) && span.Length == bytesConsumed)
                {
                    return number;
                }

                if (int.TryParse(reader.GetString(), out number))
                {
                    return number;
                }
            }

            return reader.GetInt32();
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}


