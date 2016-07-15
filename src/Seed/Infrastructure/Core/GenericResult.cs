namespace AspNetCoreAngular2Seed.Infrastructure.Core
{
    /// <summary>
    /// A class to serialize generic success/fail message for ajax requests from Angular
    /// </summary>
    public class GenericResult
    {
        /// <summary>
        /// was the request successfull?
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Success/fail message optionally
        /// </summary>
        public string Message { get; set; }
    }
}
