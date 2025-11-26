using RapidERP.Application.DTOs.MessageModuleDTOs;
using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.Interfaces;

public interface IMessageModule : IBase<MessageModulePOST, MessageModulePUT, DeleteDTO> { }
