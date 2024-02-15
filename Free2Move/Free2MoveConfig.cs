using BepInEx;
using BepInEx.Configuration;

namespace Free2Move;

public class Free2MoveConfig
{
    private const string DefaultSection = "General";

    public readonly ConfigEntry<bool> Enabled;

    public Free2MoveConfig(BaseUnityPlugin plugin)
    {
        Enabled = new ConfigEntryBuilder<bool> {
            ConfigFile = plugin.Config,
            Definition = new ConfigDefinition(DefaultSection, "Enabled"),
            DefaultValue = true,
            Description = new ConfigDescription("Globally enable/disable the plugin")
        };
    }

    private class ConfigEntryBuilder<T>
    {
        public required ConfigDefinition Definition { get; init; }
        public required T DefaultValue { get; init; }
        public required ConfigDescription Description { get; init; }
        public required ConfigFile ConfigFile { get; init; }

        public ConfigEntry<T> Bind() => ConfigFile.Bind(Definition, DefaultValue, Description);

        public static implicit operator ConfigEntry<T>(ConfigEntryBuilder<T> builder) => builder.Bind();
    }
}
