using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class FacilityPresenter : MonoBehaviour
{
  public void OnCreateFacility(Facility facility, FacilityView view)
  {
    view.SetIcon(facility.GetIcon());
    view.SetName(facility.GetName());

    facility.CoinNeed
    .Subscribe(x =>
    {
      view.SetCoinNeed(x);
    }).AddTo(view);

    facility.Count
    .Subscribe(x =>
    {
      view.SetCount(x);
    }).AddTo(view);

    facility.IsBuyable
    .Subscribe(x =>
    {
      view.SetInteractable(x);
    }).AddTo(view);

    view.GetButton().OnClickAsObservable()
        .Subscribe(_ => facility.CountUp())
        .AddTo(view);
  }
}
