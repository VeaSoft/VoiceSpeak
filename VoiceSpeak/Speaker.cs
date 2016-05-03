using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SpeechLib;
namespace VoiceSpeak
{
    class Speaker
    {
        SpVoice voice;
        public void speak(object text)
        {            
            lock(this)
            {
                voice= new SpVoice();
                voice.Volume = 100;                
                voice.Speak((string)text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                voice.WaitUntilDone(Timeout.Infinite);
                
            }

        }
        public void pause()
        {
            
            if (voice != null)
            {
                voice.Pause();
            }
        }
    }
}
