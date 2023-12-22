namespace TaskService.Entities
{
    public class Todo
    {
        public int Id { get; set; }

        public required string Text { get; set; }

        public bool IsDone { get; set; }

    }
    public class TodoCreate
    {
        public required string Text { get; set; }
        public bool IsDone { get; set; }
    }
}
