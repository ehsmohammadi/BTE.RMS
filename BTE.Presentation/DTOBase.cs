using System.Collections.Generic;

namespace BTE.Presentation
{
    public abstract class DTOBase
    {
        protected internal virtual void OnPropertyChanging<T>(string propertyName, ref T field, T value, out bool changeProperty)
        {
            changeProperty = true;
        }
        protected internal virtual void OnPropertyChanged(string propertyName)
        { }
        
        protected internal void SetField<T>(string propertyName, ref T field, T value)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return;
            var changeProperty = false;
            OnPropertyChanging(propertyName, ref field, value, out changeProperty);
            if(!changeProperty) return;
            field = value;
            OnPropertyChanged(propertyName);
        }

    }
}
