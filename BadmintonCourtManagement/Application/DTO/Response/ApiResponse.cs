using System.Net.NetworkInformation;

namespace BadmintonCourtManagement.Application.DTO.Response
{
    public class ApiResponse<T>
    {
        public int Status {  get; set; }
        public string Title { get; set; }
        public T Data { get; set; }

        public static ApiResponse<T> Success(T data) {
            return new ApiResponse<T>
            {
                Status = 200,
                Title = "Successfull",
                Data = data
            };
        }
    }
}
