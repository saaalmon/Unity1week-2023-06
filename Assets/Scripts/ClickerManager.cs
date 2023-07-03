using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;

public class ClickerManager : MonoBehaviour
{
  [SerializeField]
  private CoinManager _coinManager;
  [SerializeField]
  private int _coinBase;

  public IReadOnlyReactiveProperty<float> CoinInc => _coinInc;
  private readonly FloatReactiveProperty _coinInc = new FloatReactiveProperty(0);

  // Start is called before the first frame update
  void Awake()
  {
    _coinInc.Value += _coinBase;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
    {
      _coinManager.Coiner += _coinInc.Value;
    }
  }
}
