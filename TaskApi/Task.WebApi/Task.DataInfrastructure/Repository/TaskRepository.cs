using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Task.Domain;
using Task.Domain.Entities;
using Task.Domain.Repository;

namespace Task.DataInfrastructure.Repository
{
    public class TaskRepository : IBaseRepository<TASK, int>
    {
        private TaskDbContext _db;

        public TaskRepository(TaskDbContext db)
        {
            this._db = db;
        }

        public TASK Add(TASK entity)
        {
            _db.Add(entity);
            return entity;
        }

        public int Delete(int id)
        {
            var register = _db.TASK.Where(w => w.ID.Equals(id)).FirstOrDefault();

            if (register != null)
                _db.TASK.Remove(register);

            return id;

        }

        public TASK Edit(TASK entity)
        {
            var register = _db.TASK.Where(w => w.ID.Equals(entity.ID)).FirstOrDefault();
            if (register != null)
            {
                register.TITLE = entity.TITLE;
                register.DESCRIPTION = entity.DESCRIPTION;
                register.STATUS = entity.STATUS;
                register.DATE_UPDATED = DateTime.Now;

                _db.Entry(register).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return register;
        }

        public List<TASK> Get()
        {
            return _db.TASK.ToList();
        }

        public TASK GeTaskById(int TId)
        {
            return _db.TASK.Where(x => x.ID.Equals(TId)).FirstOrDefault();
        }


        public void saveChanges()
        {
            _db.SaveChanges();  
        }
    }
}
