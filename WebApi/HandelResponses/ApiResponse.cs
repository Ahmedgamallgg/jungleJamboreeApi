namespace WebApi.HandelResponses
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string? Message { get; set; }

        private string GetDefaultMessageForStatusCode(int code)
        {
            return code switch
            {
                400 => "bad Request",
                401 => "you are not Authorized",
                404 => "Resource not Found",
                500 => "Internal Server Error",
                _ => null
            };
        } 
    }
}
