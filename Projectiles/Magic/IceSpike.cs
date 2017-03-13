using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
    public class IceSpike : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Ice Spike";
            projectile.friendly = true;
            projectile.magic = true;
            projectile.width = 10; projectile.height = 24;
            projectile.penetrate = 1;
            projectile.timeLeft = 180;
            Main.projFrames[projectile.type] = 5;
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override bool PreAI()
        {
            projectile.tileCollide = true;
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 67, 0f, 0f);

            {
                if (projectile.localAI[0] == 0f)
                {
                    AdjustMagnitude(ref projectile.velocity);
                    projectile.localAI[0] = 1f;
                }
                Vector2 move = Vector2.Zero;
                float distance = 400f;
                bool target = false;
                for (int k = 0; k < 200; k++)
                {
                    if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                    {
                        Vector2 newMove = Main.npc[k].Center - projectile.Center;
                        float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                        if (distanceTo < distance)
                        {
                            move = newMove;
                            distance = distanceTo;
                            target = true;
                        }
                    }
                }
                if (target)
                {
                    AdjustMagnitude(ref move);
                    projectile.velocity = (10 * projectile.velocity + move) / 11f;
                    AdjustMagnitude(ref projectile.velocity);
                }
                projectile.velocity.Y += projectile.ai[0];
                {
                    projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
                }

                projectile.frameCounter++;
                if (projectile.frameCounter >= 4)
                {
                    projectile.frameCounter = 0;
                    projectile.frame = (projectile.frame + 1) % 2;
                }

                return false;
            }


        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            Dust.NewDust(projectile.position + projectile.velocity * 0, projectile.width, projectile.height, 67, projectile.oldVelocity.X * 0, projectile.oldVelocity.Y * 0);
            return false;
        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(8) == 0)
            {
                target.AddBuff(BuffID.Frostburn, 300, true);
            }
        }
    }
}

