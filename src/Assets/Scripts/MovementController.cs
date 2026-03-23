using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float maxSpeed = 2.0f;
    private Animator anim;
    private Vector2 move;
    private bool facingDown = false, facingLeft = false, horz, vert;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        horz = false;
        vert = true;
        if (facingDown || horz) { FlipFacingY(); }
        //if (facingLeft) { FlipFacingX(); }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + (move * maxSpeed * Time.fixedDeltaTime));
        anim.SetFloat("Speed", move.magnitude * maxSpeed);
        // Debug.Log(move);
        if (move.y > 0 && ((vert && facingDown) || horz)) { FlipFacingY(); }
        else if (move.y < 0 && ((vert && !facingDown) || horz)) { FlipFacingY(); }
        if (move.x > 0 && ((horz && facingLeft) || vert)) { FlipFacingX(); }
        else if (move.x < 0 && ((horz && !facingLeft) || vert)) { FlipFacingX(); }
    }

    // Flip the character vertically
    void FlipFacingY()
    {
        horz = false;
        vert = true;
        facingDown = !facingDown;
        Vector3 charScale = transform.localScale, charAngle = transform.localEulerAngles;
        charScale.y *= -1.0f;
        charAngle.Set(0f, 0f, 0f);
        transform.localScale = charScale;
        transform.localEulerAngles = charAngle;
    }

    // Flip the character horizontally
    void FlipFacingX()
    {
        horz = true;
        vert = false;
        facingLeft = !facingLeft;
        Vector3 charScale = transform.localScale, charAngle = transform.localEulerAngles;
        charScale.y *= 1.0f;
        charScale.x *= 1.0f;
        if (move.x > 0) { charAngle.Set(0f, 0f, 90f); }
        else if (move.x < 0) { charAngle.Set(0f, 0f, -90f); }
        transform.localScale = charScale;
        transform.localEulerAngles = charAngle;
    }
}
