using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killbox : MonoBehaviour
{
    private MovementController playerMove;
    private Animator anim;
    private GameObject gameStuff, deathCanvas, cam, GOtxt, button;
    private GameObject character;
    // private bool contact;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Character");
        gameStuff = GameObject.Find("GameStuff");
        deathCanvas = GameObject.Find("DeathCanvas");
        cam = GameObject.Find("Main Camera");
        GOtxt = GameObject.Find("GameOverText");
        button = GameObject.Find("RestartButton");
        anim = character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // contact = true;
        Debug.Log("Collision entered");
        //AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(0);
        //asyncOperation.allowSceneActivation = false;
        StartCoroutine(DeathAnim());
        // character.SetActive(false);
        //asyncOperation.allowSceneActivation = true;
    }

    IEnumerator DeathAnim()
    {
        Debug.Log("Death anim playing");
        anim.SetBool("Contact", true);
        anim.SetBool("Exit", true);
        yield return new WaitForSeconds(1.2f);
        gameStuff.SetActive(false);
        cam.GetComponent<AudioSource>().enabled = false;
        cam.GetComponent<MusicMuter>().enabled = false;
        deathCanvas.GetComponent<Canvas>().enabled = true;
        //deathCanvas.GetComponentInChildren<Button>
        //SceneManager.LoadScene(0);
    }
}
