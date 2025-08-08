using BadmintonCourtManagement.Domain.Enum;

namespace BadmintonCourtManagement.Application.DTO.Request.UserRequest
{
    public class UpdateCustomerRequestDTO
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public DateOnly Dob {  get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public AccountStatus Status { get; set; }
    }
}
