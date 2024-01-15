using Entities.DBModels.AccountModels;
using Entities.DBModels.HotelModels;

namespace Entities.DBModels.FavouriteModels;

public class FavouriteAccountHotel : BaseEntity
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