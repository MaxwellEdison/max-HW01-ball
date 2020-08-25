using UnityEngine;

public static class AudioHelper
{
    public static AudioSource PlayClip2D (AudioClip clip, float volume)
    {
        //create the audio
        GameObject audioObject = new GameObject("Audio2D");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        //configure the audio
        audioSource.clip = clip;
        audioSource.volume = volume;
        //activate audio
        audioSource.Play();
        Object.Destroy(audioObject, clip.length);
        //return in case further use
        return audioSource;
    }
}
