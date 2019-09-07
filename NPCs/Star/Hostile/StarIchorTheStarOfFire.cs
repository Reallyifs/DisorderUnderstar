using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Items.Star;
namespace DisorderUnderstar.NPCs.Star.Hostile
{
    public class StarIchorTheStarOfFire : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("灵液火之星");
        }
        public override void SetDefaults()
        {
            aiType = NPCID.EyeofCthulhu;
            animationType = NPCID.MeteorHead;
            npc.damage = 40;
            npc.defense = 15;
            npc.lifeMax = 2400;
            npc.friendly = false;
            npc.lifeRegen = 9;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0.1f;
            npc.buffImmune[BuffID.Ichor] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.Confused] = true;
            banner = npc.type;
            bannerItem = mod.ItemType<FireOfStarZero>();
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, damage * 2);
            target.AddBuff(BuffID.Ichor, 6000 / damage);
            target.AddBuff(BuffID.BrokenArmor, (target.statLife * target.statDefense) / target.statMana);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.dayTime) return SpawnCondition.Crimson.Chance * 0.1f;
            else if (!Main.dayTime) return SpawnCondition.Crimson.Chance * 0.2f;
            return 0.0f;
        }
        public override void NPCLoot()
        {
            #region 掉落
            Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y, npc.width, npc.height, ItemID.SilverCoin, 31);
            Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y, npc.width, npc.height, ItemID.CopperCoin, 72);
            if (Main.rand.Next(0, 100) < 1) Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y, npc.width, npc.height, ItemID.DepthMeter);
            else if (Main.rand.Next(0, 99) < 1) Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y, npc.width, npc.height, ItemID.Compass);
            if (Main.rand.Next(0, 5) < 1) Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y, npc.width, npc.height,
                 mod.ItemType<FireOfStarZero>(), 1);
            else if (Main.rand.Next(0, 10) < 1) Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y, npc.width, npc.height,
                 mod.ItemType<FireOfStarZero>(), 2);
            else if (Main.rand.Next(0, 20) < 1) Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y, npc.width, npc.height,
                 mod.ItemType<FireOfStarZero>(), 3);
            if (Main.hardMode)
            {
                if (Main.rand.Next(0, 15) < 1) Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y, npc.width, npc.height,
                     mod.ItemType<FireOfStarZero>(), 3);
                else if (Main.rand.Next(0, 5) < 1) Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y, npc.width, npc.height,
                     mod.ItemType<FireOfStarZero>(), 2);
                else if (Main.rand.Next(0, 1) < 1) Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y, npc.width, npc.height,
                     mod.ItemType<FireOfStarZero>(), 1);
                if (Main.rand.Next(0, 4) < 1) Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y, npc.width, npc.height, ItemID.Ichor, 2);
            }
            #endregion
        }
    }
}