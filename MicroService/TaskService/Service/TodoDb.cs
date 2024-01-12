namespace TaskService.Service
{
    public class TodoDb
    {
        public Dictionary<int, List<Entities.Todo>> Todos { get; } = new Dictionary<int, List<Entities.Todo>>();

    }
}
