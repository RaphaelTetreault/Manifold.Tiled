namespace Manifold.Tiled
{
    public class Optional<T>
    {
        private T value;

        public T Value
        {
            get => value;
            set => this.value = value;
        }

        public bool Exists => value != null;


        public Optional(T value)
        {
            this.value = value;
        }


        public static implicit operator T(Optional<T> wrapper)
        {
            return wrapper.Value;
        }

        public static implicit operator Optional<T>(T value)
        {
            return new Optional<T>(value);
        }


        //public static Optional<T> operator =(Optional<T> optional, T value)
        //{
        //    optional.value = value;
        //    return optional;
        //}

    }
}
