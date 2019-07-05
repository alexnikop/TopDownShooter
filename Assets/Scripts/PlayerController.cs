using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector2 moveAmount;
    private Rigidbody2D rb;
    private Animator anim;
    private bool prevHorStim = false;
    private bool prevVerStim = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveAmount = moveInput.normalized * speed;

        bool horStim = Mathf.Abs(moveInput[0]) > 0.5;
        bool verStim = Mathf.Abs(moveInput[1]) > 0.5;

        if (horStim && !prevHorStim){
            anim.SetBool("isWalkingHor", true);
            anim.SetBool("isWalkingVer", false);
        }
        if (verStim && !prevVerStim){
            anim.SetBool("isWalkingVer", true);
            anim.SetBool("isWalkingHor", false);    
        }
        if (!horStim){
            anim.SetBool("isWalkingHor", false);
        }
        if (!verStim){
            anim.SetBool("isWalkingVer", false);        
        }
        
        prevHorStim = horStim;
        prevVerStim = verStim;
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);    
    }
}
