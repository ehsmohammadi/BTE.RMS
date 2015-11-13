using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

namespace BTE.Presentation
{
    /// <summary>
    /// Base class for all ViewModel classes in the application.
    /// It provides support for property and error change notifications 
    /// and has a DisplayName property.  This class is abstract.
    /// </summary>
    public abstract class ViewModelBase : DTOBase, INotifyPropertyChanged, INotifyDataErrorInfo, IDisposable
    {
        #region Constructor

        protected ViewModelBase()
        {
        }

        #endregion // Constructor

        #region DisplayName

        /// <summary>
        /// Returns the user-friendly name of this object.
        /// Child classes can set this property to a new value,
        /// or override it to determine the value on-demand.
        /// </summary>
        public virtual string DisplayName { get; protected set; }

        #endregion // DisplayName

        #region Debugging Aides

        /// <summary>
        /// Warns the developer if this object does not have
        /// a public property with the specified name. This 
        /// method does not exist in a Release build.
        /// </summary>
        //[Conditional("DEBUG")]
        //[DebuggerStepThrough]
        //public void VerifyPropertyName(string propertyName)
        //{
        //    // Verify that the property name matches a real,  
        //    // public, instance property on this object.
        //    if (TypeDescriptor.GetProperties(this)[propertyName] == null)
        //    {
        //        string msg = "Invalid property name: " + propertyName;

        //        if (this.ThrowOnInvalidPropertyName)
        //            throw new Exception(msg);
        //        else
        //            Debug.Fail(msg);
        //    }
        //}

        /// <summary>
        /// Returns whether an exception is thrown, or if a Debug.Fail() is used
        /// when an invalid property name is passed to the VerifyPropertyName method.
        /// The default value is false, but subclasses used by unit tests might 
        /// override this property's getter to return true.
        /// </summary>
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

        #endregion // Debugging Aides

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion // INotifyPropertyChanged Members

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            this.OnDispose();
        }

        /// <summary>
        /// Child classes can override this method to perform 
        /// clean-up logic, such as removing event handlers.
        /// </summary>
        protected virtual void OnDispose()
        {
        }

#if DEBUG
        /// <summary>
        /// Useful for ensuring that ViewModel objects are properly garbage collected.
        /// </summary>
        ~ViewModelBase()
        {
            string msg = string.Format("{0} ({1}) ({2}) Finalized", this.GetType().Name, this.DisplayName, this.GetHashCode());
            System.Diagnostics.Debug.WriteLine(msg);
        }
#endif

        #endregion // IDisposable Members

        #region INotifyDataErrorInfo Members
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        protected void OnErrorChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private readonly IDictionary<string, IList<string>> _errors = new Dictionary<string, IList<string>>();
        public IEnumerable GetErrors(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                if (_errors.ContainsKey(propertyName))
                {
                    IList<string> propertyErrors = _errors[propertyName];
                    foreach (string propertyError in propertyErrors)
                    {
                        yield return propertyError;
                    }
                }
            }
            yield break;
        }

        public bool HasErrors { get { return _errors.Count > 0; } }

        //protected internal bool ValidateProperty(string propertyName, object value)
        //{
        //    ViewModelBase objectToValidate = this;
        //    var results = new List<ValidationResult>();
        //    bool isValid = Validator.TryValidateProperty(value, new ValidationContext(objectToValidate, null, null) { MemberName = propertyName }, results);
        //    if (isValid)
        //        RemoveErrorsForProperty(propertyName);
        //    else
        //        AddErrorsForProperty(propertyName, results);
        //    OnErrorChanged(propertyName);
        //    return isValid;
        //}

        private void AddErrorsForProperty(string propertyName, IEnumerable<ValidationResult> validationResults)
        {
            RemoveErrorsForProperty(propertyName);
            _errors.Add(propertyName, validationResults.Select(vr => vr.ErrorMessage).ToList());
        }

        private void RemoveErrorsForProperty(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
                _errors.Remove(propertyName);
        }
        #endregion

        protected internal override void OnPropertyChanging<T>(string propertyName, ref T field, T value, out bool changeProperty)
        {
            changeProperty = true;
        }

        protected internal override void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public bool Validate()
        {
            var validationResults = new List<ValidationResult>();
            //ValidationContext context = new ValidationContext(this, null, null);
            //Validator.TryValidateObject(this, context, validationResults, true);
            //this._errors.Clear();
            //foreach (var res in validationResults)
            //{
            //    foreach (var member in res.MemberNames)
            //    {
            //        AddErrorsForProperty(member, new ValidationResult[1] { res });
            //        OnErrorChanged(member);
            //    }
            //}
            return !HasErrors;
        }
    }
}