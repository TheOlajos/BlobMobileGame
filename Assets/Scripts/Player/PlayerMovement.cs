using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Mover
{

        public enum State
    {
        walking,
        idle,
        ability,
        absorbing,
        absorbed,
        stunned,
        attacked,

    }

    protected Vector3 moveDir;

    protected virtual void GetInput()
    {

    }
    


    

}
