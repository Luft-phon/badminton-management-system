namespace BadmintonCourtManagement.Application.DTO.Response
{
    public class ErrorResponse
    {
        public int Status { get; set; }
        public string Title { get; set; }

        public static ErrorResponse NotFound()
        {
            return new ErrorResponse
            {
                Status = 404,
                Title = "Not Found"
            };
        }
        public static ErrorResponse InternalError(int status, string message)
        {
            return new ErrorResponse
            {
                Status = status,
                Title = message
            };
        }
    }
}
