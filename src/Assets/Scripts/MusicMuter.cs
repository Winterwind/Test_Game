using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMuter : MonoBehaviour
{
    private AudioSource music;
    // private int presses = 0;

    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MPress());
    }

    IEnumerator MPress()
    {
        if (Input.GetKeyDown("m"))
        {
            if (music.mute) { music.mute = false; }
            else { music.mute = true; }
        }
        yield return new WaitForSeconds(0.01f);
    }

}
