using Entities.DBModels.AccountModels;
using Entities.DBModels.HotelModels;

namespace Entities.CoreServicesModels.FavouriteModels;

public class FavouriteAccountHotelParameters : RequestParameters
{
    public int Fk_Account { get; set; }
    public int Fk_Hotel { get; set; }
}

public class FavouriteAccountHotelModel : BaseEntity
{
    [ForeignKey(nameof(Account))]
    [DisplayName(nameof(Account))]
    public int Fk_Account { get; set; }
    
    [DisplayName(nameof(Account))]
    public Account Account { get; set; }
    
    [ForeignKey(nameof(Hotel))]
    [DisplayName(nameof(Hotel))]
    public int Fk_Hotel { get; set; }
    
    [DisplayName(nameof(Hotel))]
    public Hotel Hotel { get; set; }
}