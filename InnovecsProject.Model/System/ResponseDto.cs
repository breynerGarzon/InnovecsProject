using System.Net;

namespace InnovecsProject.Model.System
{
    public class ResponseDto<T>
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }
}