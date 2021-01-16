namespace DotNetCenter.Core
{
    public interface Entity<TKey>
    {
        TKey Id { get; }
    }
}