using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace SoundSystem
{
  [RequireComponent(typeof(AudioSource))]
  public class GameBgmPlayer : MonoBehaviour
  {
    public AudioSource _audioSource;
    public List<AudioClip> _audioClipList = new List<AudioClip>();

    public void PlayBgm(string audioClipName)
    {
      var AudioClip = _audioClipList.FirstOrDefault(clip => clip.name == audioClipName);

      if (AudioClip != null)
      {
        _audioSource.pitch = 1f;
        _audioSource.Play(AudioClip);

        Debug.Log(AudioClip.name);
      }
    }

    public void Reset()
    {
      _audioSource = GetComponent<AudioSource>();
      _audioSource.playOnAwake = false;
      _audioSource.spatialBlend = 0.7f;
    }
  }
}