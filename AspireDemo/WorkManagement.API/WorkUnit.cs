namespace WorkManagement.API
{
    public class WorkUnit
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public int StartCount { get; set; }

        public int EndCount { get; set; }
    }
}
