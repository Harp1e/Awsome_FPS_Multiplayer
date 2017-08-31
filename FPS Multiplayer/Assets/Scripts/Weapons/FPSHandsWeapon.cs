using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSHandsWeapon : MonoBehaviour 
{
    public AudioClip shootClip, reloadClip;

    AudioSource audioManager;
    GameObject muzzleFlash;
    Animator anim;

    string SHOOT = "Shoot";
    string RELOAD = "Reload";

	void Awake () 
	{
        muzzleFlash = transform.Find ("MuzzleFlash").gameObject;
        muzzleFlash.SetActive (false);

        audioManager = GetComponent<AudioSource> ();
        anim = GetComponent<Animator> ();
	}
	
	public void Shoot () 
	{
        audioManager.PlayOneShot (shootClip);
        StartCoroutine (TurnMuzzleFlashOn ());
        anim.SetTrigger (SHOOT);
	}

    IEnumerator TurnMuzzleFlashOn ()
    {
        muzzleFlash.SetActive (true);
        yield return new WaitForSeconds (0.05f);
        muzzleFlash.SetActive (false);
    }

    public void Reload ()
    {
        StartCoroutine (PlayReloadSound ());
        anim.SetTrigger (RELOAD);
    }

    IEnumerator PlayReloadSound ()
    {
        yield return new WaitForSeconds (0.8f);
        audioManager.PlayOneShot (reloadClip);
    }
}
