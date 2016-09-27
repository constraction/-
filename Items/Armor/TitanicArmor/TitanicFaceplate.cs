﻿using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.TitanicArmor
{
    public class TitanicFaceplate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Titanic Faceplate";
            item.width = 40;
            item.height = 30;
            item.toolTip = "+10% melee damage and +8% melee crit chance";
            item.toolTip += "\n'Crash down like a roaring wave'";
            item.value = 10000;
            item.rare = 5;

            item.defense = 20;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.1F;
            player.meleeCrit += 8;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("TitanicPlatemail") && legs.type == mod.ItemType("TitanicGreaves");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "'The seven seas flow in your favor'";
            player.GetModPlayer<MyPlayer>(mod).titanicSet = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TidalEssence", 16);
            recipe.AddTile(null, "EssenceDistorter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}