﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using InvertedTomato.TikLink.Encodings;

namespace InvertedTomato.TikLink {
    public static class RecordReflection {
        private class RecordMeta {
            public TikRecordAttribute Attribute { get; set; }
            public List<PropertyMeta> Properties { get; set; } = new List<PropertyMeta>();
        }
        private class PropertyMeta {
            public TikPropertyAttribute Attribute { get; set; }
            public PropertyInfo PropertyInfo { get; set; }
            public Type ValueType { get; set; }
            public TypeInfo ValueTypeInfo { get; set; }
        }
        private static ConcurrentDictionary<Type, RecordMeta> MetaRecords = new ConcurrentDictionary<Type, RecordMeta>();

        public static string GetPath<T>() {
            // Get metadata
            var meta = GetGenerateMeta<T>();

            return meta.Attribute.Path;
        }

        public static void SetProperties<T>(T record, Dictionary<string, string> attributes) {
            if (null == record) {
                throw new ArgumentNullException(nameof(record));
            }
            if (null == attributes) {
                throw new ArgumentNullException(nameof(attributes));
            }

            // Get metadata
            var meta = GetGenerateMeta<T>();

            // Set all properties
            foreach (var property in meta.Properties) {
                if (attributes.TryGetValue(property.Attribute.Name, out var value)) {
                    object v;
                    if (property.ValueType == typeof(string)) {
                        v = value;
                    } else if (property.ValueType == typeof(double)) {
                        v = DoubleEncoding.Decode(value);
                    } else if (property.ValueType == typeof(double?)) {
                        v = DoubleEncoding.DecodeNullable(value);
                    } else if (property.ValueType == typeof(long)) {
                        v = LongEncoding.Decode(value);
                    } else if (property.ValueType == typeof(long?)) {
                        v = LongEncoding.DecodeNullable(value);
                    } else if (property.ValueType == typeof(bool)) {
                        v = BoolEncoding.Decode(value);
                    } else if (property.ValueType == typeof(bool?)) {
                        v = BoolEncoding.DecodeNullable(value);
                    } else if (property.ValueTypeInfo.IsEnum) {
                        if (Nullable.GetUnderlyingType(property.ValueType) == null) {
                            v = EnumEncoding.Decode(value, property.ValueType);
                        } else {
                            v = EnumEncoding.DecodeNullable(value, property.ValueType);
                        }
                    } else {
                        throw new NotSupportedException();
                    }

                    property.PropertyInfo.SetValue(record, v);
                }
            }
        }

        public static Dictionary<string, string> GetProperties<T>(T record) {
            if (null == record) {
                throw new ArgumentNullException(nameof(record));
            }

            // Get metadata
            var meta = GetGenerateMeta<T>();

            // Get all properties
            var output = new Dictionary<string, string>();
            foreach (var properties in meta.Properties) {
                var value = properties.PropertyInfo.GetValue(record);

                var propertyType = properties.GetType();


                output[properties.Attribute.Name] = (string)value;  // TODO: Naieve!!!
            }
            return output;
        }

        public static string ResolveProperty<T>(string name) {
            if (null == name) {
                throw new ArgumentNullException(nameof(name));
            }

            // Get metadata
            var meta = GetGenerateMeta<T>();

            // Get property
            var property = meta.Properties.SingleOrDefault(a => a.PropertyInfo.Name == name);
            if (null == property) {
                throw new KeyNotFoundException();
            }

            // Return field
            return property.Attribute.Name;
        }

        private static RecordMeta GetGenerateMeta<T>() {
            var type = typeof(T);

            // If not in cache...
            if (!MetaRecords.TryGetValue(type, out var meta)) {
                meta = new RecordMeta();

                // Check record attribute
                meta.Attribute = type.GetTypeInfo().GetCustomAttribute<TikRecordAttribute>();
                if (null == meta.Attribute) {
                    throw new ArgumentException("Not decorated with TikRecordAttribute.");
                }

                // Build lookup of property infos
                foreach (var property in type.GetRuntimeProperties()) {
                    var propertyAttribute = property.GetCustomAttribute<TikPropertyAttribute>();
                    if (null == propertyAttribute) {
                        continue;
                    }

                    // Create meta record for property
                    meta.Properties.Add(new PropertyMeta() {
                        Attribute = propertyAttribute,
                        PropertyInfo = property,
                        ValueType = property.PropertyType,
                        ValueTypeInfo = property.PropertyType.GetTypeInfo()
                    });
                }

                // Add to cache
                MetaRecords[type] = meta;
            }

            return meta;
        }
    }
}
