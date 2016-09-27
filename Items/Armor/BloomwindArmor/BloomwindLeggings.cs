using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.BloomwindArmor
{
    public class BloomwindLeggings : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Bloomwind Leggings";
            item.width = 34;
            item.height = 30;
            item.toolTip = "+1 minion slot and +13% minion damage";
            item.value = 10;
            item.rare = 6;

            item.defense = 8;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
            player.minionDamage += 0.13f;
        }        
    }
}