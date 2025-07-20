using BadmintonCourtManagement.Application.DTO.Request.SendMailRequest;
using BadmintonCourtManagement.Application.DTO.Request.UserRequest;
using BadmintonCourtManagement.Application.DTO.Response.CustomerResponseDTO;
using BadmintonCourtManagement.Application.DTO.Response.UserResponseDTO;
using BadmintonCourtManagement.Application.Interface;
using BadmintonCourtManagement.Application.Utils;
using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Domain.Interface;
using BadmintonCourtManagement.Infrastructure.Data;
using BadmintonCourtManagement.Infrastructure.TempData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace BadmintonCourtManagement.Application.UseCase
{
    public class CustomerUseCase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomerRepo _customerRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly EmailValidation _emailValidation;
        private readonly VerificationStorage _verificationStorage;

        public CustomerUseCase(ApplicationDbContext context, ICustomerRepo customerRepo, IUnitOfWork unitOfWork, IEmailService emailService, EmailValidation emailValidation, VerificationStorage verificationStorage)
        {
            _context = context;
            _customerRepo = customerRepo;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _emailValidation = emailValidation;
            _verificationStorage = verificationStorage;
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

        public async Task<string> RegisterCustomer(VerificationCodeRequestDTO dto)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                // Check if user enter correct verification code
                var result = _verificationStorage.GetCode(dto.Email);
                if (result is null || !result.Value.Found || result.Value.Code != dto.Code)
                    return null;                

                // Get all request data
                var data = result.Value.Data;

                var user = new User();
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;   
                user.Phone = data.Phone;
                user.Role = Domain.Enum.Role.Member;
                user.NotificationID = 1;
                 _context.User.Add(user);

                var account = new Account();
                account.User = user;
                account.CreateAt = DateTime.UtcNow;
                account.Email = data.Email;
                var passwordHash = new PasswordHasher<Account>().HashPassword(account, data.Password);
                account.Password = passwordHash;
                _context.Account.Add(account);

                var point = new Points();
                point.Status = Domain.Enum.PointStatus.Pending;
                point.Point = 0;
                point.User = user;
                point.TotalRedeem = 0;
                point.ClaimDate = null;
                _context.Points.Add(point);


                await _context.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                _verificationStorage.Remove(dto.Email);
                return "Register Successfully";

            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception("Error registering customer", ex);
            }
        }

        public async Task<GetUserDetailResponseDTO> GetUserDetail(UserDetailRequestDTO dto)
        {
            try
            {
                var user = await _customerRepo.GetUserDetail(dto);

                if (user == null)
                {
                    throw new Exception("Not found");
                }
                var userDetail = new GetUserDetailResponseDTO
                {
                    Email = user.Email,
                    Dob = user.Dob,
                    Exp = user.Exp,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.Phone,
                };
                return userDetail;
            }
            catch (Exception ex) {
                throw;
            }
        }
    }
}
