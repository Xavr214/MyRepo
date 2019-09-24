using Examples.Exception;
using System.Globalization;
using static Common.Math;

namespace Examples.Fraction
{
    /// <summary>
    /// Дробь вида M/N
    /// </summary>
    public class Fraction
    {
        public int M { get; set; }
        public int N { get; set; }
        
        public Fraction(int m, int n)
        {
            if (n == 0)
                throw new FractionDivideByZeroException(m);

            M = m;
            N = n;
        }

        public Fraction(int number)
        {
            M = number;
            N = 1;
        }

        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.M * fraction2.N + fraction1.N * fraction2.M, fraction1.N * fraction2.N).Simplify();
        }

        public static Fraction operator +(Fraction fraction, int number)
        {
            return fraction + new Fraction(1, 1);
        }

        public static Fraction operator +(int number, Fraction fraction)
        {
            return fraction + number;
        }

        public static Fraction operator ++(Fraction fraction)
        {
            return fraction + 1;
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.M * fraction2.N - fraction1.N * fraction2.M, fraction1.N * fraction2.N).Simplify();
        }

        public static Fraction operator -(Fraction fraction, int number)
        {
            return fraction - new Fraction(1, 1);
        }

        public static Fraction operator -(int number, Fraction fraction)
        {
            return -(fraction - number);
        }

        public static Fraction operator -(Fraction fraction)
        {
            return new Fraction(-fraction.M, fraction.N);
        }

        public static Fraction operator --(Fraction fraction)
        {
            return fraction - 1;
        }

        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.M * fraction2.M, fraction1.N * fraction2.N).Simplify();
        }

        public static Fraction operator *(Fraction fraction, int number)
        {
            return new Fraction(fraction.M * number, fraction.N).Simplify();
        }

        public static Fraction operator *(int number, Fraction fraction)
        {
            return fraction * number;
        }

        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.M * fraction2.N, fraction1.N * fraction2.M).Simplify();
        }

        public static Fraction operator /(Fraction fraction, int number)
        {
            return new Fraction(fraction.M, fraction.N * number).Simplify();
        }

        public static Fraction operator /(int number, Fraction fraction)
        {
            return number * fraction.Invert();
        }

        public override bool Equals(object obj)
        {
            var that = this.Simplify();
            Fraction objectToCompare = null;

            if (obj is Fraction)
            {
                objectToCompare = (obj as Fraction).Simplify();
            }

            if (obj is int)
            {
                objectToCompare = new Fraction((int)obj);
            }

            if (objectToCompare == null)
                return false;

            return that.M == objectToCompare.M && that.N == objectToCompare.N;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }


        public static bool operator ==(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.Equals(fraction2);
        }

        public static bool operator !=(Fraction fraction1, Fraction fraction2)
        {
            return !(fraction1 == fraction2);
        }

        public static bool operator ==(Fraction fraction1, int number)
        {
            return fraction1.Equals(number);
        }

        public static bool operator !=(Fraction fraction1, int number)
        {
            return !(fraction1 == number);
        }

        public static bool operator ==(int number, Fraction fraction1)
        {
            return fraction1.Equals(number);
        }

        public static bool operator !=(int number, Fraction fraction1)
        {
            return !(fraction1 == number);
        }

        public static bool operator >(Fraction fraction1, Fraction fraction2)
        {
            var lcm = LCM(fraction1.N, fraction2.N);
            var multiplier1 = lcm / fraction1.N;
            var multiplier2 = lcm / fraction2.N;

            return fraction1 * multiplier1 > fraction2 * multiplier2;
        }

        public static bool operator <(Fraction fraction1, Fraction fraction2)
        {
            var lcm = LCM(fraction1.N, fraction2.N);
            var multiplier1 = lcm / fraction1.N;
            var multiplier2 = lcm / fraction2.N;

            return fraction1 * multiplier1 < fraction2 * multiplier2;
        }

        public static bool operator true(Fraction fraction)
        {
            var simplified = fraction.Simplify();
            return simplified.N != 1;
        }

        public static bool operator false(Fraction fraction)
        {
            var simplified = fraction.Simplify();
            return simplified.N == 1;
        }

        public static bool operator &(Fraction fraction1, Fraction fraction2)
        {
            if (fraction1)
                if (fraction2)
                    return true;

            return false;
        }

        public static bool operator |(Fraction fraction1, Fraction fraction2)
        {
            if (fraction1)
                return true;

            if (fraction2)
                return true;

            return false;
        }

        public string ToString(string format = "F2")
        {
            return ((float)(M / N)).ToString(format);
        }

        public static implicit operator int(Fraction fraction)
        {
            return fraction.M / fraction.N;
        }

        public static explicit operator float(Fraction fraction)
        {
            return fraction.M / fraction.N;
        }

        public static implicit operator Fraction(int number)
        {
            return new Fraction(number);
        }

        public static implicit operator Fraction(float number)
        {
            return new Fraction((int)number);
        }

        public int this[int index]
        {
            get { return ToString().Split('.')[1][index]; }
        }
    }
}
