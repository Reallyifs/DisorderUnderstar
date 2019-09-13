using Terraria;
using DisorderUnderstar;
using Terraria.ModLoader;
using Terraria.Localization;
using DisorderUnderstar.Texts;
namespace DisorderUnderstar.Cheats
{
    public class RealityKiller : ModItem
    {
        private readonly bool 你真的以为这个物品能使用 = true;
        private readonly bool 别想了 = true;
        private readonly bool 我劝你啊 = true;
        private readonly bool 还是自己写代码比较好 = true;
        private bool _这个物品能否使用判定 = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reality ` Killer");
            DisplayName.AddTranslation(GameCulture.Chinese, "现实·杀手");
            Tooltip.SetDefault("It has a stonger power...\n" +
                "There are also extremely severe conditions for use...");
            Tooltip.AddTranslation(GameCulture.Chinese, "它拥有非常强大的力量……\n" +
                "同时也有非常严峻的使用条件……");
        }
        public override void SetDefaults()
        {
            item.axe = 1;
            item.crit = 1;
            item.mana = 1;
            item.pick = 1;
            item.alpha = 1;
            item.magic = true;
            item.melee = true;
            item.noWet = true;
            item.scale = 1;
            item.shoot = 1;
            item.owner = 1;
            item.width = 1;
            item.damage = 1;
            item.hammer = 1;
            item.height = 1;
            item.active = true;
            item.expert = true;
            item.ranged = true;
            item.summon = true;
            item.thrown = true;
            item.channel = true;
            item.noMelee = true;
            item.notAmmo = true;
            item.ownTime = 1;
            item.useAmmo = 1;
            item.useTime = 1;
            item.useTurn = true;
            item.healLife = 1;
            item.healMana = 1;
            item.useStyle = 1;
            item.accessory = true;
            item.autoReuse = true;
            item.favorited = true;
            item.holdStyle = 1;
            item.lifeRegen = 1;
            item.instanced = true;
            item.ownIgnore = 1;
            item.consumable = true;
            item.expertOnly = true;
            item.shootSpeed = 1;
            item.noGrabDelay = 1;
            item.manaIncrease = 1;
            item.noUseGraphic = true;
            item.useAnimation = 1;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            int _0 = 0; _0 += 1;
            if (你真的以为这个物品能使用 && 别想了 && 我劝你啊 && 还是自己写代码比较好 && _这个物品能否使用判定 == false)
            {
                player.dead = true;
                _这个物品能否使用判定 = true;
            }
            if (_0 >= 300 && _这个物品能否使用判定 == true)
            {
                _0 = 0;
                player.statLifeMax = 1;
                _这个物品能否使用判定 = false;
            }
        }
        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<HumanHistory>().CheatItem == false)
            {
                player.GetModPlayer<HumanHistory>().CheatItem = true;
                player.GetModPlayer<HumanHistory>().IsReading = true;
            }
            else
            {
                player.GetModPlayer<HumanHistory>().CheatItem = false;
                player.GetModPlayer<HumanHistory>().IsReading = false;
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe _0 = new ModRecipe(mod)
            {
                alchemy = true,
                anySand = true,
                anyWood = true,
                needLava = true,
                needHoney = true,
                needWater = true,
                anyIronBar = true,
                anyFragment = true,
                needSnowBiome = true,
                anyPressurePlate = true,
            };
            _0.AddIngredient(1, 1);
            _0.AddTile(1);
            _0.SetResult(this);
            _0.AddRecipe();
        }
    }
}
