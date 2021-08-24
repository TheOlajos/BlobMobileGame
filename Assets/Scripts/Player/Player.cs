using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : PlayerMovement
{
    public State state;
    public Vector3 currentMovement;
    public Vector3 lastMoved;
    public Vector3 overrideMovement;

    public float speed;
    public FixedJoystick joystick;
    public Rigidbody rb;

    public bool useWASD = true;



    private void Awake() 
    {
        state = State.idle;
    }


    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

       // rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);


        if(useWASD)currentMovement = new Vector3(x,y,0);
        if(!useWASD)currentMovement = new Vector3(joystick.Vertical, joystick.Horizontal,0);

        if(currentMovement != Vector3.zero) lastMoved = currentMovement; 


        //overrides movement if you set overrideMovement from another class.
        if(overrideMovement != Vector3.zero) currentMovement = overrideMovement; 
 
        UpdateMotor(currentMovement);

    }

    public void OverrideVelocity(Vector3 vect){
        overrideMovement = vect;
        Debug.Log(overrideMovement.ToString());
    }

 

}
