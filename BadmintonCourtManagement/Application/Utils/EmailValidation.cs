using BadmintonCourtManagement.Application.DTO.Request.SendMailRequest;
using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BadmintonCourtManagement.Application.Utils
{
    public class EmailValidation
    {
        public async Task<string> GenerateVerificationCode(Account account)
        {
            using var rng = RandomNumberGenerator.Create();
            var bytes = new byte[4];
            rng.GetBytes(bytes);
            var number = BitConverter.ToUInt32(bytes, 0) % 1000000;

            return number.ToString("D6");
        }

  

    }
}
