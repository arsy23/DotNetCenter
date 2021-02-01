namespace DotNetCenter.Core
{
    /// <summary>
    /// The Entity interface
    /// </summary>
    /// <typeparam name="TKey">The Entity Key type</typeparam>
    public interface Entity<TKey>
    {
        /// <summary>
        /// The Entity Identity (ID)
        /// </summary>
        TKey Id { get; }
    }
}