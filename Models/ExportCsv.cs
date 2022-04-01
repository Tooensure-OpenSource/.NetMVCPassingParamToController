using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MVController.Models
{
    public class ExportCsv<T>
    {
        public ICollection<T> Models { get; set; } = new ObservableCollection<T>();
        public ExportCsv()
        {
            
        }
        public object SaveToCsv<T>(List<T> data, string path)
        {
            var lines = new List<string>();
            IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
            var header = string.Join(",", props.ToList().Select(x => x.Name));
            lines.Add(header);
            var valueLines = data.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            lines.AddRange(valueLines);
            File.WriteAllLines(path, lines.ToArray());
            return this;
        }
    }
}