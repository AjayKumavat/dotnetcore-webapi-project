using Project.Database.Infrastructure;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Repositories
{
    public interface IAccountRepository : IRepository<UserLogin>
    {
        UserLogin Login(string userName, string password);
    }
    public class AccountRepository : Repository<UserLogin>, IAccountRepository
    {
        public AccountRepository(ProjectContext projectContext) : base(projectContext)
        {
        }

        public UserLogin Login(string userName, string password)
        {
            UserLogin userLogin = ProjectContext.UserLogins.Where(x => x.Name == userName && x.Password == password).FirstOrDefault();
            return userLogin;
        }
    }
}
