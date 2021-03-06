using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SpiritMod.Buffs.Pet
{
	public class JellyfishBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Boop");
			Description.SetDefault("'The Jellyfish is helping you relax'");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.AddBuff(BuffID.PeaceCandle, 2);
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<MyPlayer>(mod).jellyfishPet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("JellyfishPet")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("JellyfishPet"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}