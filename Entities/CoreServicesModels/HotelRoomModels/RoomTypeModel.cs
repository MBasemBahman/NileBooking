using Entities.DBModels.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CoreServicesModels.HotelRoomModels
{
    public class RoomTypeParameters : RequestParameters
    {

    }
    public class RoomTypeModel : LookUpEntity , IColorEntity
    {
        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }
    }
}
