using System.Threading.Tasks;
using MealBlazorApp.Data;

namespace MealBlazorApp.Services
{
    public sealed class FriendRepository : Repository<Friend, (string, string)>
    {
        public FriendRepository(MealBlazorAppContext context) : base(context, context.Friends)
        {}

        public async override Task<Friend> Update(int id, Friend newFriend)
        {
            var friend = await _dbSet.FindAsync(id);
            if (friend == null)
                return null;

            friend.Name = newFriend.Name;
            friend.Surname = newFriend.Surname;

            _dbSet.Update(friend);
            await _context.SaveChangesAsync();
        
            return friend;
        }

        protected override (string, string) OrderKeySelector(Friend t) => (t.Surname, t.Name);
    }
}