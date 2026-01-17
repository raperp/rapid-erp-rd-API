using RapidERP.Application.DTOs.AreaDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapidERP.Application.Features.AreaFeatures.CreateBulkCommand;

public record CreateBulkAreaCommandRequestModel(List<AreaPOST> masterPOSTs);
