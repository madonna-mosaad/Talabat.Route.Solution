
namespace Talabat.API.Response
{
    public class ApiResponse
    {
        public int StatusCode {  get; set; }
        public string? Message { get; set; }
        public ApiResponse(int statuscode,string? message=null) 
        {
            StatusCode = statuscode;
            Message = message ?? GetDefaultMessage(statuscode);
        }

        private string? GetDefaultMessage(int statuscode)
        {
            return statuscode switch
            {
                404 => "Not Found",
                401 => "Unauthorized",
                400 => "BadRequest",
                500 => "Server Error",
                _ => "UnKnown"
            };
        }
    }
}
