using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CoinManager : MonoBehaviour
{
  [SerializeField]
  private double _coinMax;

  public double Coiner
  {
    get
    {
      return _coin.Value;
    }
    set
    {
      _coin.Value = value;

      if (_coin.Value >= _coinMax) _coin.Value = _coinMax;
    }
  }

  public IReadOnlyReactiveProperty<double> Coin => _coin;
  private readonly DoubleReactiveProperty _coin = new DoubleReactiveProperty(0);
}
