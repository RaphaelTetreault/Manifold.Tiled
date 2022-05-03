namespace Manifold.Tiled
{
    /// <summary>
    /// Extensions for the `IUniquelyIdentifiable` interface.
    /// </summary>
    public static class IUniquelyIdentifiableExtensions
    {
        /// <summary>
        /// Indicates if the identifiable is valid, initialized.
        /// </summary>
        /// <param name="identifiable">The identifiable to validate.</param>
        /// <returns>
        /// Returns true if the ID "is at least 1", as per Tiled's description.
        /// </returns>
        public static bool IsValidID(this IUniquelyIdentifiable identifiable)
        {
            return identifiable.ID > 0;
        }
    }
}
