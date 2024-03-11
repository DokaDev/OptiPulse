namespace JsonParser {
    public interface IJsonParser {
        public string GetValue(string key);
        public void SetValue(string key, string value);
        public Dictionary<string, string> GetAllValues();
    }
}
