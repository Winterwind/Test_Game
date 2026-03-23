using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMouseClick : MonoBehaviour
{
    private Animator anim;
    private float click;
    private AudioSource punchSound;
    // private bool facingDown = false, facingLeft = false, horz, vert;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        punchSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        click = Input.GetAxis("Fire2");
        anim.SetFloat("RightMouseClick", click);
        if(click > 0 && !punchSound.isPlaying)
        {
            punchSound.Play();
        }
        // Debug.Log(click);
    }
}
