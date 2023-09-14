using Entities.CoreServicesModels.BookingModels;

namespace CoreService.Extensions
{
    public static class BookingServiceSearchExtension
    {
        public static IQueryable<BookingModel> Search(this IQueryable<BookingModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<BookingModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<BookingModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }

        public static IQueryable<BookingReviewModel> Search(this IQueryable<BookingReviewModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<BookingReviewModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<BookingReviewModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }

        public static IQueryable<BookingRoomModel> Search(this IQueryable<BookingRoomModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<BookingRoomModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<BookingRoomModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }

        public static IQueryable<BookingRoomExtraModel> Search(this IQueryable<BookingRoomExtraModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<BookingRoomExtraModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<BookingRoomExtraModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }


        public static IQueryable<BookingStateModel> Search(this IQueryable<BookingStateModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<BookingStateModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<BookingStateModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }


    }

    public static class BookingServiceSortExtension
    {
        public static IQueryable<BookingModel> Sort(this IQueryable<BookingModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<BookingModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

        public static IQueryable<BookingReviewModel> Sort(this IQueryable<BookingReviewModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<BookingReviewModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

        public static IQueryable<BookingRoomExtraModel> Sort(this IQueryable<BookingRoomExtraModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<BookingRoomExtraModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }


        public static IQueryable<BookingRoomModel> Sort(this IQueryable<BookingRoomModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<BookingRoomModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

        public static IQueryable<BookingStateModel> Sort(this IQueryable<BookingStateModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<BookingStateModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

    }
}
