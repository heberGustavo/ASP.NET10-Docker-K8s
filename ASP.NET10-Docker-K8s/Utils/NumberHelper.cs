namespace ASP.NET10_Docker_K8s.Utils
{
    public class NumberHelper
    {
        public static bool IsNumeric(string strNumber)
        {
            decimal decimalValue;

            bool isNumber = decimal.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalValue
            );

            return isNumber;
        }

        public static decimal ConvertDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalValue
            ))
            {
                return decimalValue;
            }

            return 0;
        }

        public static double ConvertDouble(string strNumber)
        {
            double doubleValue;

            if (double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out doubleValue
            ))
            {
                return doubleValue;
            }

            return 0;
        }
    }
}
