using Entities.CoreServicesModels.FavouriteModels;

namespace CoreService.Extensions
{
    public static class FavouriteServiceSearchExtension
    {
        public static IQueryable<FavouriteAccountHotelModel> Search(this IQueryable<FavouriteAccountHotelModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<FavouriteAccountHotelModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<FavouriteAccountHotelModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }
    }

    public static class FavouriteServiceSortExtension
    {
        public static IQueryable<FavouriteAccountHotelModel> Sort(this IQueryable<FavouriteAccountHotelModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<FavouriteAccountHotelModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }
    }
}
