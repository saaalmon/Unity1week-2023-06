using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Facility : MonoBehaviour
{
  [SerializeField]
  private Carbo _carbo;
  [SerializeField]
  private Sprite _icon;
  [SerializeField]
  private string _name;
  // [SerializeField]
  // private int _coinBase;
  [SerializeField]
  private int _coinNeedBase;
  [SerializeField]
  private int _countBase;

  private int _countMax;

  public IReadOnlyReactiveProperty<int> CoinNeed => _coinNeed;
  private readonly IntReactiveProperty _coinNeed = new IntReactiveProperty(0);

  public IReadOnlyReactiveProperty<bool> IsBuyable => _isBuyable;
  private readonly BoolReactiveProperty _isBuyable = new BoolReactiveProperty();

  public IReadOnlyReactiveProperty<int> Count => _count;
  private readonly IntReactiveProperty _count = new IntReactiveProperty(0);

  // public IReadOnlyReactiveProperty<float> CoinInc => _coinInc;
  // private readonly FloatReactiveProperty _coinInc = new FloatReactiveProperty(0);

  public void Init(int countMax)
  {
    _count.Value = _countBase;
    _countMax = countMax;

    CalcCoinNeed();
  }

  public void CountUp()
  {
    _count.Value++;
    // _coinInc.Value = _coinBase * _count.Value;

    CalcCoinNeed();
  }

  public void CalcCoinNeed()
  {
    if (_count.Value >= _countMax)
    {
      _coinNeed.Value = -1;
      return;
    }

    _coinNeed.Value = _coinNeedBase * (_count.Value + 1);

    Debug.Log(_coinNeed.Value);
  }

  public void FacilityBuy(double coin)
  {
    if (_count.Value >= _countMax)
    {
      _isBuyable.Value = false;
      return;
    }

    //SoundManager.Instance.PlaySe("Buy");

    _isBuyable.Value = coin >= _coinNeed.Value;
  }

  public Sprite GetIcon()
  {
    return _icon;
  }

  public string GetName()
  {
    return _name;
  }

  public Carbo GetCarbo()
  {
    return _carbo;
  }
}