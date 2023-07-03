using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.Linq;

namespace SoundSystem
{
  public class SoundManager : MonoBehaviour
  {
    public static SoundManager Instance { get; private set; }

    public List<AudioClip> _seAudioClipList = new List<AudioClip>();
    private AudioSource _seAudioSource;

    public List<AudioClip> _bgmAudioClipList = new List<AudioClip>();
    private AudioSource _bgmAudioSource;

    public AudioMixerGroup _bgmAMG, _seAMG, _shakeAMG, _brastAMG;

    private void Awake()
    {
      //シングルトンの初期化
      if (Instance == null)
      {
        Instance = this;
        DontDestroyOnLoad(this);
      }
      else
      {
        Destroy(this);
        return;
      }

      _seAudioSource = InitializeAudioSource(this.gameObject, false, _seAMG);
      _bgmAudioSource = InitializeAudioSource(this.gameObject, true, _bgmAMG);
    }

    //AudioSourceの初期化
    private AudioSource InitializeAudioSource(GameObject parentGameObject, bool isLoop = false, AudioMixerGroup amg = null)
    {
      var audioSource = parentGameObject.AddComponent<AudioSource>();
      audioSource.loop = isLoop;
      audioSource.playOnAwake = false;

      if (amg != null)
      {
        audioSource.outputAudioMixerGroup = amg;
      }

      return audioSource;
    }

    //SEを再生
    public void PlaySe(string clipName)
    {
      var audioClip = _seAudioClipList.FirstOrDefault(clip => clip.name == clipName);

      if (audioClip == null)
      {
        Debug.Log("Error!!");
        return;
      }

      _seAudioSource.PlayOneShot(audioClip);
    }

    //BGMを再生
    public void PlayBgm(string clipName)
    {
      var audioClip = _bgmAudioClipList.FirstOrDefault(clip => clip.name == clipName);

      if (audioClip == null)
      {
        Debug.Log("Error!!");
        return;
      }

      _bgmAudioSource.Play(audioClip, 0.1f);
    }
  }
}
