﻿using System.Reflection;
using System.Text;

namespace Entities.Extensions
{
    public static class OrderQueryBuilder
    {
        public static string CreateOrderQuery<T>(string orderByQueryString)
        {
            string[] orderParams = orderByQueryString.Trim().Split(',');
            PropertyInfo[] propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            StringBuilder orderQueryBuilder = new();

            foreach (string param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                {
                    continue;
                }

                string propertyFromQueryName = param.Split(" ")[0];
                PropertyInfo objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                {
                    continue;
                }

                string direction = param.EndsWith(" desc") ? "descending" : "ascending";

                _ = orderQueryBuilder.Append($"{objectProperty.Name} {direction},");
            }

            string orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return orderQuery;
        }
    }
}
