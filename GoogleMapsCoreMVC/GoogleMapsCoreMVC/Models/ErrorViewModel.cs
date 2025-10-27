namespace GoogleMapsCoreMVC.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        // Propiedad auxiliar: indica si hay un RequestId válido
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
