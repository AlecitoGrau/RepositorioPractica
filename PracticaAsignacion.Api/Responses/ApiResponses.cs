using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PracticaAsignacion.Api.Responses
{
    public class ApiResponses<T>
    {
        public ApiResponses(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}
