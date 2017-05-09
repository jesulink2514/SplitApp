namespace SplitApp.Infrastructure
{
    public class EditorParameter<T>
    {
        public EditorStatus Status { get; set; }
        public T Param { get; set; }
    }

    public enum EditorStatus
    {
        New,
        Edited,
        Deleted
    }
}
