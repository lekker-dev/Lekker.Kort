using Lekker.Kort.Interface;

namespace Lekker.Kort.Repository.Context
{
    public class KortRepository : IKortRepository
    {
        protected KortContext _kortContext;

        private readonly IKortContextFactory _contextFactory;

        public KortRepository(IKortContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void ReleaseContext()
        {
            if (_kortContext != null)
            {
                _kortContext.Dispose();
                _kortContext = null;
            }
        }

        public void SetContext()
        {
            if (_kortContext == null)
                _kortContext = (KortContext)_contextFactory.CreateDbContext();
        }
    }
}