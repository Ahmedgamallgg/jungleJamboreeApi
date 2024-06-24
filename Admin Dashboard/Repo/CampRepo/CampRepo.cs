using Core.Context;

namespace Admin_Dashboard.Repo.CampRepo
{
    public class CampRepo : ICampRepo
    {
        private readonly JungleJumboreeDbContext _context;

        public CampRepo(JungleJumboreeDbContext context)
        {
            _context = context;
        }
        public async void DeleteCampChild(int id)
        {
           var camps =  _context.ChildCamps.Where( c => c.CampId == id).ToList();
            foreach (var camp in camps)
            {
                _context.ChildCamps.Remove(camp);
            }

        }
    }
}
