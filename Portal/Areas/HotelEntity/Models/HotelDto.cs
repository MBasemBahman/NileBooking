﻿using Entities.CoreServicesModels.HotelModels;
using Entities.EnumData;

namespace Portal.Areas.HotelEntity.Models
{
    public class HotelFilter : DtParameters
    {
        [DisplayName("Area")]
        public int Fk_Area { get; set; }

        [DisplayName("Country")]
        public int Fk_Country { get; set; }

        [DisplayName("HotelFeatureCategory")]
        public List<int> Fk_HotelFeatureCategories { get; set; }

        [DisplayName("HotelFeature")]
        public List<int> Fk_HotelFeatures { get; set; }

        [DisplayName("RoomType")]
        public List<int> Fk_RoomTypes { get; set; }

        [DisplayName("RoomFoodType")]
        public List<int> Fk_RoomFoodTypes { get; set; }

        [DisplayName("HotelType")]
        public List<int> Fk_HotelTypes { get; set; }
       
    }
    public class HotelDto : HotelModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }
    }

    public class HotelCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Address))]
        public string Address { get; set; }

        [DisplayName(nameof(ImageUrl))]
        public string ImageUrl { get; set; }

        [DisplayName(nameof(Fk_HotelType))]
        public int Fk_HotelType { get; set; }

        [DisplayName(nameof(Fk_Area))]
        public int? Fk_Area { get; set; }

        [DisplayName("Country")]
        public int Fk_Country { get; set; }

        [DisplayName(nameof(Description))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName(nameof(Rate))]
        public double Rate { get; set; } = 5.0;

        [DisplayName(nameof(IsActive))]
        public bool IsActive { get; set; }

        [DisplayName(nameof(IsRecommended))]
        public bool IsRecommended { get; set; }

        [DisplayName(nameof(Latitude))]
        public double Latitude { get; set; }

        [DisplayName(nameof(Longitude))]
        public double Longitude { get; set; }

        [DisplayName(nameof(Fk_HotelSelectedFeatures))]
        public List<int> Fk_HotelSelectedFeatures { get; set; }

        [DisplayName(nameof(HotelLangs))]
        public List<HotelLangModel> HotelLangs { get; set; }
    }

    public class HotelLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public LanguageEnum Language { get; set; }
    }
}
