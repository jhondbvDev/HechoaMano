using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechoaMano.Application.Products.Commands
{
    public record CreateProductCommand(
        int FamilyId,
        string FamilyName,
        int RegionId,
        string RegionName,  
        int SubFamilyId,
        string SubFamilyName,
        int FamilyTypeId,
        string FamilyTypeName,
        int SizeId,
        string SizeName,
        decimal SellPrice,
        decimal BuyPrice
        ):IRequest;
}
