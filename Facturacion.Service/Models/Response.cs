namespace FacturacionElectronica.Models
{
    public class Response<T>
    {
        public string CodResponse { get; set; }
        public string Message { get; set; }
        public T  Data { get; set; }
    }

}
