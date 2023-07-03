using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using SoundSystem;

public class FacilityManager : MonoBehaviour
{
  private const int _fps = 60;

  [SerializeField]
  private GameSePlayer _sePlayer;

  [SerializeField]
  private CarboManager _carboManager;
  [SerializeField]
  private CoinManager _coinManager;
  [SerializeField]
  private Transform _parent;
  [SerializeField]
  private Facility[] _facility;
  [SerializeField]
  private int _countMax;

  public IReadOnlyReactiveProperty<float> CoinInc => _coinInc;
  private readonly FloatReactiveProperty _coinInc = new FloatReactiveProperty(0);

  public IReactiveCollection<Facility> Facilities => _facilities;
  private readonly ReactiveCollection<Facility> _facilities = new ReactiveCollection<Facility>();

  void Awake()
  {
    Application.targetFrameRate = _fps;

    for (var i = 0; i < _facility.Length; i++)
    {
      var facility = CreateFacility(i);

      _facilities.Add(facility);

      //ボタンを押せるか常に監視
      facility.UpdateAsObservable()
      .Subscribe(_ => facility.FacilityBuy(_coinManager.Coin.Value))
      .AddTo(this);

      //レベルが変化したときコインを減らす
      facility.Count
      .Subscribe(x =>
      {
        _sePlayer.PlaySe("Buy");

        if (x == 1)
        {
          _carboManager.AddCarbo(facility.GetCarbo(), x);
        }
        else //if (x > 1)
        {
          _carboManager.SearchCarbo(facility.GetCarbo(), x);
        }

        if (_coinManager.Coiner >= facility.CoinNeed.Value) _coinManager.Coiner -= facility.CoinNeed.Value;
      }).AddTo(this);

      //増加量が変化したとき合計増加量を計算
      // facility.CoinInc
      // .Subscribe(_ =>
      // {
      //   _coinInc.Value = CoinIncSum();
      // }).AddTo(this);
    }
  }

  void Start()
  {
    //SoundManager.Instance.PlayBgm("BGM_2");
  }

  void Update()
  {
    //_coinManager.Coiner += _coinInc.Value / _fps;
  }

  // private float CoinIncSum()
  // {
  //   var inc = 0f;

  //   foreach (var p in Facilities)
  //   {
  //     inc += p.CoinInc.Value;
  //   }

  //   return inc;
  // }

  private Facility CreateFacility(int count)
  {
    var facility = Instantiate(_facility[count], _parent, false);
    facility.Init(_countMax);

    return facility;
  }
}
