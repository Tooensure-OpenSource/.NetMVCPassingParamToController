namespace MVController.Models
{
    public class GenericDto<T> where T : class
    {
        public List<T> Data { get; set; } = null;
        public void AddData(T model)
        {
            Data.Add(model);
        }
        public void Reset()
        {
            Data.Clear();
        }
    }
}