using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class SoundTest : MonoBehaviour
{
  private GameSePlayer _se;

  // Start is called before the first frame update
  void Start()
  {
    _se = GetComponent<GameSePlayer>();

    //SoundManager.Instance.PlayBgm("BGM_2");
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      _se.PlaySe("Brast");
    }

    if (Input.GetMouseButtonDown(1))
    {
      _se.PlaySe("Shake");
    }
  }
}
