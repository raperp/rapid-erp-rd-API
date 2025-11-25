using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.UserDTOs;

namespace RapidERP.Application.Interfaces;

public interface IUser : IBase<UserPOST, UserPUT, DeleteDTO> { }
