using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BTE.Presentation
{
    public static class DTOBase_ViewModelBaseEx
    {
        public static void OnPropertyChanged<T, TProperty>(this T dtoBase,
            Expression<Func<T, TProperty>> expression) where T : DTOBase
        {
            dtoBase.OnPropertyChanged(dtoBase.GetPropertyName(expression));
        }

        public static void SetField<T, TProperty>(this T dtoBase,
           Expression<Func<T, TProperty>> expression, ref TProperty field, TProperty value) where T : DTOBase
        {
            dtoBase.SetField(dtoBase.GetPropertyName(expression), ref field, value);
        }
        
        public static string GetPropertyName<T, TProperty>(this T owner, Expression<Func<T, TProperty>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                var unaryExpression = expression.Body as UnaryExpression;
                if (unaryExpression != null)
                {
                    memberExpression = unaryExpression.Operand as MemberExpression;
                    if (memberExpression == null)
                        throw new NotImplementedException();
                }
                else
                    throw new NotImplementedException();
            } var propertyName = memberExpression.Member.Name;
            return propertyName;
        }

        //public static bool ValidateProperty<T, TProperty>(this T viewModelBase,
        //    Expression<Func<T, TProperty>> expression, TProperty value) where T : ViewModelBase
        //{
        //    return viewModelBase.ValidateProperty(viewModelBase.GetPropertyName(expression), value);
        //}
    }
}
