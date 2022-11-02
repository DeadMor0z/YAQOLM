using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using YAQOLM.Common.Configs;

namespace YAQOLM.Common.Systems {
    public class RecipesSystem : ModSystem {
        // Recipe groups 
        public static RecipeGroup evilBarRecipeGroup;
        public static RecipeGroup moonLordWeaponRecipeGroup;
        public static RecipeGroup moonLordItemRecipeGroup;

        public override void Unload() {
            // Set stuff to null
            evilBarRecipeGroup = null;
            moonLordWeaponRecipeGroup = null;
            moonLordItemRecipeGroup = null;
            beetleArmor = null;
        }

        public override void AddRecipeGroups() {
            // Initialise our recipe groups
            evilBarRecipeGroup = new(() => "Any Evil Bar", ItemID.DemoniteBar, ItemID.CrimtaneBar);
            RecipeGroup.RegisterGroup("YAQOLM:EvilBar", evilBarRecipeGroup);
            moonLordWeaponRecipeGroup = new(() => "Any Moon Lord weapon", ItemID.Meowmere, ItemID.Terrarian, ItemID.StarWrath, ItemID.SDMG, ItemID.LastPrism, ItemID.LunarFlareBook, ItemID.RainbowCrystalStaff, ItemID.MoonlordTurretStaff, ItemID.Celeb2);
            RecipeGroup.RegisterGroup("YAQOLM:MoonLordWeapon", moonLordWeaponRecipeGroup);
            moonLordItemRecipeGroup = new(() => "Any Moon Lord item", ItemID.MeowmereMinecart, ItemID.PortalGun, ItemID.GravityGlobe, ItemID.SuspiciousLookingTentacle, ItemID.LongRainbowTrailWings);
            RecipeGroup.RegisterGroup("YAQOLM:MoonLordItem", moonLordItemRecipeGroup);
        }

        public override void AddRecipes() {
            if (ServerConfig.Instance.RodOfDiscord) {
                Recipe recipe = Recipe.Create(ItemID.RodofDiscord);
                recipe.AddIngredient(ItemID.HallowedBar, 15);
                recipe.AddIngredient(ItemID.SoulofLight, 10);
                recipe.AddIngredient(ItemID.SoulofSight, 5);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
            }

            if (ServerConfig.Instance.SnowGlobe) {
                Recipe recipe = Recipe.Create(ItemID.SnowGlobe);
                recipe.AddIngredient(ItemID.SnowBlock, 20);
                recipe.AddIngredient(ItemID.Glass, 20);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
            }

            if (ServerConfig.Instance.MoneyTrough) {
                Recipe recipe = Recipe.Create(ItemID.MoneyTrough);
                recipe.AddIngredient(ItemID.PiggyBank);
                recipe.AddRecipeGroup(evilBarRecipeGroup, 6);
                recipe.AddTile(TileID.DemonAltar);
                recipe.Register();
            }

            if (ServerConfig.Instance.Bait) {
                Recipe recipe = Recipe.Create(ItemID.JourneymanBait);
                recipe.AddIngredient(ItemID.ApprenticeBait, 2);
                recipe.AddTile(TileID.Solidifier);
                recipe.Register();

                recipe = Recipe.Create(ItemID.MasterBait);
                recipe.AddIngredient(ItemID.JourneymanBait, 2);
                recipe.AddTile(TileID.Solidifier);
                recipe.Register();
            }

            if (ServerConfig.Instance.BottomlessBuckets) {
                Recipe recipe = Recipe.Create(ItemID.BottomlessBucket);
                recipe.AddIngredient(ItemID.WaterBucket, 8);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                recipe = Recipe.Create(ItemID.BottomlessLavaBucket);
                recipe.AddIngredient(ItemID.LavaBucket, 8);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();

                // TODO: Add bottomless honey and shimmer buckets when 1.4.4 is here
            }

            if (ServerConfig.Instance.MagicMirror) {
                Recipe recipe = Recipe.Create(ItemID.MagicMirror);
                recipe.AddRecipeGroup(RecipeGroupID.IronBar, 10);
                recipe.AddIngredient(ItemID.Glass, 5);
                recipe.AddTile(TileID.DemonAltar);
                recipe.Register();
            }

            if (ServerConfig.Instance.LuminiteSmeltingRecipes) {
                Recipe recipe = Recipe.Create(ItemID.LunarBar, 8);
                recipe.AddRecipeGroup(moonLordWeaponRecipeGroup);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();

                recipe = Recipe.Create(ItemID.LunarBar, 5);
                recipe.AddRecipeGroup(moonLordItemRecipeGroup);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.Register();
            }

            if (ServerConfig.Instance.BeetleArmorOnlyBeetle) {
                Recipe recipe = Recipe.Create(ItemID.BeetleHelmet);
                recipe.AddIngredient(ItemID.BeetleHusk, 6);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();

                recipe = Recipe.Create(ItemID.BeetleLeggings);
                recipe.AddIngredient(ItemID.BeetleHusk, 9);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();

                recipe = Recipe.Create(ItemID.BeetleScaleMail);
                recipe.AddIngredient(ItemID.BeetleHusk, 12);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();

                recipe = Recipe.Create(ItemID.BeetleShell);
                recipe.AddIngredient(ItemID.BeetleHusk, 12);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
            }

            if (ServerConfig.Instance.CheaperOre) {
                Recipe recipe = Recipe.Create(ItemID.CopperBar);
                recipe.AddIngredient(ItemID.CopperOre, 2);
                recipe.AddTile(TileID.AdamantiteForge);
                recipe.Register();

                recipe = Recipe.Create(ItemID.TinBar);
                recipe.AddIngredient(ItemID.TinOre, 2);
                recipe.AddTile(TileID.AdamantiteForge);
                recipe.Register();

                recipe = Recipe.Create(ItemID.IronBar);
                recipe.AddIngredient(ItemID.IronOre, 2);
                recipe.AddTile(TileID.AdamantiteForge);
                recipe.Register();

                recipe = Recipe.Create(ItemID.LeadBar);
                recipe.AddIngredient(ItemID.LeadOre, 2);
                recipe.AddTile(TileID.AdamantiteForge);
                recipe.Register();

                recipe = Recipe.Create(ItemID.SilverBar);
                recipe.AddIngredient(ItemID.SilverOre, 3);
                recipe.AddTile(TileID.AdamantiteForge);
                recipe.Register();

                recipe = Recipe.Create(ItemID.TungstenBar);
                recipe.AddIngredient(ItemID.TungstenOre, 3);
                recipe.AddTile(TileID.AdamantiteForge);
                recipe.Register();

                recipe = Recipe.Create(ItemID.GoldBar);
                recipe.AddIngredient(ItemID.GoldOre, 3);
                recipe.AddTile(TileID.AdamantiteForge);
                recipe.Register();

                recipe = Recipe.Create(ItemID.PlatinumBar);
                recipe.AddIngredient(ItemID.PlatinumOre, 3);
                recipe.AddTile(TileID.AdamantiteForge);
                recipe.Register();

                recipe = Recipe.Create(ItemID.MeteoriteBar);
                recipe.AddIngredient(ItemID.Meteorite, 2);
                recipe.AddTile(TileID.AdamantiteForge);
                recipe.Register();

                recipe = Recipe.Create(ItemID.DemoniteBar);
                recipe.AddIngredient(ItemID.DemoniteOre, 2);
                recipe.AddTile(TileID.AdamantiteForge);
                recipe.Register();

                recipe = Recipe.Create(ItemID.CrimtaneBar);
                recipe.AddIngredient(ItemID.CrimtaneOre, 2);
                recipe.AddTile(TileID.AdamantiteForge);
                recipe.Register();

                recipe = Recipe.Create(ItemID.HellstoneBar);
                recipe.AddIngredient(ItemID.Hellstone, 2);
                recipe.AddIngredient(ItemID.Obsidian);
                recipe.AddTile(TileID.AdamantiteForge);
                recipe.Register();
            }
        }

