using Terraria;
using Terraria.ModLoader;
using YAQOLM.Common.Configs;

namespace YAQOLM.Common.Players {
    public class DetoursPlayer : ModPlayer {
        public override void Load() {
            // Subscribing in Load
            if (ServerConfig.Instance.MoreAnglerLoot) {
                On.Terraria.Player.GetAnglerReward += Player_GetAnglerReward;
            }
            if (ServerConfig.Instance.BulkExtractinate) {
                On.Terraria.Player.ExtractinatorUse += Player_ExtractinatorUse;
            }
        }

        public override void Unload() {
            // Unsubscribing in Unload
            if (ServerConfig.Instance.MoreAnglerLoot) {
                On.Terraria.Player.GetAnglerReward -= Player_GetAnglerReward;
            }
            if (ServerConfig.Instance.BulkExtractinate) {
                On.Terraria.Player.ExtractinatorUse -= Player_ExtractinatorUse;
            }
        }

        private void Player_GetAnglerReward(On.Terraria.Player.orig_GetAnglerReward orig, Player self, NPC angler) {
            // Just gives us double loot from anglerg
            orig(self, angler);
            self.anglerQuestsFinished++;
            orig(self, angler);
        }

        private void Player_ExtractinatorUse(On.Terraria.Player.orig_ExtractinatorUse orig, Player self, int extractType) {
            // Extractinate one by one, removing from the stack as we do
            // If Main.item gets 3/4 full, we should stop
            while (self.HeldItem.stack > 0) {
                // Call orig
                orig(self, extractType);

                // Reduce our stack
                self.HeldItem.stack--;
                if (self.HeldItem.stack <= 0)
                    self.HeldItem.TurnToAir();

                // Check if we should break our loop
                int numItems = 0;
                for (int i = 0; i < Main.item.Length; i++) {
                    if (Main.item[i].active) {
                        numItems++;
                    }
                }
                if (numItems > 300) {
                    break;
                }
            }
        }
    }
}