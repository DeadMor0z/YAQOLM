using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using YAQOLM.Common.Configs;
using YAQOLM.Common.Systems;

namespace YAQOLM.Content.Items.PrefixHammers {
    public class SolarPrefixHammer : ModItem {
        public override bool IsLoadingEnabled(Mod mod) => ServerConfig.Instance.PrefixHammers;

        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Right click with a weapon in your cursor to apply the best prefix to it\nOr, right click a weapon with this in your cursor");
        }

        public override void SetDefaults() {
            Item.width = 26;
            Item.height = 24;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Cyan;
        }

        public override void AddRecipes() {
            CreateRecipe()
                    .AddIngredient(ItemID.FragmentSolar, 1)
                    .AddIngredient(ItemID.FragmentVortex, 1)
                    .AddIngredient(ItemID.FragmentNebula, 1)
                    .AddIngredient(ItemID.FragmentStardust, 1)
                    .AddTile(TileID.LunarCraftingStation)
                    .Register();
        }

        public override bool CanRightClick() {
            return Main.mouseItem.damage > 0 && !PrefixSystem.ItemHasBestPrefix(Main.LocalPlayer.HeldItem);
        }

        public override void RightClick(Player player) {
            PrefixSystem.ApplyBestPrefix(ref Main.mouseItem);

            // Dusty dust
            for (int i = 0; i < 40; i++) {
                Dust d = Dust.NewDustDirect(player.position, player.width, player.height, DustID.DesertTorch, 0f, 0f, 150, default, 1.3f);
                d.noLight = true;
                d.velocity *= 10f;
                d.noGravity = true;
            }
        }
    }

    public class SolarPrefixHammerGlobalItem : GlobalItem {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.damage > 0;

        public override bool CanRightClick(Item item) {
            if (Main.mouseItem.type == ModContent.ItemType<SolarPrefixHammer>()) {
                return !PrefixSystem.ItemHasBestPrefix(item);
            }

            return base.CanRightClick(item);
        }

        public override void RightClick(Item item, Player player) {
            if (Main.mouseItem.type != ModContent.ItemType<SolarPrefixHammer>()) {
                return;
            }

            PrefixSystem.ApplyBestPrefix(ref item);
            item.stack++;
            Main.mouseItem.stack--;

            // Dusty dust
            for (int i = 0; i < 40; i++) {
                Dust d = Dust.NewDustDirect(player.position, player.width, player.height, DustID.DesertTorch, 0f, 0f, 150, default, 1.3f);
                d.noLight = true;
                d.velocity *= 10f;
                d.noGravity = true;
            }
        }
    }
}