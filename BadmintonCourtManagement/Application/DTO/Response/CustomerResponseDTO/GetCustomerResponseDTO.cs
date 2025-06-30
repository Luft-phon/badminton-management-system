namespace BadmintonCourtManagement.Application.DTO.Response.CustomerResponseDTO
{
    public class GetCustomerResponseDTO
    {
        public string UserID { get; set; }
        public string FullName { get; set; }
        public string Phone {  get; set; }
        public int TotalBooking { get; set; }
        public DateTime LastBooked { get; set; }
        public string LastCourt { get; set; }
        public string Status { get; set; }
    }
}
