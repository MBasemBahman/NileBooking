using CoreService.Logic;

namespace CoreService
{
    public class UnitOfWork
    {
        private readonly RepositoryManager _repository;
        private UserService _userService;
        private LogServices _logServices;
        private DashboardAdministrationServices _dashboardAdministrationServices;
        private AccountServices _accountServices;
        private HotelServices _hotelServices;
        private LocationServices _locationServices;
        private BookingServices _bookingServices;
        private HotelRoomServices _hotelRoomServices;

        public UnitOfWork(RepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task Save()
        {
            await _repository.Save();
        }

        public LogServices Log
        {
            get
            {
                _logServices ??= new LogServices(_repository);
                return _logServices;
            }
        }
        public UserService User
        {
            get
            {
                _userService ??= new UserService(_repository);
                return _userService;
            }
        }

        public DashboardAdministrationServices DashboardAdministration
        {
            get
            {
                _dashboardAdministrationServices ??= new DashboardAdministrationServices(_repository);
                return _dashboardAdministrationServices;
            }
        }


        public AccountServices Account
        {
            get
            {
                _accountServices ??= new AccountServices(_repository);
                return _accountServices;
            }
        }

        public HotelServices Hotel
        {
            get
            {
                _hotelServices ??= new HotelServices(_repository);
                return _hotelServices;
            }
        }

        public LocationServices Location
        {
            get
            {
                _locationServices ??= new LocationServices(_repository);
                return _locationServices;
            }
        }

        public HotelRoomServices HotelRoom
        {
            get
            {
                _hotelRoomServices ??= new HotelRoomServices(_repository);
                return _hotelRoomServices;
            }
        }

        public BookingServices Booking
        {
            get
            {
                _bookingServices ??= new BookingServices(_repository);
                return _bookingServices;
            }
        }


    }
}