using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonParser {
    public class JsonManager {
        public static Dictionary<string, string>? Dics = new();
        public static readonly string PATH = "./config.json";

        public JsonManager() {
                CreateConfigFile();
                string jsonString = File.ReadAllText(PATH);
                Dics = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);
            }

        ~JsonManager() {
            string json = JsonSerializer.Serialize<Dictionary<string, string>>(Dics);
            File.WriteAllText(PATH, json);
        }
        
        public void CreateConfigFile() {
            if(!File.Exists(PATH)) File.Create(PATH);
        }
        
        public string GetValueByKey(string key) {
            return Dics[key];
        }
        
        public void SetValueByKey(string key, string value) {
            Dics.Add(key, value);
            // Set 하면서 동기화 하는건가?
        }
        
        
    }
}
