using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundVolumer : MonoBehaviour
{
  [SerializeField]
  private AudioMixer _audioMixer;

  [SerializeField]
  private float _bgmVol;
  [SerializeField]
  private float _seVol;

  void Start()
  {
    _audioMixer.SetFloat("BGMVol", _bgmVol);
    _audioMixer.SetFloat("SEVol", _seVol);
  }

  public void SetBGM(float volume)
  {
    _audioMixer.SetFloat("BGMVol", volume);

    Debug.Log(volume);
  }

  public void SetSE(float volume)
  {
    _audioMixer.SetFloat("SEVol", volume);

    Debug.Log(volume);
  }
}
