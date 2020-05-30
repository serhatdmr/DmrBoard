namespace DmrBoard.Core.Interfaces
{
    public interface ICurrentUserService
    {
        string Name { get; }
        string UserId { get; }
        bool IsAuthenticated();
    }
}
