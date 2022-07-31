using System.Net;

namespace Sis.Estudio.Entity
{
    public class Response
    {
        public string Mensaje { get; set; }
        public object Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
