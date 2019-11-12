using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Events;
namespace DisorderUnderstar
{
    public abstract class DisorderUnderstarNPC : ModNPC
    {
        protected int State
        {
            get { return (int)npc.ai[0]; }
            set { npc.ai[0] = value; }
        }
        protected int Timer
        {
            get { return (int)npc.ai[1]; }
            set { npc.ai[1] = value; }
        }
        protected virtual void SwitchState(int state)
        {
            State = state;
        }
    }
}