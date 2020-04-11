using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolDamage : MonoBehaviour
{
    public int DamageAmount = 3;
    public float TargetDistance;
    public float AllowedRange = 15.0f;

    void Start( )
    {
        
    }

  void Update( )
    {
        if (GlobalAmmo.LoadedAmmo >= 1)
            if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit Shot; ///Raycasting -> cat de departe se afla un obiect de jucator.
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot)) /// Aflam daca am lovit vreun obiect si la ce distanta se afla fata de jucator.
            {
                TargetDistance = Shot.distance; /// Retinem distanta.
                if (TargetDistance < AllowedRange)
                {
                    Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver); ///
                }
            }
        }
    }
}
