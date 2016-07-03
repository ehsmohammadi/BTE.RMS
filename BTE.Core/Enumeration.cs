using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BTE.Core
{
    public abstract class Enumeration : IComparable
    {
        private  string value;
        private string displayName;

        protected Enumeration()
        {
        }

        protected Enumeration(string displayName, string value)
        {
            this.displayName = displayName;
            this.value = value;
        }

        public string Value
        {
            get { return value; }
        }

        public string DisplayName
        {
            get { return displayName; }
            protected set
            {
                this.displayName = value;

                // Get the static fields on the inheriting type.
                foreach (var field in GetType().GetFields(BindingFlags.Public | BindingFlags.Static))
                {
                    // If the static field is an Enumeration type.
                    var enumeration = field.GetValue(this) as Enumeration;
                    if (enumeration == null)
                    {
                        continue;
                    }

                    // Set the value of this instance to the value of the corresponding static type.
                    if (string.Compare(enumeration.DisplayName, value, true) == 0)
                    {
                        this.value = enumeration.Value;
                        break;
                    }
                }
            }
        }

        public override string ToString()
        {
            return DisplayName;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                //var instance = new T();
                var locatedValue = info.GetValue(null) as T;

                if (locatedValue != null)
                {
                    yield return locatedValue;
                }
            }
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        //public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        //{
        //    var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
        //    return absoluteDifference;
        //}

        public static T FromValue<T>(string value) where T : Enumeration
        {
            var matchingItem = parse<T, string>(value, "value", item => item.Value == value);
            return matchingItem;
        }

        public static T FromDisplayName<T>(string displayName) where T : Enumeration
        {
            var matchingItem = parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);
            return matchingItem;
        }

        private static T parse<T, TK>(TK value, string description, Func<T, bool> predicate) where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
                throw new ApplicationException(message);
            }

            return matchingItem;
        }

        public int CompareTo(object other)
        {
            return Value.CompareTo(((Enumeration)other).Value);
        }

        public static bool operator ==(Enumeration a, Enumeration b)
        {
            if (object.ReferenceEquals(a, b))
            {
                return true;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            var typeMatches = a.GetType().Equals(b.GetType());
            var valueMatches = a.Value.Equals(b.Value);

            return typeMatches && valueMatches;
        }

        public static bool operator !=(Enumeration a, Enumeration b)
        {
            return !(a == b);
        }
    }
}
