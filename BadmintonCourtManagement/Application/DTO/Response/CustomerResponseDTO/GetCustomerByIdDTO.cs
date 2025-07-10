namespace BadmintonCourtManagement.Application.DTO.Response.CustomerResponseDTO
{
    public class GetCustomerByIdDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dob {  get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int TotalBooking { get; set; }
        public int Exp {  get; set; }
        
        public List<BookingHistoryResponseDTO> bookingHistory { get; set; }
    }
}
