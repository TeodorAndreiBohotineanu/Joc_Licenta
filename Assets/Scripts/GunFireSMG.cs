﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireSMG : MonoBehaviour
{
    public GameObject TheSMG;
    public AudioSource SMGSound;
    public GameObject MuzzleFlash;
    public int AmmoCount;
    public int Firing;
    public GameObject UpCurs;
    public GameObject DownCurs;
    public GameObject LeftCurs;
    public GameObject RightCurs;
    // Update is called once per frame
    void Update( )
    {
        AmmoCount = GlobalAmmo.LoadedAmmo;
        if (Input.GetButton("Fire1"))
        {
            if (AmmoCount >= 1)
            {
                if (Firing == 0)
                {
                    SMGFire( );
                }
            }
        }
    }
    void SMGFire( )
    {
        Firing = 1;
        UpCurs.GetComponent<Animator>( ).enabled = true;
        DownCurs.GetComponent<Animator>( ).enabled = true;
        LeftCurs.GetComponent<Animator>( ).enabled = true;
        RightCurs.GetComponent<Animator>( ).enabled = true;
        GlobalAmmo.LoadedAmmo -= 1;
        SMGSound.Play( );
        MuzzleFlash.SetActive(true);
        TheSMG.GetComponent<Animator>( ).enabled = true;

        MuzzleOff( );
        TheSMG.GetComponent<Animator>( ).enabled = false;
        UpCurs.GetComponent<Animator>( ).enabled = false;
        DownCurs.GetComponent<Animator>( ).enabled = false;
        LeftCurs.GetComponent<Animator>( ).enabled = false;
        RightCurs.GetComponent<Animator>( ).enabled = false;
        Firing = 0;
    }
    IEnumerator MuzzleOff( )
    {
        yield return new WaitForSeconds(5);
        MuzzleFlash.SetActive(false);
    }
}