using School.DataAccess;
using School.Model;
using School.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL
{
    public class ClassService
    {
        ClassRepository classRepository;
        public ClassService()
        {
            classRepository = new ClassRepository();
        }
        public OperationResult Insert(Class clas)
        {
            classRepository.Insert(clas);
            return new OperationResult { Success = true };
        }
    }
}
