using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BTE.Core;

public class CastleWindsorModelBiner : DefaultModelBinder
{
    protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
    {
        // fallback to the type's default constructor
        Type typeToCreate = modelType;

        // we can understand some collection interfaces, e.g. IList<>, IDictionary<,>
        if (modelType.IsGenericType)
        {
            Type genericTypeDefinition = modelType.GetGenericTypeDefinition();
            if (genericTypeDefinition == typeof(IDictionary<,>))
            {
                typeToCreate = typeof(Dictionary<,>).MakeGenericType(modelType.GetGenericArguments());
            }
            else if (genericTypeDefinition == typeof(IEnumerable<>) || genericTypeDefinition == typeof(ICollection<>) || genericTypeDefinition == typeof(IList<>))
            {
                typeToCreate = typeof(List<>).MakeGenericType(modelType.GetGenericArguments());
            }
        }

        try
        {
            if (ServiceLocator.Current.IsRegistered(typeToCreate))
                return ServiceLocator.Current.GetInstance(typeToCreate);
            return Activator.CreateInstance(typeToCreate);
        }
        catch (MissingMethodException exception)
        {
            // Ensure thrown exception contains the type name.  Might be down a few levels.
            //MissingMethodException replacementException =
            //    TypeHelpers.EnsureDebuggableException(exception, typeToCreate.FullName);
            if (exception != null)
            {
                throw exception;
            }

            throw;
        }
    }
}
