using System;
using System.Linq;
using Kodnix.Character.Extensions;

namespace Kodnix.Character
{
    public class EastAsianString
    {
        #region Properties
        public string Value { get; }

        public EastAsianChar[] Characters { get; }

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
        #endregion

        #region Constructor
        public EastAsianString(string value)
        {
            Value = value;
            Characters = value.Select(x => x.ToEastAsianChar()).ToArray();
        }
        #endregion

        #region Public Methods
        public EastAsianString Substring(int startIndex, int length)
        {
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (startIndex > Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            if (startIndex > Length - length)
                throw new ArgumentOutOfRangeException(nameof(length));

            if (length == 0)
                return string.Empty.ToEastAsianString();

            var startPosition = IndexToPosition(startIndex);
            var lengthPosition = LengthToPosition(startPosition, length);

            return new string(Characters[startPosition..lengthPosition]
                .Select(x => x.Value)
                .ToArray()).ToEastAsianString();
        }
        #endregion

        #region Private Methods
        private int IndexToPosition(int index)
        {
            int charLength = 0;

            for (var i = 0; i < Characters.Length; i++)
            {
                charLength += Characters[i].Length;

                if (charLength > index)
                    return i;
            }

            return -1;
        }

        private int LengthToPosition(int startPosition, int length)
        {
            int charLength = 0;

            for (var i = startPosition; i < Characters.Length; i++)
            {
                charLength += Characters[i].Length;

                if (charLength >= length)
                    return i + 1;
            }

            return -1;
        }

        private int LengthToPosition(int length)
        {
            return LengthToPosition(0, length);
        }
        #endregion

        #region Override Methods
        public static implicit operator string(EastAsianString value)
        {
            return value.Value;
        }

        public override string ToString()
        {
            return Value;
        }
        #endregion
    }
}
