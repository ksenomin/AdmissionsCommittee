namespace AdmissionComitte.Web.Models;

public class ErrorViewModel
{
    /// <summary>
    /// Идентификатор запроса
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// Показать идентификатор
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
