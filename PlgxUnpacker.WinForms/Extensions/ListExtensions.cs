using System.Collections.Generic;
using System.Text;

namespace PlgxUnpacker.Extensions
{
    public static class ListExtensions
    {
        public static string Join(this IList<string> strings, string separator = " ")
        {
            if (strings == null)
            {
                return null;
            }

            if (strings.Count == 0)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < strings.Count; i++)
            {
                stringBuilder.Append(strings[i]);

                if (i != strings.Count - 1)
                {
                    if (separator != null)
                    {
                        stringBuilder.Append(separator);
                    }
                }
            }

            return stringBuilder.ToString();
        }
    }
}
