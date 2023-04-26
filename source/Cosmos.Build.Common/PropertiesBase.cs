using System;
using System.Collections.Generic;

namespace Cosmos.Build.Common
{
    public abstract class PropertiesBase
    {
        protected Dictionary<string, string> mPropTable = new Dictionary<string, string>();

        public event EventHandler<PropertyChangingEventArgs> PropertyChanging;
        public event EventHandler<PropertyChangedEventArgs> PropertyChanged;

        public bool IsDirty { get; private set; }

        public Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> clonedTable = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> pair in mPropTable)
            {
                clonedTable.Add(pair.Key, pair.Value);
            }

            return clonedTable;
        }

        /// <summary>
        /// Gets array of project names which are project independent.
        /// </summary>
        public abstract string[] ProjectIndependentProperties { get; }

        public void Reset()
        {
            mPropTable.Clear();
            IsDirty = false;
        }

        public void SetProperty(string name, string value)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(name));

            mPropTable.TryGetValue(name, out var xOldValue);
            mPropTable[name] = value;
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name, xOldValue, value));
            IsDirty = true;
        }

        public void SetProperty(string name, object value)
        {
            SetProperty(name, value.ToString());
        }

        public string GetProperty(string name)
        {
            return GetProperty(name, string.Empty);
        }

        /// <summary>
        /// Get string value of the property.
        /// </summary>
        /// <param name="name">Name of the property.</param>
        /// <param name="default">Default value for the property.</param>
        /// <returns>Vaue of the property with given name.</returns>
        public string GetProperty(string name, string @default)
        {
            string value = @default;
            if (mPropTable.ContainsKey(name) == true)
            {
                value = mPropTable[name];
            }

            return value;
        }

        /// <summary>
        /// Gets typed value of the property.
        /// </summary>
        /// <typeparam name="T">Get property type.</typeparam>
        /// <param name="name">Get name of the property.</param>
        /// <param name="default">Default value for the proeprty.</param>
        /// <returns>Value of the property with given name.</returns>
        public T GetProperty<T>(string name, T @default) where T : struct
        {
            T value = @default;
            if (mPropTable.ContainsKey(name) == true)
            {
                string stringValue = mPropTable[name];
                Type valueType = typeof(T);
                string valueTypeName = valueType.Name;

                if (valueType.IsEnum)
                {
                    value = EnumValue.Parse(stringValue, @default);
                }
                else
                {
                    switch (valueTypeName)
                    {
                        case "Short":
                        case "Int16":
                            if (short.TryParse(stringValue, out short newValueShort))
                            {
                                value = (T)(object)newValueShort;
                            }
                            break;
                        case "Integer":
                        case "Int32":
                            if (int.TryParse(stringValue, out int newValueInt))
                            {
                                value = (T)(object)newValueInt;
                            }
                            break;
                        case "Long":
                        case "Int64":
                            if (long.TryParse(stringValue, out long newValueLong))
                            {
                                value = (T)(object)newValueLong;
                            }
                            break;
                        case "Boolean":
                            if (bool.TryParse(stringValue, out bool newValueBool))
                            {
                                value = (T)(object)newValueBool;
                            }
                            break;
                        case "UShort":
                        case "UInt16":
                            if (ushort.TryParse(stringValue, out ushort newValueUShort))
                            {
                                value = (T)(object)newValueUShort;
                            }
                            break;
                        case "UInteger":
                        case "UInt32":
                            if (uint.TryParse(stringValue, out uint newValueUInt) == true)
                            {
                                value = (T)(object)newValueUInt;
                            }
                            break;
                        case "ULong":
                        case "UInt64":
                            if (ulong.TryParse(stringValue, out ulong newValueULong) == true)
                            {
                                value = (T)(object)newValueULong;
                            }
                            break;
                        default:
                            throw new ArgumentException("Unsupported value type.", nameof(T));
                    }
                }
            }

            return value;
        }

    }
}