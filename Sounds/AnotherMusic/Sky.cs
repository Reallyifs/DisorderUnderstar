using Terraria.ModLoader;
using Microsoft.Xna.Framework.Audio;
namespace DisorderUnderstar.Sounds.AnotherMusic
{
    public class Sky : ModSound
    {
        public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
        {
            if (soundInstance.State == SoundState.Playing) { return null; }
            soundInstance = sound.CreateInstance();
            soundInstance.Pan = pan;
            soundInstance.Volume = volume * 1.2f;
            return soundInstance;
        }
    }
}