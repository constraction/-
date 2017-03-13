using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Thrown
{
    public class SeashellDaggerProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Seashell Dagger";
            projectile.width = 18;
            projectile.height = 28;
            projectile.aiStyle = 113;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.alpha = 255;
            projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.ThrowingKnife;
        }
        public override void AI()
        {
            {
                {
                    int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height - 10, 172, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height - 10, 172, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust2].noGravity = true;
                    Main.dust[dust2].velocity *= 0f;
                    Main.dust[dust2].velocity *= 0f;
                    Main.dust[dust2].scale = 1.2f;
                    Main.dust[dust].scale = 1.2f;
                }

            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 172);
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(4) == 0)
            {
                target.AddBuff(mod.BuffType("TidalEbb"), 240);
            }
        }
    }
}