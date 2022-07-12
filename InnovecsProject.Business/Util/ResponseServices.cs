using InnovecsProject.Model.System;

namespace InnovecsProject.Business.Util
{
    public static class ResponseServices
    {
        public static ResponseDto<T> Successfull<T>(T datosRespuesta)
        {
            return new ResponseDto<T>() { StatusCode = System.Net.HttpStatusCode.OK, Data = datosRespuesta };
        }

        public static ResponseDto<T> BadRequest<T>(string messageError)
        {
            return new ResponseDto<T>() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = messageError };
        }
    }
}