using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinCounter coinCounter;
    private AudioSource coinSound;
    private AudioClip coinSoundClip;
    private Color col;
    private CircleCollider2D bump;

    // Start is called before the first frame update
    void Start()
    {
        coinCounter = GameObject.Find("Coin Counter").GetComponent<CoinCounter>();
        coinSound = GetComponent<AudioSource>();
        Debug.Log("This is coinsound: " + coinSound);
        coinSoundClip = coinSound.clip;
        Debug.Log("This is coinSoundClip: " + coinSoundClip);
        col = GetComponent<SpriteRenderer>().color;
        bump = GetComponent<CircleCollider2D>();
        //coinSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Control coin collison
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision entered");
        coinCounter.coinCount++;
        Debug.Log("coinCount: " + coinCounter.coinCount.ToString());
        AudioSource.PlayClipAtPoint(coinSoundClip, this.transform.position);
        Destroy(gameObject);
    }
}
