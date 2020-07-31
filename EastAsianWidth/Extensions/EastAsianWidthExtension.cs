namespace Kodnix.Character.Extensions
{
    public static class EastAsianWidthExtension
    {
        public static int GetEastAsianWidthLength(this char value)
        {
            return EastAsianWidth.GetLength(value);
        }

        public static int GetEastAsianWidthLength(this string value)
        {
            return EastAsianWidth.GetLength(value);
        }

        public static EastAsianWidthKind GetEastAsianWidthKind(this char value)
        {
            return EastAsianWidth.GetKind(value);
        }

        public static EastAsianString ToEastAsianString(this string value)
        {
            return new EastAsianString(value);
        }

        public static EastAsianChar ToEastAsianChar(this char value)
        {
            return new EastAsianChar(value);
        }
    }
}
