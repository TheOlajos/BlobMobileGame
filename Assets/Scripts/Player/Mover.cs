using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;

    protected float ySpeed = 5.75f;
    protected float xSpeed = 5.0f;


    public int hitPoint;
    public int maxHitPoint;
    public float pushRecoverySpeed;

    //Immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

        public Rigidbody2D rb;

    //Push
    protected Vector3 pushDirection;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }



    protected virtual void UpdateMotor(Vector3 input)
    {
          //reset movedelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        //flip position
        if (moveDelta.x > 0) 
        {
            rb.AddForce = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1 , 1);
        }

        //Add push vector
        moveDelta += pushDirection;

        //decrmeent pushforce based on recovery speed
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        //Check we can move in this direction
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0 , new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
   

        if(hit.collider == null) {
            //move the player
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

                hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0 , new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
   
        
        if(hit.collider == null) {
            //move the player
            transform.Translate(moveDelta.x * Time.deltaTime, 0 , 0);
        }



    }

}
