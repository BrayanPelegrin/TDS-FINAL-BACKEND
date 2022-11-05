namespace TecnoStore.Api
{
    public class ApiResponse
    {
        public bool Success { get; set; } = false;
        public string Mensaje { get; set; } = string.Empty;
        public object? Result { get; set; } = null;
    }
}
