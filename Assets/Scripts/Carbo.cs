using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;
using DamageNumbersPro;

public class Carbo : MonoBehaviour
{
  [SerializeField]
  private DamageNumber _coinIncView;
  [SerializeField]
  private GameObject _line;
  [SerializeField]
  private int _countMax;
  [SerializeField]
  private double _coinbase;
  [SerializeField]
  private Vector2 _pos;
  [SerializeField]
  private float _timerInterval;

  private bool _isShake;

  public IReadOnlyReactiveProperty<double> CoinInc => _coinInc;
  private readonly DoubleReactiveProperty _coinInc = new DoubleReactiveProperty(0);

  public IReadOnlyReactiveProperty<int> Count => _count;
  private readonly IntReactiveProperty _count = new IntReactiveProperty(0);

  public void Init(int count)
  {
    transform.position = _pos;

    var seq = DOTween.Sequence()
    .OnStart(() =>
    {
      transform.localScale = Vector3.zero;
    })
    .Append(transform.DOScale(Vector3.one, 0.4f))
    .Play();

    _isShake = true;
    _count.Value = _countMax;
    _coinInc.Value = _coinbase * count;


    //オートクリック
    Observable.Interval(System.TimeSpan.FromSeconds(_timerInterval))
    .Where(_ => _isShake == true)
    .Subscribe(_ =>
    {
      CountDown();
    }).AddTo(this);


    Debug.Log(count);
  }

  public void CountDown()
  {
    _count.Value--;
  }

  public void Shake()
  {
    if (!_isShake) return;

    var seq = DOTween.Sequence()
    .Append(transform.DOPunchPosition(Vector2.up * 1f, 0.5f, 10, 5))
    .OnComplete(() =>
    {
      transform.position = _pos;
    })
    .Play();
  }

  public void Brast()
  {
    _isShake = false;

    transform.DOLocalRotate(Vector3.forward * 720f, 1f, RotateMode.FastBeyond360)
    .Play();

    var seq = DOTween.Sequence()
    .Append(transform.DOMoveY(3.0f, 0.5f).SetEase(Ease.OutCubic))
    .Append(transform.DOMoveY(-8.0f, 0.5f).SetEase(Ease.InCubic))
    .OnComplete(() =>
    {
      Destroy(gameObject);
    })
    .Play();


    var line = Instantiate(_line, _pos, Quaternion.identity);

    var lineSeq = DOTween.Sequence()
    .Append(line.transform.DOScaleX(0f, 0.5f).SetEase(Ease.OutElastic))
    .OnComplete(() =>
    {
      Destroy(line);
    })
    .Play();


    _coinIncView.Spawn(_pos, (float)_coinInc.Value);
  }
}
