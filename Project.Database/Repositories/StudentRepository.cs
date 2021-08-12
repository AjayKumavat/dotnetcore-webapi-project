using Project.Database.Infrastructure;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        
    }
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ProjectContext projectContext) : base(projectContext)
        {

        }
    }
}
