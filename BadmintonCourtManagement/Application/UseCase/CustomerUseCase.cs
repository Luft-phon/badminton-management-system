using BadmintonCourtManagement.Application.DTO.Request;
using BadmintonCourtManagement.Application.DTO.Response.CustomerResponseDTO;
using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Infrastructure.Data;
using BadmintonCourtManagement.Infrastructure.Repository;
using Microsoft.Data.SqlClient;
using System.Numerics;

namespace BadmintonCourtManagement.Application.UseCase
{
    public class CustomerUseCase
    {
        private readonly ApplicationDbContext _context;
        private readonly CustomerRepo _customerRepo;
        private readonly UnitOfWork _unitOfWork;

        public CustomerUseCase(ApplicationDbContext context, CustomerRepo customerRepo, UnitOfWork unitOfWork)
        {
            _context = context;
            _customerRepo = customerRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetCustomerResponseDTO>> GetAllCustomers(int pageNumber, int pageSize)
        {
            var result = new List<GetCustomerResponseDTO>();
            var customer = await _customerRepo.GetAllCustomers();
            result.AddRange(customer);

            return result
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }


        public async Task<GetCustomerByIdDTO> GetCustomerById(int id)
        {
            var user = await _customerRepo.GetCustomerById(id);
            if (user == null)
            {
                return null;
            }         
            var bookingsHistory = await _customerRepo.GetCustomerBookingHistory(id);
            var dto = new GetCustomerByIdDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Dob = user.Dob,
                Email = user.Email,
                Phone = user.Phone,
                TotalBooking = user.TotalBooking,
                Exp = user.Exp,
                bookingHistory = bookingsHistory.Select(b => new BookingHistoryResponseDTO
                {
                    BookedDate = b.BookedDate,
                    StartTime = b.StartTime,
                    EndTime = b.EndTime,
                    CourtName = b.CourtName,
                    Status = b.Status
                }).ToList()
            };
            return dto;
        }

        public async Task<UpdateCustomerRequestDTO> UpdateCustomerById(UpdateCustomerRequestDTO dto)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var user = await _context.User.FindAsync(dto.UserID);
                if (user == null)
                {
                    return null;
                }

                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.Dob = dto.Dob;
                user.Email = dto.Email;
                user.Phone = dto.Phone;
                _context.Update(user);
                await _context.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                return dto;
            } catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception("Error updating customer", ex);
            }
           
        }
    }
}
