using System.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace DisorderUnderstar
{
    public class DisorderUnderstarWorld : ModWorld
    {
        public static bool downedMeteorTidal;
        public static bool downedDisorderEschatology;
        public override void Initialize()
        {
            downedMeteorTidal = false;
            downedDisorderEschatology = false;
        }
        public override TagCompound Save()
        {
            var modOpen = new List<string>();
            if (DisorderUnderstar.Difficulty == (int)DifficultyMode.Nightmare) { modOpen.Add("DUNightmareOpened"); }
            else if (DisorderUnderstar.Difficulty == (int)DifficultyMode.Hell) { modOpen.Add("DUHellModOpened"); }
            var downed = new List<string>();
            if (downedMeteorTidal) { downed.Add("MeteorTidal"); }
            if (downedDisorderEschatology) { downed.Add("DisorderEschatology"); }
            return new TagCompound
            {
                ["DisorderUnderstarDowned"] = downed,
                ["DisorderUnderstarModOpened"] = modOpen
            };
        }
        public override void Load(TagCompound tag)
        {
            var modOpen = tag.Get<string>("DisorderUnderstarModOpened");
            if (modOpen.Contains("DUNightmareModOpened")) { DisorderUnderstar.Difficulty = (int)DifficultyMode.Nightmare; }
            else if (modOpen.Contains("DUHellModOpened")) { DisorderUnderstar.Difficulty = (int)DifficultyMode.Hell; }
            var downed = tag.Get<string>("DisorderUnderstarDowned");
            downedMeteorTidal = downed.Contains("MeteorTidal");
            downedDisorderEschatology = downed.Contains("DisorderEschatology");
        }
        public override void LoadLegacy(BinaryReader reader)
        {

        }
    }
}