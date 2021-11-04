using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public SFXData Data;
    public AudioSource SFXSource;
    public AudioSource SoundtrackSource;

    private void Start()
    {
    }
    public void PlayFlap()
    {
        var rnd = UnityEngine.Random.Range(0, Data.SFX_Flaps.Length);
        SFXSource.clip = Data.SFX_Flaps[rnd];
        SFXSource.Play ();
        //TODO play the sound
    }

    public void PlayCollide()
    {
        var rnd = UnityEngine.Random.Range(0, Data.SFX_Collide.Length);
        SFXSource.clip = Data.SFX_Collide[rnd];
        SFXSource.Play ();
        //TODO play the sound
    }

    public void PlayGameOver()
    {
        var rnd = UnityEngine.Random.Range(0, Data.SFX_GameOver.Length);
        SoundtrackSource.clip = Data.SFX_GameOver[rnd];
        SoundtrackSource.loop = false;
        SoundtrackSource.Play ();
        //TODO play the sound
    }

    public void StopSoundtrack()
    {
        SoundtrackSource.Stop ();
    }
}
