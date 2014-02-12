using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Features.Models
{
    public static class MyExtensionMethods
    {
        public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum, Func<Product, bool> selectorParam)
        {
            foreach (Product prod in productEnum)
            {
                if (selectorParam(prod))
                {
                    yield return prod;
                }
            }
        }
    }
}