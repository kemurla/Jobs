using System;

namespace Jobs.Business.Validators
{
    /// <summary>
    /// A validator class for validating common logic.
    /// </summary>
    public static class CommonValidator
    {
        /// <summary>
        /// Throws an ArgumentNullException if the given value is null
        /// </summary>
        public static void ThrowIfNull<T>(T value)
        {
            if(value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }
    }
}
