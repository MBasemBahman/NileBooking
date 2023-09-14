using Entities.CoreServicesModels.HotelRoomModels;

namespace CoreService.Extensions
{
    public static class HotelRoomServiceSearchExtension
    {
        public static IQueryable<HotelRoomModel> Search(this IQueryable<HotelRoomModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<HotelRoomModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<HotelRoomModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }

        public static IQueryable<HotelRoomPriceModel> Search(this IQueryable<HotelRoomPriceModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<HotelRoomPriceModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<HotelRoomPriceModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }

        public static IQueryable<RoomFoodTypeModel> Search(this IQueryable<RoomFoodTypeModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<RoomFoodTypeModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<RoomFoodTypeModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }

        public static IQueryable<RoomTypeModel> Search(this IQueryable<RoomTypeModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<RoomTypeModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<RoomTypeModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }
    }

    public static class HotelRoomServiceSortExtension
    {
        public static IQueryable<HotelRoomModel> Sort(this IQueryable<HotelRoomModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<HotelRoomModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

        public static IQueryable<HotelRoomPriceModel> Sort(this IQueryable<HotelRoomPriceModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<HotelRoomPriceModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

        public static IQueryable<RoomFoodTypeModel> Sort(this IQueryable<RoomFoodTypeModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<RoomFoodTypeModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }


        public static IQueryable<RoomTypeModel> Sort(this IQueryable<RoomTypeModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<RoomTypeModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }



    }
}
