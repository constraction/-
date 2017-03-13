using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace SpiritMod.Items.Weapon.Magic
{
    public class TrueDarkStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "True Horizon's Edge";
            item.damage = 62;
            item.magic = true;
            item.mana = 15;
            item.width = 66;
            item.height = 68;
            item.useTime = 34;
            item.useAnimation = 34;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 5;
            item.value = 120000;
            item.rare = 8;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CursedFire");
            item.shootSpeed = 16f;
            item.toolTip = "Shoots out a splitting volley of homing pestilence and cursed fire.";
        }

        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(mod);
            modRecipe.AddIngredient(null, "BrokenStaff", 1);
            modRecipe.AddIngredient(null, "NightStaff", 1);
            modRecipe.AddTile(134);
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}