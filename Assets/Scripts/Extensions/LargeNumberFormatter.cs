namespace Extensions
{
    using System;

    public static class LargeNumberFormatter
    {
        public static string Format(int value)
        {
            string stringValue = value.ToString();
            int length = stringValue.Length;
            string suffix = "";
            int outDigitLength = length % 3;
            int suffixIndex = (length - 1) / 3;

            if (outDigitLength == 0)
            {
                outDigitLength = 3;
            }

            if (suffixIndex > 0)
            {
                suffix = Enum.GetName(typeof(Suffix), suffixIndex);
            }
            
            return stringValue[..outDigitLength] + suffix;
        }
        
        private enum Suffix
        {
            _ = 0,
            K,
            M,
            B
        }
    }
}