/*
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Items;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Items.Disorder;
namespace DisorderUnderstar.NPCs.Bosses.Disorder
{
    public class DisorderEschatology : DisorderUnderstarNPC
    {
        private bool DontTakeAnyDamage = false;
        private bool DropBossBagAlready;
        private bool EschatologyDeadNormally;
        private bool EschatologyDeadAbnormally;
        private readonly bool IsEchatologyActive = true;
        enum EschatologyAIType
        {
            The_Start,
            The_Frist,
            The_Second,
            The_Thrid,
            The_Last,
            The_Rest,
            The_BeKilledNormally,
            The_BeKilledAbnormally,
            The_KilledPlayer
        }
        enum Skill
        {
            Solor,
            Nebula,
            Vortex,
            Stardust
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·恐惧症");
        }
        public override void SetDefaults()
        {
            music = MusicID.Boss2;
            bossBag = ModContent.ItemType<DisorderEschatologyBossBag>();
            npc.boss = true;
            npc.value = Item.buyPrice(0, 10, 50, 10);
            npc.damage = Main.expertMode ? 267 : 186;
            npc.defense = Main.expertMode ? 113 : 67;
            npc.lifeMax = Main.expertMode ? 60170 : 43410;
            npc.noGravity = true;
            musicPriority = MusicPriority.BiomeHigh;
            npc.DeathSound = mod.GetLegacySoundSlot(SoundType.NPCKilled, "DisorderUnderstar/Sounds/Disorder/DisorderEschatologyDeathSound");
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0.0f;
            for (int i = 0; i < Main.maxBuffTypes; i++) { npc.buffImmune[i] = true; }
        }
        public override void AI()
        {
            int CheatINT = 0;
            CheatINT++;
            Player player = Main.player[npc.target];
            if ((player.dead && !player.active) || Main.dayTime) { SwitchState((int)EschatologyAIType.The_KilledPlayer); }
            else if ((npc.life < Main.rand.Next(10, 19) || !npc.active) && CheatINT > (Main.expertMode ? 1800 : 1500))
            {
                npc.life = Main.rand.Next(10, 19);
                SwitchState((int)EschatologyAIType.The_BeKilledNormally);
            }
            else if ((npc.life < Main.rand.Next(10, 19) || !npc.active) && CheatINT < (Main.expertMode ? 1800 : 1500))
            {
                npc.life = Main.rand.Next(10, 19);
                npc.lifeMax = npc.life;
                SwitchState((int)EschatologyAIType.The_BeKilledAbnormally);
            }
            else if (npc.life < npc.lifeMax / 5) { SwitchState((int)EschatologyAIType.The_Last); }
            switch ((EschatologyAIType)State)
            {
                case EschatologyAIType.The_Start:
                    {
                        DontTakeAnyDamage = true;
                        int tINT = 0;
                        tINT++;
                        话痨(tINT, player, Start: true);
                        break;
                    }
                case EschatologyAIType.The_Frist:
                    {
                        DontTakeAnyDamage = false;
                        话痨(0, player, Frist: true);
                        break;
                    }
                case EschatologyAIType.The_Second:
                    {
                        DontTakeAnyDamage = false;
                        break;
                    }
                case EschatologyAIType.The_Thrid:
                    {
                        DontTakeAnyDamage = false;
                        break;
                    }
                case EschatologyAIType.The_Last:
                    {
                        DontTakeAnyDamage = false;
                        break;
                    }
                case EschatologyAIType.The_Rest:
                    {
                        DontTakeAnyDamage = true;
                        int tINT = 0;
                        tINT++;
                        话痨(tINT, player, Rest: true);
                        EschatologyAiSet((int)EschatologyAIType.The_Rest, player);
                        break;
                    }
                case EschatologyAIType.The_BeKilledNormally:
                    {
                        DontTakeAnyDamage = true;
                        EschatologyDeadNormally = true;
                        EschatologyDeadAbnormally = false;
                        int tINT = 0;
                        tINT++;
                        话痨(tINT, player, BeKilledNormally: true);
                        EschatologyAiSet((int)EschatologyAIType.The_BeKilledNormally, player);
                        break;
                    }
                case EschatologyAIType.The_BeKilledAbnormally:
                    {
                        DontTakeAnyDamage = true;
                        EschatologyDeadNormally = false;
                        EschatologyDeadAbnormally = true;
                        int tINT = 0;
                        tINT++;
                        话痨(tINT, player, BeKilledAbnomally: true);
                        EschatologyAiSet((int)EschatologyAIType.The_BeKilledAbnormally, player);
                        break;
                    }
                case EschatologyAIType.The_KilledPlayer:
                    {
                        DontTakeAnyDamage = true;
                        EschatologyDeadNormally = false;
                        EschatologyDeadAbnormally = true;
                        int tINT = 0;
                        tINT++;
                        话痨(tINT, player, KilledPlayer: true);
                        EschatologyAiSet((int)EschatologyAIType.The_KilledPlayer, player);
                        break;
                    }
            }
        }
        #region 伤害&&生成判定
        public override bool CheckDead() => false;
        public override bool? CanHitNPC(NPC target) => DontTakeAnyDamage ? false : true;
        public override bool CheckActive() => false;
        public override bool CanHitPlayer(Player target, ref int cooldownSlot) => DontTakeAnyDamage ? false : true;
        public override bool? CanBeHitByItem(Player player, Item item) => DontTakeAnyDamage ? false : true;
        public override bool CanTownNPCSpawn(int numTownNPCs, int money) => IsEchatologyActive ? false : true;
        public override void ModifyHitByItem(Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {
            if (!DontTakeAnyDamage)
            {
                damage -= npc.defense;
                if (Main.rand.Next(1, 10) <= 1)
                {
                    Vector2 tVEC = Vector2.Normalize(player.Center - npc.Center);
                    if (Main.rand.NextBool()) { tVEC.X += Main.rand.Next(1, 4); }
                    if (Main.rand.NextBool()) { tVEC.X -= Main.rand.Next(1, 4); }
                    if (Main.rand.NextBool()) { tVEC.Y += Main.rand.Next(1, 4); }
                    if (Main.rand.NextBool()) { tVEC.Y -= Main.rand.Next(1, 4); }
                    var nPRO = Projectile.NewProjectileDirect(npc.Center, tVEC, 1, damage, knockback, npc.whoAmI);
                    nPRO.friendly = false;
                }
            }
            else { damage = 0; }
        }
        public override bool? CanBeHitByProjectile(Projectile projectile) => DontTakeAnyDamage ? false : true;
        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (!DontTakeAnyDamage)
            {
                damage -= npc.defense;
                npc.immune[projectile.type] = 2;
                if (Main.rand.Next(1, 4) <= 1)
                {
                    var nPRO = Projectile.NewProjectileDirect(npc.Center, -projectile.velocity + Main.player[projectile.owner].velocity * 4,
                        projectile.type, damage * 3, knockback, npc.whoAmI);
                    nPRO.hostile = true;
                    nPRO.friendly = false;
                }
            }
            else { damage = 0; }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo) => 0;
        #endregion
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ModContent.ItemType<LikeLifeLine>();
        }
        public override void NPCLoot()
        {
            if (EschatologyDeadAbnormally || !EschatologyDeadNormally || DropBossBagAlready) { return; }
            int PlayerLife = Main.player[npc.target].statLife;
            if (PlayerLife > 500) { PlayerLife = 500; }
            int rINT = Main.rand.Next(1, PlayerLife);
            int rINT1 = Main.rand.Next(1, rINT);
            int rINT2 = rINT - rINT1;
            if (rINT2 <= 0) { rINT2 = 1; }
            int rINT3 = Main.rand.Next(1, rINT2);
            Item.NewItem((int)npc.velocity.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Star, Main.rand.Next(17, 24));
            Item.NewItem((int)npc.velocity.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart, Main.rand.Next(84, 142));
            if (Main.expertMode) { npc.DropBossBags(); }
            if (rINT1 <= 1)
            {
                Item.NewItem(Main.player[npc.target].Center, ModContent.ItemType<DisorderCross>());
                return;
            }
            else if (rINT3 <= 1) { Item.NewItem(Main.player[npc.target].Center, ModContent.ItemType<DisorderSummoned>()); }
        }
        private void 话痨(int tINT, Player player, bool Start = false, bool Frist = false, bool Second = false, bool Thrid = false,
            bool Last = false, bool Rest = false, bool BeKilledNormally = false, bool BeKilledAbnomally = false, bool KilledPlayer = false)
        {
            if (Start)
            {
                if (tINT == 0)
                {
                    string 时间 = Main.dayTime ? "日辉" : "夜光";
                    Main.NewText("遥远的地平线藏起了" + 时间 + "。", Color.OrangeRed);
                }
                else if (tINT == 180)
                {
                    string 时间 = Main.dayTime ? "加速至" : "暂停在";
                    string 时间2 = Main.dayTime ? "的起点" : null;
                    Main.NewText("时间" + 时间 + "黑夜" + 时间2 + "。", Color.Orange);
                }
                else if (tINT == 360) { Main.NewText("静夜将指示那场命运的战斗……", Color.Yellow); }
                else if (tINT == 540) { Main.NewText("“这就是最后了？”", Color.YellowGreen); }
                else if (tINT == 720) { Main.NewText("或许……", Color.Orange); }
                else if (tINT == 900)
                {
                    Main.NewText("还没有！！！", Color.OrangeRed);
                    if (Main.dayTime) { Main.time = 54000; }
                    SwitchState((int)EschatologyAIType.The_Frist);
                }
                if (tINT >= 180 && Main.time < 54000 && Main.dayTime) { Main.time += 10; }
                else if (tINT >= 180 && !Main.dayTime) { Main.time--; }
            }
            else if (BeKilledNormally)
            {
                if (tINT == 180) { Main.NewText("看来，是我战败了呢……", Color.Orange); }
                else if (tINT == 360) { Main.NewText("很高兴，能与你战斗到现在。", Color.Orange); }
                else if (tINT == 540)
                {
                    npc.life = 0;
                    npc.DropBossBags();
                    DropBossBagAlready = true;
                    Main.NewText("那么，告辞。", Color.Yellow);
                }
                if (tINT >= 0 && !Main.dayTime && Main.time < 54000) { Main.time += 10; }
            }
            else if (BeKilledAbnomally)
            {
                if (tINT == 600) { Main.NewText("这可是，你自己选择的。", Color.Red); }
                if (tINT >= 600 && !Main.dayTime && Main.time < 54000) { Main.time += 10; }
            }
            else if (KilledPlayer)
            {
                if (tINT == 60) { Main.NewText("这就是你的真正实力么……", Color.Orange); }
                else if (tINT == 120) { Main.NewText("不，我相信不是。（笑）", Color.Orange); }
                else if (tINT == 180) { Main.NewText("那么，期待与你的下次见面。", Color.Orange); }
                if (tINT > 180)
                {
                    Main.time = 54000;
                    npc.velocity.Y += npc.width * 2;
                    if (npc.velocity.Y > player.Center.Y + Main.sectionHeight * 2) { npc.life = 0; }
                }
                else if (tINT > 60 && !Main.dayTime && Main.time < 54000) { Main.time += 10; }
            }
        }
        private void 技能(int 型, int 式)
        {
            if (型 == (int)Skill.Solor) { }
            else if (型 == (int)Skill.Nebula) { }
            else if (型 == (int)Skill.Vortex) { }
            else if (型 == (int)Skill.Stardust) { }
        }
        private void EschatologyAiSet(int AI设置, Player player)
        {
            if (AI设置 == (int)EschatologyAIType.The_Rest) { npc.velocity *= 0.4f; }
            else if (AI设置 == (int)EschatologyAIType.The_BeKilledAbnormally)
            {
                npc.FindClosestPlayer(out float dis);
                Vector2 tVEC = Vector2.Normalize(player.Center - npc.Center) * dis;
                npc.velocity += tVEC * player.velocity;
            }
            else if (AI设置 == (int)EschatologyAIType.The_KilledPlayer) { npc.velocity *= 0.2f; }
        }
    }
}
*/