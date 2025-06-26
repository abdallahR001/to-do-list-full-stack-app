using to_do_list.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using to_do_list.Data;
using to_do_list.Models;
using to_do_list.Repositories.Interfaces;
using to_do_list.Requests;

namespace to_do_list.Repositories.Classes
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<TaskRepository> _logger;

        public TaskRepository(AppDbContext dbContext, ILogger<TaskRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<List<ToDo>> GetToDosAsync()
        {
            var tasks = await _dbContext.ToDos.ToListAsync();

            return tasks;
        }
        public async Task<ToDo?> GetToDoAsync(int id)
        {
            var task = await _dbContext.ToDos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);

            return task;
        }
        public async Task<OperationResult> AddToDoAsync(AddToDoModel request)
        {
            try
            {
                var task = new ToDo
                {
                        Title = request.Title,
                        Description = request.Description,
                };

                await _dbContext.ToDos.AddAsync(task);

                await _dbContext.SaveChangesAsync();

                return OperationResult.Ok("added task successfulyy");

            }

            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a ToDo.");
                return OperationResult.Fail();
            }
        }
        public async Task<OperationResult> UpdateToDoAsync(int id, UpdateToDoModel request)
        {
            try
            {
                var task = await _dbContext.ToDos.FindAsync(id);

                if(task == null)
                    return OperationResult.Fail("task not found");

                if(!request.Title.IsNullOrEmpty() && request.Title?.Trim().Length > 0)
                    task.Title = request.Title;

                if(!request.Description.IsNullOrEmpty() && request.Description?.Trim().Length > 0)
                    task.Description = request.Description;

                await _dbContext.SaveChangesAsync();

                return OperationResult.Ok("task updated successfully");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a ToDo.");
                return OperationResult.Fail();
            }
        }
        public async Task<OperationResult> DeleteToDoAsync(int id)
        {
            try
            {
                var task = await _dbContext.ToDos.FindAsync(id);

                if(task == null)
                    return OperationResult.Fail("task not found");;

                _dbContext.ToDos.Remove(task);

                await _dbContext.SaveChangesAsync();

                return OperationResult.Ok("task deleted successfully");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a ToDo.");
                return OperationResult.Fail();
            }
        }
        public async Task<OperationResult> ChangeToDoState(int id)
        {
            try
            {
                var task = await _dbContext.ToDos.FindAsync(id);

                if(task == null)
                    return OperationResult.Fail("task not found");

                if(!task.IsCompleted)
                    task.IsCompleted = true;
                else
                    task.IsCompleted = false;

                await _dbContext.SaveChangesAsync();

                return OperationResult.Ok("task state changed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "an error occurred while changing a ToDo state.");
                return OperationResult.Fail();
            }
        }
    }
}