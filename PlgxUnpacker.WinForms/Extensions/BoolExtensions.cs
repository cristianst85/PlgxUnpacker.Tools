namespace PlgxUnpacker.Extensions
{
    public static class BoolExtensions
    {
        public static bool IsTrue(this bool? value)
        {
            return value == true;
        }

        public static bool IsFalse(this bool? value)
        {
            return value == false;
        }
    }
}
