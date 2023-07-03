using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  //フレームレート
  private const int _fps = 60;
  //桁数指定
  private const int _digit = 1000;

  // [SerializeField]
  // private float _score;
  // [SerializeField]
  // private float _dps;
  // [SerializeField]
  // private float _dpsClick;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    // Add();

    // if (Input.GetMouseButtonDown(0))
    // {
    //   ClickAdd();
    // }
  }

  // //自動増加
  // private void Add()
  // {
  //   var add = (float)_dps / _fps;
  //   add = SetDigit(add);

  //   _score += add;
  //   Debug.Log(_dps.ToString("F0"));
  // }

  // public void SetDpsAdd(float dps)
  // {
  //   _dps += dps;
  // }

  // //クリック増加
  // private void ClickAdd()
  // {
  //   _score += _dpsClick;
  //   Debug.Log(_score);
  // }

  // //有効数字計算
  // private float SetDigit(float value)
  // {
  //   value = value * _digit;
  //   value = Mathf.Floor(value) / _digit;

  //   return value;
  // }
}
