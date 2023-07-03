using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;
using UniRx.Triggers;
using Cinemachine;
using SoundSystem;

public class CarboManager : MonoBehaviour
{
  [SerializeField]
  private GameSePlayer _sePlayer;

  [SerializeField]
  private CinemachineImpulseSource _impulse;
  [SerializeField]
  private CoinManager _coinManager;

  private List<int> _carboCount = new List<int>();

  //private int[] _carboCount = new int[10];

  public IReactiveCollection<Carbo> Carbos => _carbos;
  private readonly ReactiveCollection<Carbo> _carbos = new ReactiveCollection<Carbo>();

  // Start is called before the first frame update
  void Start()
  {

  }

  void Update()
  {

  }

  public Carbo CreateCarbo(Carbo instance)
  {
    if (_carbos.Count == 0)
    {
      Debug.Log("error!!");
      return null;
    }

    var carbo = Instantiate(instance, transform.position, Quaternion.identity);
    var num = _carbos.IndexOf(instance);
    carbo.Init(_carboCount[num]);

    //クリックしたとき振動させる
    carbo.UpdateAsObservable()
    .Subscribe(_ =>
    {
      if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && carbo.Count.Value > 0)
      {
        carbo.CountDown();
      }
    })
    .AddTo(carbo);

    //カウントが0になったとき終了処理する
    carbo.Count
    .Subscribe(x =>
    {
      if (x <= 0)
      {
        _sePlayer.PlaySe("Brast");

        _coinManager.Coiner += carbo.CoinInc.Value;

        _impulse.GenerateImpulse();
        carbo.Brast();
        CreateCarbo(instance);
      }
      else
      {
        _sePlayer.PlaySe("Shake");

        carbo.Shake();
      }
    })
    .AddTo(carbo);


    // Debug.Log(_carbos.Count);

    // var rand = Random.Range(0, _carbos.Count);
    // var carbo = Instantiate(_carbos[rand], transform.position, Quaternion.identity);
    // carbo.Init(_carboCount[rand]);

    // //クリックしたとき振動させる
    // carbo.UpdateAsObservable()
    // .Subscribe(_ =>
    // {
    //   if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && carbo.Count.Value > 0)
    //   {
    //     carbo.CountDown();
    //   }
    // })
    // .AddTo(carbo);

    // //カウントが0になったとき終了処理する
    // carbo.Count
    // .Subscribe(x =>
    // {
    //   if (x <= 0)
    //   {
    //     _coinManager.Coiner += carbo.CoinInc.Value;

    //     carbo.Brast();
    //     CreateCarbo();
    //   }
    //   else
    //   {
    //     carbo.Shake();
    //   }
    // })
    // .AddTo(carbo);

    return carbo;
  }

  public void SearchCarbo(Carbo carbo, int count)
  {
    var num = _carbos.IndexOf(carbo);

    if (num >= 0)
    {
      Debug.Log("あります");
      _carboCount[num] = count;
    }
    else
    {
      Debug.Log("ありません");

      return;
    }
  }

  public void AddCarbo(Carbo instance, int count)
  {
    _carbos.Add(instance);
    _carboCount.Add(count);

    CreateCarbo(instance);
  }
}
