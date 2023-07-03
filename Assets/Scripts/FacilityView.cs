using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FacilityView : MonoBehaviour
{
  [SerializeField]
  private Button _button;
  [SerializeField]
  private Image _icon;
  [SerializeField]
  private TextMeshProUGUI _name;
  [SerializeField]
  private TextMeshProUGUI _needCoin;
  [SerializeField]
  private TextMeshProUGUI _count;

  public void SetIcon(Sprite sprite)
  {
    _icon.sprite = sprite;
  }

  public void SetName(string name)
  {
    _name.text = name;
  }

  public void SetCoinNeed(float coin)
  {
    if (coin == -1) _needCoin.text = "-";
    else _needCoin.text = coin.ToString("N0");
  }

  public void SetCount(int count)
  {
    _count.text = count.ToString();
  }

  public void SetInteractable(bool isbuyable)
  {
    _button.interactable = isbuyable;
  }

  public Button GetButton()
  {
    return _button;
  }
}
