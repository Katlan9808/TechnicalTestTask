using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Interfaces;
using Task.Domain.Entities;
using Task.Domain.Repository;

namespace Task.Application.Services
{
    public class TaskService : IBaseService<TASK, int>
    {
        private readonly IBaseRepository<TASK, int> _taskRepository;

        public TaskService(IBaseRepository<TASK, int> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public TASK Add(TASK entity)
        {
            var result = _taskRepository.Add(entity); ;
            _taskRepository.saveChanges();
            return result;
        }

        public TASK Edit(TASK entity)
        {
            var result = _taskRepository.Edit(entity); ;
            _taskRepository.saveChanges();
            return result;
        }

        public List<TASK> Get()
        {
            return _taskRepository.Get(); ;
        }

        public int Delete(int id)
        {
            var result = _taskRepository.Delete(id); ;
            _taskRepository.saveChanges();
            return result;
        }

        public TASK GeTaskById(int TId)
        {
            return _taskRepository.GeTaskById(TId); ;
        }
    }
}
