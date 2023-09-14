using Entities.CoreServicesModels.LocationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.Extensions
{
    public static class LocationServiceSearchExtension
    {
        public static IQueryable<AreaModel> Search(this IQueryable<AreaModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<AreaModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<AreaModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }

        public static IQueryable<CountryModel> Search(this IQueryable<CountryModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<CountryModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<CountryModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }

    }

    public static class LocationServiceSortExtension
    {
        public static IQueryable<AreaModel> Sort(this IQueryable<AreaModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<AreaModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

        public static IQueryable<CountryModel> Sort(this IQueryable<CountryModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<CountryModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

    }
}
