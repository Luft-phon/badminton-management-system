using BadmintonCourtManagement.Application.DTO.Request.UserRequest;

namespace BadmintonCourtManagement.Infrastructure.TempData
{
    public class VerificationStorage
    {
        private static Dictionary<string, (string Code, UserRegistrationRequestDTO Data, DateTime Expiry)> _store = new();

        public void SaveCode(string email, string code, UserRegistrationRequestDTO data)
        {
            _store[email] = (code, data, DateTime.UtcNow.AddMinutes(5));
        }

        public (bool Found, string Code, UserRegistrationRequestDTO Data)? GetCode(string email)
        {
            if (_store.TryGetValue(email, out var entry) && entry.Expiry > DateTime.UtcNow)
            {
                return (true, entry.Code, entry.Data);
            }
            return null;
        }

        public void Remove(string email)
        {
            _store.Remove(email);
        }
    }
}
