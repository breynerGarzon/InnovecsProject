namespace InnovecsProject.Business.Util.Validation
{
    public static class Validation
    {
        public static bool IsNotNull<T>(T item)
        {
            return (item != null);
        }

        public static bool IsNotZero(int item)
        {
            return (item > 0);
        }
    }
}