
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace JsonParser {
    public class JsonParserV2 : IJsonParser {
        public string Path { get; }
        private Dictionary<string, string> _values;

        public JsonParserV2(string path) {
            Path = path;
            LoadValues();
        }

        public Dictionary<string, string> GetAllValues() {
            return _values;
        }

        public string GetValue(string key) {
            if(_values.ContainsKey(key)) {
                return _values[key];
            }

            throw new KeyNotFoundException(nameof(key));
        }

        public void SetValue(string key, string value) {
            _values[key] = value;
            SaveValues();
        }

        private void LoadValues() {
            if(File.Exists(Path)) {
                using(FileStream fs = File.OpenRead(Path)) {
                    _values = JsonSerializer.Deserialize<Dictionary<string, string>>(fs) ?? new Dictionary<string, string>();
                }
            } else
                _values = new();
        }

        private void SaveValues() {
            using(FileStream fs = File.Create(Path)) {
                JsonSerializer.Serialize(fs, _values, new JsonSerializerOptions { WriteIndented = true });
            }
        }
    }
}
