using to_do_list.Helpers;
using to_do_list.Models;
using to_do_list.Requests;

namespace to_do_list.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        public Task<List<ToDo>> GetToDosAsync();
        public Task<ToDo?> GetToDoAsync(int id);
        public Task<OperationResult> AddToDoAsync(AddToDoModel request);
        public Task<OperationResult> UpdateToDoAsync(int id, UpdateToDoModel request);
        public Task<OperationResult> DeleteToDoAsync(int id);
        public Task<OperationResult> ChangeToDoState(int id);
    }
}