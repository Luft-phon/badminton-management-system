using BadmintonCourtManagement.Application.DTO.Request.UserRequest;
using BadmintonCourtManagement.Application.DTO.Response.CustomerResponseDTO;
using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Domain.Interface;
using BadmintonCourtManagement.Infrastructure.Data;
using BadmintonCourtManagement.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace BadmintonCourtManagement.Application.UseCase
{
    public class CustomerUseCase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomerRepo _customerRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerUseCase(ApplicationDbContext context, ICustomerRepo customerRepo, IUnitOfWork unitOfWork)
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
                Phone = user.Phone,
                Email = user.Email,
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
                var account = await _context.Account.FirstOrDefaultAsync(a => a.UserID == dto.UserID);
                if (account == null)
                {
                    return null;
                }
                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.Dob = dto.Dob;
                user.Phone = dto.Phone;
                account.Email = dto.Email;
                _context.Update(account);
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

        public async Task<UserRegistrationRequestDTO> RegisterCustomer(UserRegistrationRequestDTO dto)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var accounts = await _context.Account.AnyAsync(u => u.Email == dto.Email);
                if (accounts == true)
                {
                    return null;
                }
                var user = new User();
                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;   
                user.Phone = dto.Phone;
                user.Role = Domain.Enum.Role.Member;
                user.NotificationID = 1;
                 _context.User.Add(user);

                var account = new Account();
                account.User = user;
                account.CreateAt = DateTime.UtcNow;
                account.Email = dto.Email;
                var passwordHash = new PasswordHasher<Account>().HashPassword(account, dto.Password);
                account.Password = passwordHash;
                _context.Account.Add(account);

                await _context.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                return dto;

            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception("Error registering customer", ex);
            }
        }
    }
}
