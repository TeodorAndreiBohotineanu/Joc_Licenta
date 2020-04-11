using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gunfire : MonoBehaviour
{
    public GameObject Flash; // Am creat o variabila de tipul GameObject
    // Start is called before the first frame update
    void Start( )
    {
        
    }
    // Update is called once per frame
    void Update( )
    {
        if (GlobalAmmo.LoadedAmmo >= 1)
            if (Input.GetButtonDown("Fire1")) /// Daca a detectat ca s-a apasat click
            {
                AudioSource Gunsound = GetComponent<AudioSource>( ); /// Facem Gunsound sa faca referire la AudioSource 
                Gunsound.Play( ); /// Face play la sunet.
                Flash.SetActive(true); /// Activam muzzle flash-ul 
                MuzzleOff( ); /// turn off muzzle flash-ul 
                GetComponent<Animation>( ).Play("M9_GunShot"); /// Luam animatia si ii dam play deodata cu sunetul
                GlobalAmmo.LoadedAmmo -= 1; /// Scadem din munitie 
            }
    }
    IEnumerator MuzzleOff( )
    {
        yield return new WaitForSeconds(1); /// Asteptam
        Flash.SetActive(false); /// Si apoi eliminam muzzle flash-ul
    }
}
