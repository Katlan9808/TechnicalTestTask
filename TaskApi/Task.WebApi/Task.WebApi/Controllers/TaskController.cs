using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Application.Services;
using Task.DataInfrastructure.Repository;
using Task.Domain;
using Task.Domain.Entities;
using Task.Models.Models;
using Task.Utilities.Enums;
using Task.WebApi.Validations;

namespace Task.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        TaskService createService()
        {
            TaskDbContext db = new TaskDbContext();
            TaskRepository repository = new TaskRepository(db);
            TaskService service = new TaskService(repository);

            return service;
        }

        [HttpGet]
        [Route(nameof(TaskController.Get))]
        public RequestResultModel<List<TaskDTO>> Get()
        {
            RequestResultModel<List<TaskDTO>> response = new Models.Models.RequestResultModel<List<TaskDTO>>();
            var service = createService();
            response.result = service.Get().Select(x => new TaskDTO
            {
                Id = x.ID,
                Title = x.TITLE,
                Description = x.DESCRIPTION,
                Developer = x.DEVELOPER,
                State = x.STATUS,
                DateLimit = x.DATE_LIMIT
            }).ToList();
            return response;
        }


        [HttpPost]
        [Route(nameof(TaskController.Create))]
        public RequestResultModel<TaskDTO> Create(TaskDTO objDto)
        {
            RequestResultModel<TaskDTO> response = new Models.Models.RequestResultModel<TaskDTO>();
            try
            {
                TaskValidation validat = new();
                var validatorResult = validat.Validate(objDto);

                if (validatorResult.Errors.Any())
                {
                    response.isSuccessful = false;
                    response.errorMessage = validatorResult.Errors.Select(s => s.ErrorMessage).Aggregate((a, b) => $"{a}, {b}");

                    return response;
                }

                TASK entity = new TASK
                {
                    DEVELOPER = objDto.Developer,
                    TITLE = objDto.Title,
                    DESCRIPTION = objDto.Description,
                    STATUS = objDto.State,
                    DATE_CREATED = DateTime.Now,
                    DATE_LIMIT = DateTime.Now.AddDays(5),
                };

                var service = createService();
                service.Add(entity);

                response.isSuccessful = true;
                response.result = new TaskDTO { Title = entity.TITLE };

                return response;
            }
            catch (Exception e)
            {
                response.isSuccessful = false;
                response.result = objDto;
                response.errorMessage = e.StackTrace + " " + e.Message;
                return response;
            }
        }



        [HttpPost]
        [Route(nameof(TaskController.Edit))]
        public RequestResultModel<TaskDTO> Edit(TaskDTO objDto)
        {
            RequestResultModel<TaskDTO> response = new Models.Models.RequestResultModel<TaskDTO>();
            try
            {
                TaskValidation validat = new();
                var validatorResult = validat.Validate(objDto);

                if (validatorResult.Errors.Any())
                {
                    response.isSuccessful = false;
                    response.errorMessage = validatorResult.Errors.Select(s => s.ErrorMessage).Aggregate((a, b) => $"{a}, {b}");

                    return response;
                }


                TASK entity = new TASK
                {
                    ID = objDto.Id,
                    DEVELOPER = objDto.Developer,
                    TITLE = objDto.Title,
                    DESCRIPTION = objDto.Description,
                    STATUS = objDto.State,
                    DATE_UPDATED = DateTime.Now,
                    DATE_LIMIT = DateTime.Now.AddDays(5),
                };


                var service = createService();
                service.Edit(entity);

                response.isSuccessful = true;
                response.result = new TaskDTO { Title = entity.TITLE };

                return response;
            }
            catch (Exception e)
            {
                response.isSuccessful = false;
                response.result = objDto;
                response.errorMessage = e.StackTrace + " " + e.Message;
                return response;
            }
        }

        [HttpPost]
        [Route(nameof(TaskController.Delete))]
        public RequestResultModel<TaskDTO> Delete(TaskDTO objDto)
        {
            RequestResultModel<TaskDTO> response = new Models.Models.RequestResultModel<TaskDTO>();
            try
            {
                var service = createService();
                service.Delete(objDto.Id);
                response.isSuccessful = true;
                response.result = objDto;

                return response;
            }
            catch (Exception e)
            {
                response.isSuccessful = false;
                response.result = objDto;
                response.errorMessage = e.StackTrace + " " + e.Message;
                return response;
            }
        }
    }
}