        private int[] barTypes = new int[] {
            ItemID.CopperBar,
            ItemID.TinBar,
            ItemID.IronBar,
            ItemID.LeadBar,
            ItemID.SilverBar,
            ItemID.TungstenBar,
            ItemID.GoldBar,
            ItemID.PlatinumBar,
            ItemID.MeteoriteBar,
            ItemID.DemoniteBar,
            ItemID.CrimtaneBar,
            ItemID.HellstoneBar
        };

        private int[] oreTypes = new int[] {
            ItemID.CopperOre,
            ItemID.TinOre,
            ItemID.IronOre,
            ItemID.LeadOre,
            ItemID.SilverOre,
            ItemID.TungstenOre,
            ItemID.GoldOre,
            ItemID.PlatinumOre,
            ItemID.Meteorite,
            ItemID.DemoniteOre,
            ItemID.CrimtaneOre,
            ItemID.Hellstone
        };

        private int[] beetleArmor = new int[] {
            ItemID.BeetleHelmet,
            ItemID.BeetleLeggings,
            ItemID.BeetleScaleMail,
            ItemID.BeetleShell
        };

        public override void PostAddRecipes() {
            if (ServerConfig.Instance.CheaperOre) {
                for (int i = 0; i < Main.recipe.Length; i++) {
                    Recipe recipe = Main.recipe[i];
                    if (barTypes.Contains(recipe.createItem.type) && !recipe.requiredTile.Contains(TileID.AdamantiteForge) && oreTypes.Contains(recipe.requiredItem[0].type)) {
                        recipe.AddCondition(NetworkText.FromLiteral("Pre Hardmode Furnace"), r => !Main.LocalPlayer.adjTile[TileID.AdamantiteForge]);
                    }
                }
            }

            if (ServerConfig.Instance.BeetleArmorOnlyBeetle) {
                for (int i = 0; i < Main.recipe.Length; i++) {
                    if (beetleArmor.Contains(Main.recipe[i].createItem.type) && Main.recipe[i].requiredItem.Count > 1) {
                        Main.recipe[i].DisableRecipe();
                    }
                }
            }
        }
    }
}