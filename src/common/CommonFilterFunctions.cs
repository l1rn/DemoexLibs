using System.Linq.Expressions;

namespace UsefullLibs.src.common
{
    internal class CommonFilterFunctions
    {
        private List<T> FilterBy<T>
            (
                ComboBox cb,
                string allParameter,
                IQueryable<T> query,
                Expression<Func<T, string>> selector)
        {
            string filteredText = cb.Text;
            if (allParameter == filteredText)
                return query.ToList();

            var parameter = selector.Parameters[0];

            var body = Expression.Equal(
                selector.Body,
                Expression.Constant(filteredText)
            );

            var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
            return query.Where(lambda).ToList();
        }
    }
}
