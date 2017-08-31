using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerAnimations : MonoBehaviour 
{
    Animator anim;

    string MOVE = "Move";
    string VELOCITY_Y = "VelocityY";
    string CROUCH = "Crouch";
    string CROUCHWALK = "CrouchWalk";

    void Awake () 
	{
        anim = GetComponent<Animator> ();
	}
	
    public void Movement (float magnitude)
    {
        anim.SetFloat (MOVE, magnitude);
    }

    public void PlayerJump (float velocity)
    {
        anim.SetFloat (VELOCITY_Y, velocity);
    }

    public void PlayerCrouch (bool isCrouching)
    {
        anim.SetBool (CROUCH, isCrouching);
    }

    public void PlayerCrouchWalk (float magnitude)
    {
        anim.SetFloat (CROUCHWALK, magnitude);
    }
}
