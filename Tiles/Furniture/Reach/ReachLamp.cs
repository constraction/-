using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SpiritMod.Tiles.Furniture.Reach {
public class ReachLamp : ModTile
{
    public override void SetDefaults()
    {
      			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
					Main.tileLighted[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
			TileObjectData.newTile.Height = 3;
						TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16,
				16,
				16
			};
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Elderbark Lamp");
			AddMapEntry(new Color(200, 200, 200), name);
			dustType = mod.DustType("Pixel");
    }
	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 1.0f;
        g = 0.9f;
        b = 0.8f;
    }
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(i * 16, j * 16, 48, 32, mod.ItemType("ReachLampItem"));
    }
}}