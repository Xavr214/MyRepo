using System;
using System.Runtime.Serialization;

namespace Examples.Exception
{
    [Serializable]
    public class FractionDivideByZeroException : DivideByZeroException
    {
        #region Exception base
        public FractionDivideByZeroException() 
            : base()
        { }

        public FractionDivideByZeroException(string message, System.Exception inner) 
            : base(message, inner)
        { }

        protected FractionDivideByZeroException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
        #endregion

        public DateTime ExceptionOccurs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nominator"></param>
        public FractionDivideByZeroException(string message) : base(message)
        {
            ExceptionOccurs = DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nominator"></param>
        public FractionDivideByZeroException(int nominator) : base("Fraction denominator cannot be euqal to zero")
        {
            ExceptionOccurs = DateTime.Now;
            Data.Add("FractionDeatils", $"{nominator}/0");
        }
    }
}
