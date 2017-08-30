using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour 
{
    Transform firstPerson_View;
    Transform firstPerson_Camera;

    Vector3 firstPerson_View_Rotation = Vector3.zero;

    public float walkSpeed = 6.75f;
    public float runSpeed = 10f;
    public float crouchSpeed = 4f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;

    float speed;

    bool is_Moving, is_Grounded, is_Crouching;

    float inputX, inputY;
    float inputX_Set, inputY_Set;
    float inputModifyFactor;

    bool limitDiagonalSpeed = true;

    float antiBumpFactor = 0.75f;

    CharacterController charController;
    Vector3 moveDirection = Vector3.zero;

	void Start () 
	{
        firstPerson_View = transform.Find ("FPS View").transform;
        charController = GetComponent<CharacterController> ();
        speed = walkSpeed;
        is_Moving = false;
	}
	
	void Update () 
	{
        PlayerMovement ();
	}

    void PlayerMovement ()
    {
        if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S))
        {
            if (Input.GetKey (KeyCode.W))
            {
                inputY_Set = 1f;
            }
            else
            {
                inputY_Set = -1f;
            }
        }
        else
        {
            inputY_Set = 0f;
        }

        if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D))
        {
            if (Input.GetKey (KeyCode.A))
            {
                inputX_Set = -1f;
            }
            else
            {
                inputX_Set = 1f;
            }
        }
        else
        {
            inputX_Set = 0f;
        }

        inputY = Mathf.Lerp (inputY, inputY_Set, 19f * Time.deltaTime);
        inputX = Mathf.Lerp (inputX, inputX_Set, 19f * Time.deltaTime);
        inputModifyFactor = Mathf.Lerp (inputModifyFactor,
            (inputY_Set != 0 && inputX_Set != 0 && limitDiagonalSpeed) ? 0.75f : 1.0f, 
            19f * Time.deltaTime);

        firstPerson_View_Rotation = Vector3.Lerp (firstPerson_View_Rotation, 
            Vector3.zero, 5f * Time.deltaTime);
        firstPerson_View.localEulerAngles = firstPerson_View_Rotation;

        if (is_Grounded)
        {
            moveDirection = new Vector3 (inputX * inputModifyFactor, -antiBumpFactor, inputY * inputModifyFactor);
            moveDirection = transform.TransformDirection (moveDirection) * speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        is_Grounded = (charController.Move (moveDirection * Time.deltaTime) & CollisionFlags.Below) != 0;
        is_Moving = charController.velocity.magnitude > 0.15f;
    }
}
