using System;
using System.Drawing;

namespace ExamSys.Util
{
     public class ColorParser
    {
        /// <summary>
        /// Get a System.Color object from the specified hexidecimal code
        /// </summary>
        /// <param name="HexidecimalCode"> The hexidecimal code to convert </param>
        /// <returns>System.Color</returns>
        public static Color GetColorFromHex(string HexidecimalCode)
        {
            RGBValue rgb = GetRBGFromHex(HexidecimalCode);
            return Color.FromArgb(rgb.R, rgb.G, rgb.B);
        }
        /// <summary>
        /// Get the hexidecimal color code for the specified color object
        /// </summary>
        /// <param name="color"> The color object to convert </param>
        /// <returns>System.String</returns>
        public static string GetHexFromColor(Color color)
        {
            string strHex = GetHexFromRGB(color.R.ToString(), color.G.ToString(), color.B.ToString());
            return strHex;
        }
        /// <summary>
        /// Gets the hexidecimal color code from the specified RGB
        /// </summary>
        /// <param name="R"> The value of R </param>
        /// <param name="G"> The value of G </param>
        /// <param name="B"> The value of B </param>
        /// <returns></returns>
        public static string GetHexFromRGB(string R, string G, string B)
        {
            string a, b, c, d, e, f, z;
            a = GetHex(Math.Floor(double.Parse(R) / 16));
            b = GetHex(int.Parse(R) % 16);
            c = GetHex(Math.Floor(double.Parse(G) / 16));
            d = GetHex(int.Parse(G) % 16);
            e = GetHex(Math.Floor(double.Parse(B) / 16));
            f = GetHex(int.Parse(B) % 16);
            z = a + b + c + d + e + f;
            return z;
        }

         public static string PlatformHexBackColor 
         {
             get { return GetHexFromRGB(SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformBackColor)); }
         }

         public static string PlatformHexOptionColor
         {
             get { return GetHexFromRGB(SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformOptionColor)); }
         }

         public static string PlatformHexForeColor
         {
             get { return GetHexFromRGB(SysConfig.SettingsHelper.GetValue(Options.PlatformStyle.PlatformForeColor)); }
         }
         /// <summary>
        /// Gets the hexidecimal color code from the specified RGB
        /// </summary>
        /// <param name="R"> The value of R </param>
        /// <param name="G"> The value of G </param>
        /// <param name="B"> The value of B </param>
        /// <returns></returns>
        public static string GetHexFromRGB(string rgbString)
        {
            string[] rgb = rgbString.Split(',');

            string r =rgb[0];
            string g =rgb[1];
            string b =rgb[2];

            return GetHexFromRGB(r,g,b);
        }
        /// <summary>
        /// A simple RGB structure
        /// </summary>
        public struct RGBValue
        {
            private int iR;
            private int iG;
            private int iB;
            public int R { get { return iR; } set { iR = value; } }
            public int G { get { return iG; } set { iG = value; } }
            public int B { get { return iB; } set { iB = value; } }
        }
        /// <summary>
        /// Gets a ColorConverter.RBGValue object for the specified hexidecimal code
        /// </summary>
        /// <param name="Hexidecimal"> The hexidecimal code to convert </param>
        /// <returns>ColorConverter.RGBValue</returns>
        public static RGBValue GetRBGFromHex(string Hexidecimal)
        {
            char[] arChars = Hexidecimal.Replace("#", "").ToCharArray();
            RGBValue rgb = new RGBValue();
            for (int i = 0; i < arChars.Length; i++)
            {
                switch (i)
                {
                    case 0: { rgb.R = (GetRGB(arChars[i]) * 16) + GetRGB(arChars[i + 1]); } break;
                    case 1: { } break;
                    case 2: { rgb.G = (GetRGB(arChars[i]) * 16) + GetRGB(arChars[i + 1]); } break;
                    case 3: { } break;
                    case 4: { rgb.B = (GetRGB(arChars[i]) * 16) + GetRGB(arChars[i + 1]); } break;
                    case 5: { } break;
                }
            }
            return rgb;
        }
        /// <summary>
        /// Gets the RGB value for the specified character
        /// </summary>
        /// <param name="InChar"> The character to convert </param>
        /// <returns>System.Int32</returns>
        private static int GetRGB(char InChar)
        {
            int Value = 0;
            char Char = InChar.ToString().ToUpper().ToCharArray()[0];
            if (Char == 'A')
            {
                Value = 10;
            }
            else if (Char == 'B')
            {
                Value = 11;
            }
            else if (Char == 'C')
            {
                Value = 12;
            }
            else if (Char == 'D')
            {
                Value = 13;
            }
            else if (Char == 'E')
            {
                Value = 14;
            }
            else if (Char == 'F')
            {
                Value = 15;
            }
            else
            {
                Value = int.Parse(Char.ToString());
            }
            return Value;
        }
        /// <summary>
        /// Returns the hexidecimal character for the specified value
        /// </summary>
        /// <param name="Dec"> The value to convert </param>
        /// <returns>System.String</returns>
        private static string GetHex(double Dec)
        {
            string Value = "";
            if (Dec == 10)
            {
                Value = "A";
            }
            else if (Dec == 11)
            {
                Value = "B";
            }
            else if (Dec == 12)
            {
                Value = "C";
            }
            else if (Dec == 13)
            {
                Value = "D";
            }
            else if (Dec == 14)
            {
                Value = "E";
            }
            else if (Dec == 15)
            {
                Value = "F";
            }
            else
            {
                Value = "" + Dec;
            }
            return Value;
        }
    }
}
