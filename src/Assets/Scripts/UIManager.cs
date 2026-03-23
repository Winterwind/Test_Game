using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    private CoinCounter coinCounter;
    private Coin coin;

    // Start is called before the first frame update
    void Start()
    {
        coin = GameObject.Find("Coin").GetComponent<Coin>();
        coinCounter = GameObject.Find("Coin Counter").GetComponent<CoinCounter>();
        coinText.text = "Coins: " + coinCounter.coinCount;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + coinCounter.coinCount;
    }
}
