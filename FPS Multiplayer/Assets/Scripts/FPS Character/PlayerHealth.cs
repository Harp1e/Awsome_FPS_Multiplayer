using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour 
{
    [SyncVar] public float health = 100;

	public void TakeDamage (float damage)
    {
        if (!isServer) { return; }
        health -= damage;
        print ("Damage Received");
        if (health <= 0f)
        {

        }
    }
}
