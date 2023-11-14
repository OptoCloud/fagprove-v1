namespace backend.DTOs;

public struct ApiError
{
    public ApiError(string error)
    {
        Error = error;
    }

    public string Error { get; set; }
}
