namespace TodoEc2.API.Controllers
{
    public class RequestCreateTodoJson
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}