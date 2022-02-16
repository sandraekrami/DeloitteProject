namespace DeloitteProject.Domain.Models
{
    public class APIResponse<T>
    {
        public bool Status { get; set; }

        public T Data { get; set; }
    }
}
