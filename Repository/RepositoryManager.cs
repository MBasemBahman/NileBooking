using Repository.DBModels.AccountModels;
using Repository.DBModels.DashboardAdministrationModels;
using Repository.DBModels.LogModels;
using Repository.DBModels.UserModels;
using Repository.DBModels.HotelModels;
using Repository.DBModels.HotelRoomModels;
using Repository.DBModels.BookingModels;
using Repository.DBModels.LocationModels;


namespace Repository
{
    public class RepositoryManager
    {
        private readonly BaseContext _dBContext;

        #region private

        #region Log
        private LogRepository _logRepository;
        #endregion

        #region User
        private UserRepository _userRepository;
        private DeviceRepository _deviceRepository;
        private VerificationRepository _verificationRepository;
        private RefreshTokenRepository _refreshTokenRepository;
        #endregion

        #region Dashboard Administration

        private AdministrationRolePremissionRepository _administrationRolePremissionRepository;
        private DashboardAccessLevelRepository _dashboardAccessLevelRepository;
        private DashboardAdministrationRoleRepository _dashboardAdministrationRoleRepository;
        private DashboardAdministratorRepository _dashboardAdministratorRepository;
        private DashboardViewRepository _dashboardViewRepository;

        #endregion

        #region Account

        private AccountRepository _accountRepository;
        private AccountStateRepository _accountStateRepository;
        private AccountTypeRepository _accountTypeRepository;

        #endregion

        #region Booking
        private BookingRepository _bookingRepository;
        private BookingReviewRepository _bookingReviewRepository;
        private BookingRoomExtraRepository _bookingRoomExtraRepository;
        private BookingRoomRepository _bookingRoomRepository;
        private BookingStateRepository _bookingStateRepository;
        #endregion

        #region Hotel

        private HotelRepository _hotelRepository;
        private HotelAttachmentRepository _hotelAttachmentRepository;
        private HotelFeatureRepository _hotelFeatureRepository;
        private HotelFeatureCategoryRepository _hotelFeatureCategoryRepository;
        private HotelSelectedFeaturesRepository _hotelSelectedFeaturesRepository;
        private HotelExtraPriceRepository _hotelExtraPriceRepository;
        private HotelTypeRepository _hotelTypeRepository;

        #endregion

        #region Hotel Room

        private HotelRoomPriceRepository _hotelRoomPriceRepository;
        private HotelRoomRepository _hotelRoomRepository;
        private RoomFoodTypeRepository _roomFoodTypeRepository;
        private RoomTypeRepository _roomTypeRepository;

        #endregion

        #region Location

        private AreaRepository _areaRepository;
        private CountryRepository _countryRepository;
       
        #endregion



        #endregion

