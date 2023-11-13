namespace backend.DTOs;

public class ErrorDTO
{
    public ErrorDTO(string error)
    {
        Error = error;
    }

    public string Error { get; set; }
}
