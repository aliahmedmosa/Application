using Application.DTOs.IdentityDTOs;
using static Application.DTOs.IdentityDTOs.ServiceResponses;

namespace Application.Persistence.Contracts.Identity
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAccount(UserDTO userDTO);
        Task<LoginResponse> LoginAccount(LoginDTO loginDTO);
    }
}
