﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GODInventory
{
    public class EncodingUtility
    {
        public static string ConvertShiftJisStringToUtf8(string text )
        {
            // Create two different encodings.
            Encoding shift_jis = Encoding.GetEncoding("shift_jis");
            Encoding utf8 = Encoding.UTF8;

            byte[] utf8_bytes, shift_jis_bytes;
            shift_jis_bytes = shift_jis.GetBytes(text);

            // Perform the conversion from one encoding to the other.
            utf8_bytes = Encoding.Convert(shift_jis, utf8, shift_jis_bytes);

            return utf8.GetString(utf8_bytes);

        }

        public static string ConvertShiftJisToUtf8(byte[] shift_jis_bytes)
        {
            // Create two different encodings.
            Encoding shift_jis = Encoding.GetEncoding("shift_jis");
            Encoding utf8 = Encoding.UTF8;


            // Perform the conversion from one encoding to the other.
            byte[] utf8_bytes = Encoding.Convert(shift_jis, utf8, shift_jis_bytes);

            return utf8.GetString(utf8_bytes);

        }
        public static string ConvertUtf8ToShiftJis(string text)
        {
            // Create two different encodings.
            Encoding shift_jis = Encoding.GetEncoding("shift_jis");
      
            byte[] shift_jis_bytes = ConvertUtf8ToShiftJisBytes( text );
            //返回转换后的字符   
            return shift_jis.GetString(shift_jis_bytes);

        }

        public static byte[] ConvertUtf8ToShiftJisBytes(string text) {
            // generate asn, some filed may be null
            if (text == null)
            {
                text = "";
            }
            // Create two different encodings.
            Encoding shift_jis = Encoding.GetEncoding("shift_jis");
            Encoding utf8 = Encoding.UTF8;

            byte[] utf8_bytes, shift_jis_bytes;
            utf8_bytes = utf8.GetBytes(text);
            shift_jis_bytes = Encoding.Convert(utf8, shift_jis, utf8_bytes);
            return shift_jis_bytes;
        }

    }
}
