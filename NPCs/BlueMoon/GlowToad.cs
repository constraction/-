using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.BlueMoon
{
    public class GlowToad : ModNPC
    {
		int timer = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glow Toad");
            Main.npcFrameCount[npc.type] = 2;
        }
        public override void SetDefaults()
        {
            npc.width = 54;
            npc.height = 45;
            npc.damage = 25;
            npc.defense = 10;
            npc.lifeMax = 300;
            npc.HitSound = SoundID.NPCHit6;
            npc.DeathSound = SoundID.NPCDeath8;
            npc.value = 2000f;
            npc.knockBackResist = 0.5f;
           // npc.aiStyle = 26;
           // aiType = NPCID.Unicorn;

        }
		 public override void HitEffect(int hitDirection, double damage)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 6, hitDirection, -1f, 0, default(Color), 1f);
            }
            if (npc.life <= 0)
            {
			
                npc.position.X = npc.position.X + (float)(npc.width / 2);
                npc.position.Y = npc.position.Y + (float)(npc.height / 2);
                npc.width = 40;
                npc.height = 48;
                npc.position.X = npc.position.X - (float)(npc.width / 2);
                npc.position.Y = npc.position.Y - (float)(npc.height / 2);
                for (int num621 = 0; num621 < 200; num621++)
                {
                    int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 206, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num622].velocity *= 3f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num622].scale = 0.5f;
                        Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                    }
                }
              
            }
        }
		
		  public override void AI()
        {
          npc.TargetClosest(true);
            Player player = Main.player[npc.target];
			timer++;
			if (timer % 70 == 0)
			{
				npc.velocity.Y = -7;
				if (player.position.X > npc.position.X)
				{
					npc.velocity.X = 20;
					
					npc.netUpdate = true;
				}
				else
				{
					npc.velocity.X = -20;
					
					npc.netUpdate = true;
				}
			}
			if (player.position.X > npc.position.X)
				{
					npc.spriteDirection = 0;
				}
				else
				{
					npc.spriteDirection = 1;
				}
		}
		
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return MyWorld.BlueMoon ? 7f : 0f;
        }
       /* public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Alien1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Alien2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Alien2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Alien2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Alien2"), 1f);
            }
        }*/
        public override void FindFrame(int frameHeight)
        {
			if (!npc.collideY)
			{
			//	npc.frameCounter += 0.40f;
          //  npc.frameCounter %= 5;
           // int frame = (int)npc.frameCounter;
            npc.frame.Y = frameHeight;
			}
            else
			{
				npc.frame.Y = 0;
			}
        }
        
       
        
    }
}
