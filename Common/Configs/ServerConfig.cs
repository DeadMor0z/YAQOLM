using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace YAQOLM.Common.Configs {
    [Label("Recipe Configs")]
    public class ServerConfig : ModConfig {
        public static ServerConfig Instance;

        public override ConfigScope Mode => ConfigScope.ServerSide;

        /* ================ */
        /*   NEW CONTENT    */
        /* ================ */

        [Header("New Content")]

        [Label("$Mods.YAQOLM.Config.WarpedMirror")]
        [Tooltip("Returns you to where you died")]
        [DefaultValue(true)]
        public bool WarpedMirror { get; set; }

        [Label("$Mods.YAQOLM.Config.MysticMirror")]
        [Tooltip("Acts as a return potion")]
        [DefaultValue(true)]
        public bool MysticMirror { get; set; }

        [Label("$Mods.YAQOLM.Config.GoldenHorseshoeBalloon")]
        [Tooltip("Crafted from and into every horseshoe balloon")]
        [DefaultValue(true)]
        public bool GoldenHorseshoeBalloon { get; set; }

        [Label("$Mods.YAQOLM.Config.FlowerOfTheJungle")]
        [Tooltip("Summons Plantera")]
        [DefaultValue(true)]
        public bool FlowerOfTheJungle { get; set; }

        [Label("$Mods.YAQOLM.Config.PrefixHammers")]
        [Tooltip("Right click to apply a given prefix to your held item")]
        [DefaultValue(true)]
        public bool PrefixHammers { get; set; }


        /* ================ */
        /*     RECIPES      */
        /* ================ */

        [Header("Recipes")]

        [Label("[i:1326] Rod of Discord")]
        [Tooltip("15 Hallowed Bar\n10 Soul of Light\n5 Soul of Sight")]
        [DefaultValue(true)]
        public bool RodOfDiscord { get; set; }

        [Label("[i:602] Snow Globe")]
        [Tooltip("20 Snow Block\n20 Glass")]
        [DefaultValue(true)]
        public bool SnowGlobe { get; set; }

        [Label("[i:3213] Money Trough")]
        [Tooltip("1 Piggy Bank\n6 Demonite/Crimtane Bar")]
        [DefaultValue(true)]
        public bool MoneyTrough { get; set; }

        [Label("[i:2676] Bait")]
        [Tooltip("2 Apprentice Bait -> 1 Journeyman Bait\n2 Journeyman Bait -> 1 Master Bait")]
        [DefaultValue(true)]
        public bool Bait { get; set; }

        [Label("[i:3031] Bottomless Buckets")]
        [Tooltip("8 of any fluid bucket -> 1 of that fluids bottomless bucket")]
        [DefaultValue(true)]
        public bool BottomlessBuckets { get; set; }

        [Label("[i:3031] Magic Mirror")]
        [Tooltip("10 Iron/Lead Bar\n5 Glass")]
        [DefaultValue(true)]
        public bool MagicMirror { get; set; }

        [Label("[i:3467] Moon Lord drops to Luminite Bars")]
        [Tooltip("Any weapon -> 8 Luminite Bar\nAnything else -> 5 Luminite Bar")]
        [DefaultValue(true)]
        public bool LuminiteSmeltingRecipes { get; set; }

        [Label("[i:2201] Beetle Armor doesn't require Turtle Armor")]
        [Tooltip("The number of Beetle Husks required is increased to compensate")]
        [DefaultValue(true)]
        public bool BeetleArmorOnlyBeetle { get; set; }

        [Label("[i:20] Pre Hardmode bars are cheaper at a Hardmode forge")]
        [DefaultValue(true)]
        public bool CheaperOre { get; set; }


        /* ================ */
        /*      DROPS       */
        /* ================ */

        [Header("Drops")]

        [Label("[i:1309] King Slime drops Slime Staff")]
        [Tooltip("20% chance in Classic, 25% chance in Expert")]
        [DefaultValue(true)]
        public bool KingSlimeDropsSlimeStaff { get; set; }

        [Label("[i:3212] Sharks drop Sharktooth Necklace")]
        [Tooltip("4% chance")]
        [DefaultValue(true)]
        public bool SharksDropSharktoothNecklace { get; set; }


        /* ================ */
        /*      ITEMS       */
        /* ================ */

        [Header("Items")]

        [Label("[i:729] Wood Greaves have 1 defense")]
        [DefaultValue(true)]
        public bool WoodGreavesDefense { get; set; }

        [Label("[i:37] Goggles grant Night Owl")]
        [DefaultValue(true)]
        public bool GogglesGiveNightVision { get; set; }

        [Label("[i:1136] Rain Armor set bonus")]
        [Tooltip("8% increased damage and 5% increased critical chance when exposed to rain")]
        [DefaultValue(true)]
        public bool RainArmorSetBonus { get; set; }

        [Label("[i:780] Cheaper solutions")]
        [DefaultValue(true)]
        public bool CheaperSolutions { get; set; }

        [Label("[i:530] Cheaper wire")]
        [DefaultValue(true)]
        public bool CheaperWire { get; set; }

        [Label("[i:3111] Pink Gel is gel ammo")]
        [DefaultValue(true)]
        public bool PinkGelIsAmmo { get; set; }

        [Label("[i:854] Discount Card works from inventory and banks")]
        [DefaultValue(true)]
        public bool DiscountCard { get; set; }

        /* ================ */
        /*       NPCS       */
        /* ================ */

        [Header("NPCs")]

        [Label("[i:780] Steampunker sells all vanilla solutions")]
        [Tooltip("Can't sell modded solutions here to avoid progression breaking with modded biomes")]
        [DefaultValue(true)]
        public bool SteampunkerSolutions { get; set; }

        [Label("[i:2873] Dye Trader sells Strange Plant dyes")]
        [Tooltip("Depending on moon phase to not spam out the shop")]
        [DefaultValue(true)]
        public bool DyeTraderSellsSusDyes { get; set; }

        /* ================ */
        /*       MISC       */
        /* ================ */

        [Header("Misc")]

        [Label("[i:2294] More angler quest loot")]
        [DefaultValue(true)]
        public bool MoreAnglerLoot { get; set; }

        [Label("[i:2294] Angler quest resets immediately")]
        [DefaultValue(true)]
        public bool AnglerResetsImmediately { get; set; }

        [Label("[i:3198] Buff station changes")]
        [Tooltip("Buff stations provide 10% increased damage and a class specific buff")]
        [DefaultValue(true)]
        public bool BuffStationChanges { get; set; }

        [Label("[i:997] Bulk extratination")]
        [DefaultValue(true)]
        public bool BulkExtractinate { get; set; }

        [Label("[i:166] Bombs explode tiles you could mine")]
        [DefaultValue(true)]
        public bool BetterBombTiles { get; set; }

        [Label("[i:166] Bombs explode walls even when unexposed")]
        [DefaultValue(true)]
        public bool BetterBombWalls { get; set; }
    }
}