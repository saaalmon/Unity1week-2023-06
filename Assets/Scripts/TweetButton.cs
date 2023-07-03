using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using naichilab;

public class TweetButton : MonoBehaviour
{
  [SerializeField]
  private CoinManager _coinManager;

  public void OnTweetButton()
  {
    naichilab.UnityRoomTweet.Tweet("syuwa-syuwa-vender", "シュワシュワベンダーで" + _coinManager.Coiner + "ポイント稼いだ！", "unityroom", "unity1week");
  }
}
