using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioSourceExtensions
{
  public static void Play(this AudioSource audioSource, AudioClip audioClip = null, float volume = 1f)
  {
    if (audioClip != null)
    {
      audioSource.clip = audioClip;

      audioSource.volume = Mathf.Clamp01(volume);
      audioSource.Play();
    }
  }
}
