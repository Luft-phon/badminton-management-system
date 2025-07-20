namespace BadmintonCourtManagement.Application.DTO.Response.UserResponseDTO
{
    public class GetUserDetailResponseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly? Dob { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Exp { get; set; }
    }
}
