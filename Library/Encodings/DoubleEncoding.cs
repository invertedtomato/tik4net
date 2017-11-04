﻿using System;

namespace InvertedTomato.TikLink.Encodings {
    public static class DoubleEncoding {
        public static string EncodeNullable(double? value) {
            if (null == value) {
                return string.Empty;
            }

            return Encode(value.Value);
        }

        public static string Encode(double value) {
            return value.ToString();
        }

        public static double? DecodeNullable(string value) {
            if (null == value) {
                throw new ArgumentNullException(nameof(value));
            }

            if (value == string.Empty) {
                return null;
            }

            return Decode(value);
        }

        public static double Decode(string value) {
            if (null == value) {
                throw new ArgumentNullException(nameof(value));
            }

            return double.Parse(value);
        }
    }
}
