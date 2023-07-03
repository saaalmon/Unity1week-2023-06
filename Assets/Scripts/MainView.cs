using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MainView : MonoBehaviour
{
  [SerializeField]
  private TextMeshProUGUI _coin;

  public void SetCoin(double coin)
  {
    _coin.text = coin.ToString("N0");

    var seq = DOTween.Sequence()
      .OnStart(() =>
      {
        _coin.transform.localScale = Vector3.one * 1.4f;
      })
      .Append(_coin.transform.DOScale(1.0f, 0.1f))
      .Play();
  }
}
