using Terraria.ModLoader;
using Microsoft.Xna.Framework.Audio;
namespace DisorderUnderstar.Sounds.Disorder
{
    public class DisorderEschatologyDeathSound : ModSound
    {
        public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
        {
            soundInstance = sound.CreateInstance();
            soundInstance.Pan = pan;
            soundInstance.Volume = volume * 1.5f;
            return soundInstance;
        }
    }
}