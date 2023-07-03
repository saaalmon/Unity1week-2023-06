using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityDispatcher : MonoBehaviour
{
  [SerializeField]
  private FacilityManager _manager;
  [SerializeField]
  private FacilityPresenter _presenter;
  [SerializeField]
  private FacilityView _view;

  void Start()
  {
    foreach (var p in _manager.Facilities)
    {
      Dispatch(p);
    }
  }

  private void Dispatch(Facility facility)
  {
    var view = Instantiate(_view, facility.transform, false);

    _presenter.OnCreateFacility(facility, view);
  }
}
