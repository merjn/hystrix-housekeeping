namespace Hystrix.Application.Hasher.Argon
{
    public static class DefaultArgonOptions
    {
        /// <summary>
        /// The assumption here is that all machines running this software is at least
        /// using a quad-core machine. 
        /// </summary>
        public const int Parallelism = 8;
    }
}