using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

/////////////////////////////////////////// Sound Manager ///////////////////////////////////////////////////
// Manages sounds
// Contains a list of sounds from 0 to however many sounds you have
// Play a sound by passing the number of the sound into playSound - make a note of your sound numbers
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace MinigameRave
{
    class SoundManager
    {
        //Variables
        //List of Sounds
        List<SoundEffectInstance> sounds;

        //Gets overwritten a lot
        SoundEffect soundEffect;

        public SoundManager()
        {

        }

        public void playSound(int soundNumber, bool looped)
        {
            sounds[soundNumber].Play();

            if (looped)
                sounds[soundNumber].IsLooped = true;           
        }

        public void stopSound(int soundNumber)
        {
            sounds[soundNumber].Stop();
        }

        public void pauseSound(int soundNumber)
        {
            sounds[soundNumber].Pause();
        }

        public int loadSound(String gameName, params String[] soundName)
        {   
            String fileName;
            sounds = new List<SoundEffectInstance>();

            foreach (String s in soundName)
            {
                try
                {
                    fileName = "sounds/" + gameName + soundName;
                    soundEffect = globals.contentManager.Load<SoundEffect>(fileName);
                    sounds.Add(soundEffect.CreateInstance());
                }
                catch
                {
                    return 1;
                }

            }

            return 0;
        }
    }
}
