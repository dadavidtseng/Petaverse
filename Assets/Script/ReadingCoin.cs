using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadingCoin : MonoBehaviour
{
    public Text CoinText;
    public int coin = 0;
   

    public GameObject Coin;
    

    void Start()
    {
        coin = 0;
    }

    public void AddCoin(int newCoin)
    {
        coin += newCoin;
        return;
    }

    public void UpdateCoin()
    {
        CoinText.text = "COIN: " + coin; 

    }

    void Update()
    {
        UpdateCoin();

       
    }
}
