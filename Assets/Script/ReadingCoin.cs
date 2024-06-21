using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class ReadingCoin : MonoBehaviour
    {
        [SerializeField] private Text coinText;
        [SerializeField] private int  coin;

        private void Start()
        {
            coin = 0;
        }

        private void Update()
        {
            UpdateCoin();
        }

        private void UpdateCoin()
        {
            coinText.text = "COIN: " + coin;
        }

        public void AddCoin(int newCoin)
        {
            coin += newCoin;
        }
    }
}