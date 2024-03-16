using System.Text.Json;

namespace JsonParser {
    public class JsonManager : IJsonParser {
        public string PATH { get; }

        public JsonManager(string path) {
            PATH = path;
            Init();
        }

        public void Init() {
            string initJson = "{}";
            if(!File.Exists(PATH))
                File.WriteAllText(PATH, initJson);
        }

        public string GetValue(string key) {
            using(FileStream fs = File.OpenRead(PATH)) {
                var options = new JsonSerializerOptions { AllowTrailingCommas = true };
                Dictionary<string, string> values = JsonSerializer.Deserialize<Dictionary<string, string>>(fs, options);

                if(values != null && values.ContainsKey(key))
                    return values[key];
            }
            return null;
        }

        public void SetValue(string key, string value) {
            Dictionary<string, string> values;

            // Get Existing Values
            if(File.Exists(PATH)) {
                using(FileStream fs = File.OpenRead(PATH)) {
                    var options = new JsonSerializerOptions { AllowTrailingCommas = true };
                    values = JsonSerializer.Deserialize<Dictionary<string, string>>(fs, options) ?? new Dictionary<string, string>();
                }
            } else values = new Dictionary<string, string>();

            // Write New Value
            values[key] = value;

            // Overwrite File
            using(FileStream fs = File.Create(PATH)) {
                var options = new JsonSerializerOptions { AllowTrailingCommas = true };
                JsonSerializer.Serialize<Dictionary<string, string>>(fs, values, options);
            }
        }

        public Dictionary<string, string> GetAllValues() {
            throw new NotImplementedException();
        }
    }
}
