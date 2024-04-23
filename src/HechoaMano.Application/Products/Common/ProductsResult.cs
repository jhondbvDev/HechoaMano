namespace HechoaMano.Application.Products.Common
{
    public record ProductsResult(
        Guid Id,
        string Name,
        string FamilyName,
        string SubFamilyName,
        string RegionName,
        string FamilyTypeName,
        string SizeName,
        decimal SellPrice,
        decimal BuyPrice);
    //{ 
    //    public static ProductsResult Fromwhatever(whatever whatever)
    //    {
    //        return new ProductsResult(
    //                           whatever.Id,
    //                                          whatever.Name,
    //                                                         whatever.Family.Name,
    //                                                                        whatever.SubFamily.Name,
    //                                                                                       whatever.Region.Name,
    //                                                                                                      whatever.FamilyType.Name,
    //                                                                                                                     whatever.Size.Name,
    //                                                                                                                                    whatever.SellPrice,
    //                                                                                                                                                   whatever.BuyPrice
    //                                                                                                                                                              );
    //    }
    //}
}
