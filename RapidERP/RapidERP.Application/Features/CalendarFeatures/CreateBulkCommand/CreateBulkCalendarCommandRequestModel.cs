using RapidERP.Application.DTOs.CalendarDTOs;

namespace RapidERP.Application.Features.CalendarFeatures.CreateBulkCommand;

public record CreateBulkCalendarCommandRequestModel(List<CalendarPOST> masterPOSTs);