using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class BgmManager : MonoBehaviour
{
  [SerializeField]
  private GameBgmPlayer _bgmPlayer;

  public void Awake()
  {
    _bgmPlayer.PlayBgm("BGM_2");
  }
}
