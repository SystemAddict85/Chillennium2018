using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New SoundObject", menuName = "ScriptableObjects/Sound", order = 3)]
public class SoundObject : ScriptableObject
{
    public enum StatusEffect { None, Bleed, Poison, Paralyze, Drain };

    public string soundName = "New Sound";
    public AudioClip[] soundEffects;   // sound made when used; may use multiple for variance

    [MinMaxRange(0f,2f)]
    public RangedFloat pitch;

    [MinMaxRange(0f, 2f)]
    public RangedFloat volume;

    public void PlayAudio(AudioSource source)
    {        
        var randVol = Random.Range(volume.minValue, volume.maxValue);
        var randPitch = Random.Range(pitch.minValue, pitch.maxValue);
        var randClip = Random.Range(0, soundEffects.Length);
        source.loop = false;

        source.volume = randVol;
        source.pitch = randPitch;
        source.clip = soundEffects[randClip];
        source.Play();
        
    }




}
