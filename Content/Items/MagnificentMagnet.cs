﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using YAQOLM.Common.Configs;

namespace YAQOLM.Content.Items {
    public class MagnificentMagnet : ModItem {
        public override bool IsLoadingEnabled(Mod mod) => ServerConfig.Instance.MagnificentMagnet;

        public override void SetStaticDefaults() {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("Increases pickup range for items while in your inventory\nUse to pull all items in the world to you");
        }

        public override void SetDefaults() {
            Item.width = 26;
            Item.height = 28;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.buyPrice(gold: 3);

            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item4;
        }

        public override void AddRecipes() {
            CreateRecipe()
                    .AddIngredient(ModContent.ItemType<GemstoneMagnet>())
                    .AddIngredient(ItemID.SoulofSight, 3)
                    .AddIngredient(ItemID.SoulofMight, 3)
                    .AddIngredient(ItemID.SoulofFright, 3)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
        }

        public int Mode { get; private set; } = 0;

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            // Get index
            var lastTip = tooltips.FirstOrDefault(t => t.Name == "Tooltip1");
            int index = tooltips.IndexOf(lastTip) + 1;
            float colorMult = Main.mouseTextColor / 255f;

            // Make TooltipLine
            string text = "";
            Color color;
            switch (Mode) {
                case 0:
                    color = Color.Red * colorMult;
                    text = $"[c/{color.Hex3()}:Disabled]";
                    break;
                case 1:
                    color = Color.Orange * colorMult;
                    text = $"[c/{color.Hex3()}:1x strength]";
                    break;
                case 2:
                    color = Color.Yellow * colorMult;
                    text = $"[c/{color.Hex3()}:10x strength]";
                    break;
                case 3:
                    color = Color.Green * colorMult;
                    text = $"[c/{color.Hex3()}:100x strength]";
                    break;
            }
            TooltipLine line = new(Mod, "Mode", text);

            // insert
            tooltips.Insert(index, line);
            tooltips.Insert(index + 1, new(Mod, "RightClick", "Right click to change mode"));
        }

        public override bool CanRightClick() => true;

        public override void OnConsumeItem(Player player) => Item.stack++;

        public override void RightClick(Player player) {
            Mode++;
            if (Mode > 3) {
                Mode = 0;
            }
        }

        public override bool? UseItem(Player player) {
            if (player.whoAmI == Main.myPlayer) {
                for (int i = 0; i < Main.maxItems; i++) {
                    Item item = Main.item[i];

                    if (!item.active || item.noGrabDelay != 0 || item.playerIndexTheItemIsReservedFor != player.whoAmI) {
                        continue;
                    }

                    item.beingGrabbed = true;
                    item.Center = player.Center;
                }
            }

            return true;
        }
    }

    public class MagnificentMagnetPlayer : ModPlayer {
        public override void Load() {
            On.Terraria.Player.GetItemGrabRange += Player_GetItemGrabRange;
        }

        public override void Unload() {
            On.Terraria.Player.GetItemGrabRange += Player_GetItemGrabRange;
        }

        private int Player_GetItemGrabRange(On.Terraria.Player.orig_GetItemGrabRange orig, Player self, Item item) {
            int ret = orig(self, item);

            int magnet = self.FindItem(ModContent.ItemType<MagnificentMagnet>());
            if (magnet != -1) {
                var modItem = self.inventory[magnet].ModItem as MagnificentMagnet;
                switch (modItem.Mode) {
                    case 1:
                        ret += 150;
                        break;
                    case 2:
                        ret += 1500;
                        break;
                    case 3:
                        ret += 15000;
                        break;
                }
            }

            return ret;
        }
    }
}
