using System;
using System.Collections.Generic;
 
public class ConfigurationManager
{
    // ✅ Singleton instance (thread-safe and lazy)
    private static readonly Lazy<ConfigurationManager> instance =
        new Lazy<ConfigurationManager>(() => new ConfigurationManager());
 
    // ✅ Lazy-loaded configuration dictionary
    private readonly Lazy<Dictionary<string, string>> configData =
        new Lazy<Dictionary<string, string>>(() => LoadConfiguration());
 
    // 🔒 Private constructor to prevent external instantiation
    private ConfigurationManager() {}
 
    // ✅ Public access to the singleton instance
    public static ConfigurationManager Instance => instance.Value;
 
    // ✅ Public method to access configuration values
    public string GetValue(string key)
    {
        return configData.Value.ContainsKey(key) ? configData.Value[key] : null;
    }
 
    // 🧠 Simulates expensive loading (e.g., from DB or file)
    private static Dictionary<string, string> LoadConfiguration()
    {
        Console.WriteLine("Loading configuration...");
        return new Dictionary<string, string>
        {
{ "Url", "https://instagram.com" },
            { "Key", "ABC123" }
        };
    }
}
class Program
{
    static void Main()
    {
        var value = ConfigurationManager.Instance.GetValue("Url");
        Console.WriteLine(value); // Loads config on first use
    }
}
