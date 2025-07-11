using Azure.Core;
using BadmintonCourtManagement.Application.DTO.Request.SendMailRequest;
using BadmintonCourtManagement.Application.DTO.Request.UserRequest;
using BadmintonCourtManagement.Application.Interface;
using BadmintonCourtManagement.Application.Utils;
using BadmintonCourtManagement.Infrastructure.Data;
using BadmintonCourtManagement.Infrastructure.TempData;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

namespace BadmintonCourtManagement.Application.Service
{
    public class EmailService : IEmailService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly EmailValidation _emailValidation;
        private readonly VerificationStorage _verificationStorage;

        public EmailService(IConfiguration configuration, EmailValidation emailValidation, ApplicationDbContext applicationDbContext, VerificationStorage verificationStorage)
        {
            _configuration = configuration;
            _emailValidation = emailValidation;
            _context = applicationDbContext;
            _verificationStorage = verificationStorage;
        }
        public async Task<string> SendContactUsEmailAsync(ContactUsRequestDTO request)
        {
            string response = "";

            try
            {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["Smtp:From"], "Badminton Westminster Court"),
                Subject = $"New Message From Contact Us: {request.Title}",
                Body = $"<strong>Name:</strong> {request.Fullname}<br/>" +
                        $"<strong>Email:</strong> {request.Email}<br/>" +
                         $"<strong>Message:</strong><br/>{request.Message}",
                IsBodyHtml = true,
            };

                mailMessage.To.Add("thanhphongchupanh@gmail.com");
                await smtpClient.SendMailAsync(mailMessage);
                response = "Email sent successfully.";
            }
            catch (SmtpException ex)
            {
                return response = $"Email is invalid: {ex.Message}";
            }

            return response;
        }

        public async Task<string> SendVerificationEmail(UserRegistrationRequestDTO dto)
        {
            string response = "";
            // Check if the email already exists
            var accounts = await _context.Account.AnyAsync(u => u.Email == dto.Email);
            if (accounts == true)
            {
                return null;
            }
            var account = await _context.Account.FirstOrDefaultAsync(u => u.Email == dto.Email);
            var code = await _emailValidation.GenerateVerificationCode(account);
            _verificationStorage.SaveCode(dto.Email, code, dto);

            // Đọc nội dung template HTML
            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Application/Templates", "VerificationEmail.html");
            var html = await File.ReadAllTextAsync(templatePath);

            // Thay thế các placeholder bằng nội dung thật
            html = html.Replace("{{email}}", dto.Email)
                       .Replace("{{code}}", code);
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]),
                    EnableSsl = true,
                };
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_configuration["Smtp:From"], "Badminton Westminster Court"),
                    Subject = $"Verify your email address",
                    Body = html,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(dto.Email);
                await smtpClient.SendMailAsync(mailMessage);
                response = "Email sent successfully.";
            }
            catch (SmtpException ex)
            {
                return response = $"Email is invalid: {ex.Message}";
            }

            return response;
        }
    }
}