        public RepositoryManager(BaseContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task Save()
        {
            _ = await _dBContext.SaveChangesAsync();
        }

        #region Public

        #region Log
        public LogRepository Log
        {
            get
            {
                _logRepository ??= new LogRepository(_dBContext);
                return _logRepository;
            }
        }
        #endregion

        #region User

        public UserRepository User
        {
            get
            {
                _userRepository ??= new UserRepository(_dBContext);
                return _userRepository;
            }
        }

        public DeviceRepository Device
        {
            get
            {
                _deviceRepository ??= new DeviceRepository(_dBContext);
                return _deviceRepository;
            }
        }


        public VerificationRepository Verification
        {
            get
            {
                _verificationRepository ??= new VerificationRepository(_dBContext);
                return _verificationRepository;
            }
        }


        public RefreshTokenRepository RefreshToken
        {
            get
            {
                _refreshTokenRepository ??= new RefreshTokenRepository(_dBContext);
                return _refreshTokenRepository;
            }
        }

        #endregion

        #region Dashboard Administration

        public AdministrationRolePremissionRepository AdministrationRolePremission
        {
            get
            {
                _administrationRolePremissionRepository ??= new AdministrationRolePremissionRepository(_dBContext);
                return _administrationRolePremissionRepository;
            }
        }

        public DashboardAccessLevelRepository DashboardAccessLevel
        {
            get
            {
                _dashboardAccessLevelRepository ??= new DashboardAccessLevelRepository(_dBContext);
                return _dashboardAccessLevelRepository;
            }
        }

        public DashboardAdministrationRoleRepository DashboardAdministrationRole
        {
            get
            {
                _dashboardAdministrationRoleRepository ??= new DashboardAdministrationRoleRepository(_dBContext);
                return _dashboardAdministrationRoleRepository;
            }
        }

        public DashboardAdministratorRepository DashboardAdministrator
        {
            get
            {
                _dashboardAdministratorRepository ??= new DashboardAdministratorRepository(_dBContext);
                return _dashboardAdministratorRepository;
            }
        }

        public DashboardViewRepository DashboardView
        {
            get
            {
                _dashboardViewRepository ??= new DashboardViewRepository(_dBContext);
                return _dashboardViewRepository;
            }
        }

        #endregion

        #region Account
        public AccountRepository Account
        {
            get
            {
                _accountRepository ??= new AccountRepository(_dBContext);
                return _accountRepository;
            }
        }

        public AccountStateRepository AccountState
        {
            get
            {
                _accountStateRepository ??= new AccountStateRepository(_dBContext);
                return _accountStateRepository;
            }
        }

        public AccountTypeRepository AccountType
        {
            get
            {
                _accountTypeRepository ??= new AccountTypeRepository(_dBContext);
                return _accountTypeRepository;
            }
        }
        #endregion

        #region Booking
        public BookingRepository Booking
        {
            get
            {
                _bookingRepository ??= new BookingRepository(_dBContext);
                return _bookingRepository;
            }
        }

        public BookingReviewRepository BookingReview
        {
            get
            {
                _bookingReviewRepository ??= new BookingReviewRepository(_dBContext);
                return _bookingReviewRepository;
            }
        }

        public BookingRoomRepository BookingRoom
        {
            get
            {
                _bookingRoomRepository ??= new BookingRoomRepository(_dBContext);
                return _bookingRoomRepository;
            }
        }

        public BookingRoomExtraRepository BookingRoomExtra
        {
            get
            {
                _bookingRoomExtraRepository ??= new BookingRoomExtraRepository(_dBContext);
                return _bookingRoomExtraRepository;
            }
        }

        public BookingStateRepository BookingState
        {
            get
            {
                _bookingStateRepository ??= new BookingStateRepository(_dBContext);
                return _bookingStateRepository;
            }
        }
        #endregion

        #region Hotel

        public HotelRepository Hotel
        {
            get
            {
                _hotelRepository ??= new HotelRepository(_dBContext);
                return _hotelRepository;
            }
        }

        public HotelAttachmentRepository HotelAttachment
        {
            get
            {
                _hotelAttachmentRepository ??= new HotelAttachmentRepository(_dBContext);
                return _hotelAttachmentRepository;
            }
        }

        public HotelFeatureRepository HotelFeature
        {
            get
            {
                _hotelFeatureRepository ??= new HotelFeatureRepository(_dBContext);
                return _hotelFeatureRepository;
            }
        }

        public HotelFeatureCategoryRepository HotelFeatureCategory
        {
            get
            {
                _hotelFeatureCategoryRepository ??= new HotelFeatureCategoryRepository(_dBContext);
                return _hotelFeatureCategoryRepository;
            }
        }

        public HotelSelectedFeaturesRepository HotelSelectedFeatures
        {
            get
            {
                _hotelSelectedFeaturesRepository ??= new HotelSelectedFeaturesRepository(_dBContext);
                return _hotelSelectedFeaturesRepository;
            }
        }

        public HotelExtraPriceRepository HotelExtraPrice
        {
            get
            {
                _hotelExtraPriceRepository ??= new HotelExtraPriceRepository(_dBContext);
                return _hotelExtraPriceRepository;
            }
        }

        public HotelTypeRepository HotelType
        {
            get
            {
                _hotelTypeRepository ??= new HotelTypeRepository(_dBContext);
                return _hotelTypeRepository;
            }
        }

        #endregion

        #region Hotel Room

        public HotelRoomPriceRepository HotelRoomPrice
        {
            get
            {
                _hotelRoomPriceRepository ??= new HotelRoomPriceRepository(_dBContext);
                return _hotelRoomPriceRepository;
            }
        }

        public HotelRoomRepository HotelRoom
        {
            get
            {
                _hotelRoomRepository ??= new HotelRoomRepository(_dBContext);
                return _hotelRoomRepository;
            }
        }

        public RoomFoodTypeRepository RoomFoodType
        {
            get
            {
                _roomFoodTypeRepository ??= new RoomFoodTypeRepository(_dBContext);
                return _roomFoodTypeRepository;
            }
        }

        public RoomTypeRepository RoomType
        {
            get
            {
                _roomTypeRepository ??= new RoomTypeRepository(_dBContext);
                return _roomTypeRepository;
            }
        }

        #endregion

        #region Hotel Room

        public AreaRepository Area
        {
            get
            {
                _areaRepository ??= new AreaRepository(_dBContext);
                return _areaRepository;
            }
        }

        public CountryRepository Country
        {
            get
            {
                _countryRepository ??= new CountryRepository(_dBContext);
                return _countryRepository;
            }
        }

        #endregion

        #endregion
    }
}
