using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloading_Pistol : MonoBehaviour
{
    public AudioSource ReloadSound;
    public GameObject CrossObject;
    public GameObject MechanicsObject;
    public int ClipCount;
    public int ReserveCount;
    public int ReloadAvailable;

    void Start( )
    {

    }

    void Update( )
    {
        ClipCount = GlobalAmmo.LoadedAmmo;
        ReserveCount = GlobalAmmo.CurrentAmmo;

        if (ReserveCount == 0)
        {
            ReloadAvailable = 0;
        }
        else
        {
            ReloadAvailable = 15 - ClipCount;
        }

        if (Input.GetButtonDown("Reload"))
        {
            if (ReloadAvailable >= 1)
            {
                if (ReserveCount <= ReloadAvailable)
                {
                    GlobalAmmo.LoadedAmmo += ReserveCount;
                    GlobalAmmo.CurrentAmmo -= ReserveCount;
                    ActionReload( );
                }
                else
                {
                    GlobalAmmo.LoadedAmmo += ReloadAvailable;
                    GlobalAmmo.CurrentAmmo -= ReloadAvailable;
                    ActionReload( );
                }
            }
            StartCoroutine(EnableScripts( ));

        }
    }

    IEnumerator EnableScripts( )
    {
        yield return new WaitForSeconds(1.3f);
        CrossObject.SetActive(true);
        MechanicsObject.SetActive(true);
    }

    void ActionReload( )
    {
        CrossObject.SetActive(false);
        MechanicsObject.SetActive(false);
        ReloadSound.Play( );
        GetComponent<Animation>( ).Play("Reload_Pistol");
    }
}