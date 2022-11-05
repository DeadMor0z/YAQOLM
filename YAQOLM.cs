using Terraria.ModLoader;
using YAQOLM.Content.Items;
using YAQOLM.Content.Items.PrefixHammers;

namespace YAQOLM {
    public class YAQOLM : Mod {
        public override void Load() {
            AddToggle("Mods.YAQOLM.Config.WarpedMirror", "Warped Mirror", ModContent.ItemType<WarpedMirror>(), "ffffff");
            AddToggle("Mods.YAQOLM.Config.MysticMirror", "Mystic Mirror", ModContent.ItemType<MysticMirror>(), "ffffff");
            AddToggle("Mods.YAQOLM.Config.RunicMirror", "Runic Mirror", ModContent.ItemType<RunicMirror>(), "ffffff");
            AddToggle("Mods.YAQOLM.Config.GemstoneMagnet", "Gemstone Magnet", ModContent.ItemType<GemstoneMagnet>(), "ffffff");
            AddToggle("Mods.YAQOLM.Config.MagnificentMagnet", "Magnificent Magnet", ModContent.ItemType<MagnificentMagnet>(), "ffffff");
            AddToggle("Mods.YAQOLM.Config.QuantumStrongbox", "Quantum Strongbox", ModContent.ItemType<QuantumStrongbox>(), "ffffff");
            AddToggle("Mods.YAQOLM.Config.GoldenHorseshoeBalloon", "Golden Horseshoe Balloon", ModContent.ItemType<GoldenHorseshoeBalloon>(), "ffffff");
            AddToggle("Mods.YAQOLM.Config.FlowerOfTheJungle", "Flower of the Jungle", ModContent.ItemType<FlowerOfTheJungle>(), "ffffff");
            AddToggle("Mods.YAQOLM.Config.PrefixHammers", "Prefix Hammers", ModContent.ItemType<SolarPrefixHammer>(), "ffffff");
        }

        private void AddToggle(string toggle, string name, int item, string color) {
            ModTranslation text = LocalizationLoader.CreateTranslation(toggle);
            text.SetDefault($"[i:{item}] [c/{color}:{name}]");
            LocalizationLoader.AddTranslation(text);
        }
    }
}