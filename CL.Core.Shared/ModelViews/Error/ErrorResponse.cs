using System;

namespace LC.Core.Shared.ModelViews
{
    public class ErrorResponse
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string message { get; set; }

        public ErrorResponse()
        {
            Date = DateTime.Now;
            message = "Erro inesperado."; 
        }
    }
}
