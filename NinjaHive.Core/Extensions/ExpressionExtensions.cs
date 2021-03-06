﻿using System;
using System.Linq.Expressions;
using System.Reflection;

namespace NinjaHive.Core.Extensions
{
    public static class ExpressionExtensions
    {
        public static string GetPropertyNameFromExpression<TModel, TProp>(this Expression<Func<TModel, TProp>> expression)
        {
            var member = GetMemberExpression(expression).Member;

            var prop = member as PropertyInfo;

            if (prop == null)
            {
                //A member expression is only either a property or field
                // If it has made it this far, it's a member expression but isn't a property
                // Must be a field
                var field = member as FieldInfo;
                return field.Name;
            }

            return prop.Name;
        }

        private static MemberExpression GetMemberExpression<TModel, TProp>(Expression<Func<TModel, TProp>> expression)
        {
            var member = expression.Body as MemberExpression;

            if (member == null)
            {
                throw new ArgumentException($"Lambda body '{expression}' is not a MemberExpression");
            }

            return member;
        }
    }
}
