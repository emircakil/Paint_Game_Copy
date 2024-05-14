using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource paintballSound;
    [SerializeField] AudioSource starSound;
    [SerializeField] AudioSource buttonSound;
    bool isMusicOff = true;
    bool isAudioOff = true;

    public void setMusic() {

        if (isMusicOff)
        {

            isMusicOff = false;
            music.volume = 0;
        }
        else { 
        
            isMusicOff = true;
            music.volume = 0.3f;
        }
    }

    public void setAudio() {

        if (isAudioOff)
        {
            isAudioOff = false;
            paintballSound.volume = 0;
            starSound.volume = 0;
            buttonSound.volume = 0;
        }
        else {
            isAudioOff= true;
            paintballSound.volume = 1;
            starSound.volume = 1;
            buttonSound.volume = 1;
        }
    
    }
}
