using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Collections;

namespace Panuon.UI.Silver.Core
{
    public static class GenericsExtension
    {
        #region IsNull
        public static bool IsNull<T>(this T obj)
        {
            return obj == null;
        }
        #endregion

        #region DoIf
        public static void DoIf<T>(this T obj, Func<T, bool> func, Action action)
        {
            if (func(obj))
            {
                action();
            }
        }
        #endregion

        #region Initialize
        public static void Init<T>(this T[] array, T value)
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }

        public static void Init<T>(this T[] array, Func<int,T> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(i);
            }
        }
        #endregion

        #region DeepCopy
        // Testing
        internal static T DeepCopy<T>(this T obj)
        {
            var type = typeof(T);
            ValidateConstructors(type);
            var newObject = Activator.CreateInstance(type);

            foreach(var property in type.GetProperties(BindingFlags.Public).Where(x => x.CanWrite && x.CanRead))
            {
                DeepCopyPropertyValue(obj, ref newObject, property);
            }

            return (T)newObject;
        }
        #endregion

        #region Function
        private static void DeepCopyPropertyValue<T>(T obj, ref T newObj, PropertyInfo propertyInfo)
        {
            var propertyType = propertyInfo.PropertyType;
            if (propertyType.IsValueType || propertyType == typeof(string) || propertyType.IsEnum)
            {
                var value = propertyInfo.GetValue(obj, null);
                propertyInfo.SetValue(newObj, value, null);
            }
            else if(typeof(IEnumerable).IsAssignableFrom(propertyType))
            {
                var enumerable = propertyInfo.GetValue(obj, null);
                var newEnumerable = Activator.CreateInstance(propertyType);

                if (typeof(IList<>).IsAssignableFrom(propertyType))
                {
                    var list = (IList)enumerable;
                    var newList = (IList)newEnumerable;

                }
                else if (typeof(ICollection<>).IsAssignableFrom(propertyType))
                {
                    var collection = (IList)enumerable;
                    var newCollection = (IList)newEnumerable;

                }
                

            }
        }
        private static void ValidateConstructors(Type type)
        {
            var constructos = type.GetConstructors(BindingFlags.Public);
            foreach(var constructor in constructos)
            {
                var parameters = constructor.GetParameters();
                if (parameters == null || parameters.Length == 0)
                    return;
            }
            throw new Exception($"Exception in DeepCopy Method : Type {type.FullName} does not have a parameterless constructor.");
        }
        #endregion
    }
}
