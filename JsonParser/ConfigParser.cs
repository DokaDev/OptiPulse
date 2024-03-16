namespace JsonParser {
    public class ConfigParser {
        IJsonParser jsonParser = new JsonParserV2("config.json");

        public void Init() {
            jsonParser.SetValue("language", "");
            jsonParser.SetValue("theme", "");
            jsonParser.SetValue("IsRunOnStartup", "");
        }

        public void SetLanguage(string language) {
            jsonParser.SetValue("language", language);
        }

        public void SetTheme(string theme) {
            jsonParser.SetValue("theme", theme);
        }
    }
}
