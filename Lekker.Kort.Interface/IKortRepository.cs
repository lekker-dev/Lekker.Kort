namespace Lekker.Kort.Interface
{
    public interface IKortRepository
    {
        void ReleaseContext();

        void SetContext();
    }
}