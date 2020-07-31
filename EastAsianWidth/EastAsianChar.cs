using Kodnix.Character.Extensions;

namespace Kodnix.Character
{
    public class EastAsianChar
    {
        #region Properties
        public char Value { get; }

        public int Length
        {
            get
            {
                if (_length == null)
                    _length = Value.GetEastAsianWidthLength();

                return _length.Value;
            }
        }

        private int? _length;

        public EastAsianWidthKind Kind
        {
            get
            {
                if (_kind == null)
                    _kind = Value.GetEastAsianWidthKind();

                return _kind.Value;
            }
        }

        private EastAsianWidthKind? _kind;
        #endregion

        #region Constructor
        public EastAsianChar(char value)
        {
            Value = value;
        }
        #endregion

        #region Override Methods
        public static implicit operator char(EastAsianChar value)
        {
            return value.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
        #endregion
    }
}
