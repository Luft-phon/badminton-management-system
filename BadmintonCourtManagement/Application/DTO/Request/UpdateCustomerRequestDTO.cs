namespace BadmintonCourtManagement.Application.DTO.Request
{
    public class UpdateCustomerRequestDTO
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public DateTime Dob {  get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
