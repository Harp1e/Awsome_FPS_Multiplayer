using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FPSPlayerAnimations : NetworkBehaviour 
{
    Animator anim;

    string MOVE = "Move";
    string VELOCITY_Y = "VelocityY";
    string CROUCH = "Crouch";
    string CROUCHWALK = "CrouchWalk";
    string STAND_SHOOT = "StandShoot";
    string CROUCH_SHOOT = "CrouchShoot";
    string RELOAD = "Reload";

    public RuntimeAnimatorController animController_Pistol, animController_MachineGun;

    NetworkAnimator networkAnim;

    void Awake () 
	{
        anim = GetComponent<Animator> ();
        networkAnim = GetComponent<NetworkAnimator> ();
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

    public void Shoot (bool isCrouching)
    {
        if (isCrouching)
        {
            anim.SetTrigger (CROUCH_SHOOT);
            networkAnim.SetTrigger (CROUCH_SHOOT);
        }
        else
        {
            anim.SetTrigger (STAND_SHOOT);
            networkAnim.SetTrigger (STAND_SHOOT);
        }
    }

    public void ReloadGun ()
    {
        anim.SetTrigger (RELOAD);
        networkAnim.SetTrigger (RELOAD);
    }

    public void ChangeController (bool isPistol)
    {
        if (isPistol)
        {
            anim.runtimeAnimatorController = animController_Pistol;
        }
        else
        {
            anim.runtimeAnimatorController = animController_MachineGun;

        }
    }
}
