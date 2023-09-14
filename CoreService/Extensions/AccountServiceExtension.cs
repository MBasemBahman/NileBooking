using Entities.CoreServicesModels.AccountModels;

namespace CoreService.Extensions
{
    public static class AccountServiceSearchExtension
    {
        public static IQueryable<AccountModel> Search(this IQueryable<AccountModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<AccountModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<AccountModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }

        public static IQueryable<AccountStateModel> Search(this IQueryable<AccountStateModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<AccountStateModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<AccountStateModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }

        public static IQueryable<AccountTypeModel> Search(this IQueryable<AccountTypeModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<AccountTypeModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<AccountTypeModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }

    }

    public static class AccountServiceSortExtension
    {
        public static IQueryable<AccountModel> Sort(this IQueryable<AccountModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<AccountModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

        public static IQueryable<AccountTypeModel> Sort(this IQueryable<AccountTypeModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<AccountTypeModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

        public static IQueryable<AccountStateModel> Sort(this IQueryable<AccountStateModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<AccountStateModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

    }
}
