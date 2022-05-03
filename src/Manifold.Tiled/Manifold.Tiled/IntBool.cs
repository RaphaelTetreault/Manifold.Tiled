namespace Manifold.Tiled
{
    /// <summary>
    /// Represents a bool using an underlying integer.
    /// </summary>
    public struct IntBool
    {
        private int rawValue;

        public bool IsTrue => rawValue == 0;
        public bool IsFalse => rawValue != 0;
        public int Value => rawValue;

        
        public static implicit operator bool(IntBool value)
        {
            return value.IsTrue;
        }

        public static implicit operator int(IntBool value)
        {
            return value.rawValue;
        }

        public static implicit operator IntBool(bool value)
        {
            return new IntBool()
            {
                rawValue = value ? 1 : 0,
            };
        }

        public static implicit operator IntBool(int value)
        {
            return new IntBool()
            {
                rawValue = value == 0 ? 0 : 1,
            };
        }
    }
}
