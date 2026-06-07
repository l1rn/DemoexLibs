using System.Linq.Expressions;

namespace UsefulLibs.src.common
{
    public class CommonFilterFunctions
    {
        // usage
        //
        public IQueryable<T> FilterBy<T>
            (
                string filterText,
                string allParameter,
                IQueryable<T> query,
                Expression<Func<T, string>> selector)
        {
            if (allParameter == filterText)
                return query;

            var parameter = selector.Parameters[0];

            var body = Expression.Equal(
                selector.Body,
                Expression.Constant(filterText)
            );

            var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
            return query.Where(lambda);
        }

        public IQueryable<T> SearchAllFields<T>(
        IQueryable<T> query,
        string searchText
    )
        {
            if (string.IsNullOrEmpty(searchText))
                return query;

            var parameter = Expression.Parameter(typeof(T), "x");
            Expression combinedBody = null;

            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string), typeof(StringComparison) });
            var searchConstant = Expression.Constant(searchText, typeof(string));
            var comparisonConstant = Expression.Constant(StringComparison.OrdinalIgnoreCase);

            var stringProperties = typeof(T)
                .GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(string));

            foreach (var prop in stringProperties)
            {
                var propertyAccess = Expression.Property(parameter, prop);
                var containsCall = Expression.Call(propertyAccess, containsMethod, searchConstant, comparisonConstant);

                var nullConstant = Expression.Constant(null, typeof(string));
                var isNotNull = Expression.NotEqual(propertyAccess, nullConstant);

                var safeConstainsExpression = Expression.AndAlso(isNotNull, containsCall);
                if (combinedBody == null)
                {
                    combinedBody = safeConstainsExpression;
                }
                else
                {
                    combinedBody = Expression.OrElse(combinedBody, safeConstainsExpression);
                }
            }

            if (combinedBody == null)
                return query;
            var lambda = Expression.Lambda<Func<T, bool>>(combinedBody, parameter);
            return query.Where(lambda);
        }

        public IQueryable<T> SortBy<T, TKey>
            (
                IQueryable<T> query,
                Expression<Func<T, TKey>> selector,
                bool ascending = true
            )
        {
            return ascending
                ? query.OrderBy(selector)
                : query.OrderByDescending(selector);
        }
    }
}
