using Entities.CoreServicesModels.HotelModels;

namespace CoreService.Extensions
{
    public static class HotelServiceSearchExtension
    {
        public static IQueryable<HotelAttachmentModel> Search(this IQueryable<HotelAttachmentModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<HotelAttachmentModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<HotelAttachmentModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }

        public static IQueryable<HotelExtraPriceModel> Search(this IQueryable<HotelExtraPriceModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<HotelExtraPriceModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<HotelExtraPriceModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }

        public static IQueryable<HotelFeatureCategoryModel> Search(this IQueryable<HotelFeatureCategoryModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<HotelFeatureCategoryModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<HotelFeatureCategoryModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }

        public static IQueryable<HotelFeatureModel> Search(this IQueryable<HotelFeatureModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<HotelFeatureModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<HotelFeatureModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }


        public static IQueryable<HotelSelectedFeaturesModel> Search(this IQueryable<HotelSelectedFeaturesModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<HotelSelectedFeaturesModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<HotelSelectedFeaturesModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }


        public static IQueryable<HotelModel> Search(this IQueryable<HotelModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<HotelModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<HotelModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }


        public static IQueryable<HotelTypeModel> Search(this IQueryable<HotelTypeModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<HotelTypeModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<HotelTypeModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }

    }

    public static class HotelServiceSortExtension
    {
        public static IQueryable<HotelAttachmentModel> Sort(this IQueryable<HotelAttachmentModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<HotelAttachmentModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

        public static IQueryable<HotelExtraPriceModel> Sort(this IQueryable<HotelExtraPriceModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<HotelExtraPriceModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

        public static IQueryable<HotelFeatureCategoryModel> Sort(this IQueryable<HotelFeatureCategoryModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<HotelFeatureCategoryModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }


        public static IQueryable<HotelFeatureModel> Sort(this IQueryable<HotelFeatureModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<HotelFeatureModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

        public static IQueryable<HotelModel> Sort(this IQueryable<HotelModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<HotelModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

        public static IQueryable<HotelSelectedFeaturesModel> Sort(this IQueryable<HotelSelectedFeaturesModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<HotelSelectedFeaturesModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

        public static IQueryable<HotelTypeModel> Sort(this IQueryable<HotelTypeModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<HotelTypeModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

    }
}
