using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class AlphaBlade : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Cosmos unleasher";     
            item.damage = 138;            
            item.melee = true;            
            item.width = 34;              
            item.height = 40;             
            item.toolTip = "'The power of the universe sides with you'";  
            item.useTime = 16;           
            item.useAnimation = 16;     
            item.useStyle = 1;        
            item.knockBack = 6;      
            item.value = 10000;        
            item.rare = 1;
            item.useSound = 1;       
            item.shoot = mod.ProjectileType("PestilentSwordProjectile");
            item.shootSpeed = 4f;
			item.autoReuse = true;			
        }
		
		    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
            Vector2 origVect = new Vector2(speedX, speedY);
			//generate the remaining projectiles
			
			Vector2 newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(72, 1800) / 10));
				Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, mod.ProjectileType("AlphaProj1"), damage, knockBack, player.whoAmI, 0f, 0f);
				newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(72, 1800) / 10));
				Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, mod.ProjectileType("AlphaProj2"), damage, knockBack, player.whoAmI, 0f, 0f);
				newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(72, 1800) / 10));
				Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, mod.ProjectileType("AlphaProj3"), damage, knockBack, player.whoAmI, 0f, 0f);
				newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(72, 1800) / 10));
				Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, mod.ProjectileType("AlphaProj4"), damage, knockBack, player.whoAmI, 0f, 0f);
				newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(72, 1800) / 10));
				Projectile.NewProjectile(position.X, position.Y, newVect.X * 1.5f, newVect.Y * 1.5f, mod.ProjectileType("AlphaProj5"), damage, knockBack, player.whoAmI, 0f, 0f);
				
            return false;
        }
    }
}