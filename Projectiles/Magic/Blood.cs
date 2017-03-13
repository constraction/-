using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
    public class Blood : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.hostile = false;
            projectile.magic = true;
            projectile.name = "Blood Clusters";
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.alpha = 255;
            projectile.timeLeft = 60;

        }

        public override bool PreAI()
        {
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 5, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[dust].scale = 2f;
            Main.dust[dust].noGravity = true;

            return true;
        }
        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(projectile.position.X - 50, projectile.position.Y - 1000, 0f, 30f, mod.ProjectileType("Blood2"), projectile.damage, 0f, projectile.owner, 0f, 0f);

        }
    }
}