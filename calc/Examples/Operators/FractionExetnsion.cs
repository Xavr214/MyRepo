using static Common.Math;

namespace Examples.Fraction
{
    public static class FractionExetnsion
    {
        public static Fraction Simplify(this Fraction source)
        {
            var result = source;
            var gcd = 1;
            while ((gcd = GCD(result.M, result.N)) > 1)
            {
                result.M /= gcd;
                result.N /= gcd;
            }

            return result;
        }

        public static Fraction Invert(this Fraction fraction)
        {
            return new Fraction(fraction.N, fraction.M);
        }
    }
}
