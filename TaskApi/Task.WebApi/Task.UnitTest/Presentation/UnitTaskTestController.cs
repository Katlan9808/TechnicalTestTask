using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Task.Application.Interfaces;
using Task.Application.Services;
using Task.DataInfrastructure.Repository;
using Task.Domain;
using Task.Domain.Entities;
using Task.WebApi.Controllers;

namespace Task.UnitTest.Presentation
{
    public class UnitTaskTestController
    {
        private readonly Mock<Application.Interfaces.ITaskService<TASK, int>> taskService;
        public UnitTaskTestController()
        {
            taskService = new Mock<ITaskService<TASK, int>>();
        }

        TaskService createService()
        {
            TaskDbContext db = new TaskDbContext();
            TaskRepository repository = new TaskRepository(db);
            TaskService service = new TaskService(repository);

            return service;
        }

        [Fact]
        public void GetTask()
        {
            //Arrange
            var taskData = GetTasks();
            taskService.Setup(x => x.Get())
                .Returns(taskData);

            //act
            var service = createService();
            var taskResult = service.Get();
            //assert
            Assert.NotNull(taskResult);
            Assert.Equal(GetTasks().Count(), taskResult.Count());
            Assert.Equal(GetTasks().ToString(), taskResult.ToString());
        }

        [Fact]
        public void SaveTaskTest()
        {
            //arrange
            var tasks = GetTasks();
            taskService.Setup(x => x.Add(tasks[4])).Returns(tasks[4]);

            //act
            var service = createService();
            var task = service.Add(tasks[4]);

            //assert
            Assert.NotNull(task);
            Assert.Equal(tasks[4].TITLE, task.TITLE);
            Assert.True(tasks[4].TITLE == task.TITLE);
        }

        [Fact]
        public void EditTaskTest()
        {
            //arrange
            var tasks = GetTasks();
            taskService.Setup(x => x.Edit(tasks[2])).Returns(tasks[2]);

            //act
            var service = createService();
            var task = service.Edit(tasks[2]);

            //assert
            Assert.NotNull(task);
            Assert.Equal(tasks[2].TITLE, task.TITLE);
            Assert.True(tasks[2].TITLE == task.TITLE);
        }

        [Fact]
        public void DeleteTaskTest()
        {
            //arrange
            var tasks = GetTasks();
            taskService.Setup(x => x.Delete(tasks[3].ID)).Returns(tasks[3].ID);

            //act
            var service = createService();
            var taskId = service.Delete(tasks[3].ID);

            //assert
            Assert.NotNull(taskId);
            Assert.Equal(tasks[3].ID, taskId);
            Assert.True(tasks[3].ID == taskId);
        }


        [Theory]
        [InlineData(39)]
        public void CheckIfTaskExist(int idTask)
        {
            ////arrange
            var tasks = GetTasks();
            taskService.Setup(x => x.GeTaskById(tasks[1].ID)).Returns(tasks[1]);

            //act
            var service = createService();
            var taskExpected = service.GeTaskById(tasks[1].ID);

            //act

            //assert
            Assert.NotNull(taskExpected);
            Assert.Equal(idTask, taskExpected.ID);
        }

        private List<TASK> GetTasks()
        {
            List<TASK> task = new List<TASK>
        {
            new TASK
            {
                ID = 38,
                TITLE = "a",
                DESCRIPTION = "a",
                DEVELOPER = "a",
                STATUS = "Pendiente"
            },
             new TASK
            {
               ID = 39,
                TITLE = "a",
                DESCRIPTION = "a",
                DEVELOPER = "n",
                STATUS = "Pendiente"
            },
             new TASK
            {
               ID = 40,
                TITLE = "a",
                DESCRIPTION = "a",
                DEVELOPER = "a",
                STATUS = "Pendiente"
            },
              new TASK
            {
               ID = 41,
                TITLE = "SQL",
                DESCRIPTION = "Tarea",
                DEVELOPER = "Prueba",
                STATUS = "Pendiente"
            },
               new TASK
            {
                TITLE = "Task Add",
                DESCRIPTION = "Nueva tarea",
                DEVELOPER = "Prueba unica",
                STATUS = "Pendiente"
            }
        };
            return task;
        }
    }
}

