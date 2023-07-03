using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MainPresenter : MonoBehaviour
{
  [SerializeField]
  private CoinManager _coinModel;
  [SerializeField]
  private FacilityManager _facilityModel;
  [SerializeField]
  private MainView _view;

  // Start is called before the first frame update
  void Start()
  {
    _coinModel.Coin
    .Subscribe(x =>
    {
      _view.SetCoin(x);
    }).AddTo(this);
  }
}
