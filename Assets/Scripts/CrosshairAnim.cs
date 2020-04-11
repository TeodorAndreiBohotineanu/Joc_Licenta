using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairAnim : MonoBehaviour
{

    public GameObject UpCurs;
    public GameObject DownCurs;
    public GameObject LeftCurs;
    public GameObject RightCurs;
    // Start is called before the first frame update
    void Start( )
    {
        
    }

    void Update( )
    {
        if (GlobalAmmo.LoadedAmmo >= 1)
            if (Input.GetButtonDown("Fire1"))/// Update se intampla la fiecare frame, si daca s-a detectat ca am tras, atunci se executa animatiile.
        {
            UpCurs.GetComponent<Animator>( ).enabled = true;
            DownCurs.GetComponent<Animator>( ).enabled = true;
            LeftCurs.GetComponent<Animator>( ).enabled = true;
            RightCurs.GetComponent<Animator>( ).enabled = true;
            StartCoroutine(WaitingAnim( ));
        }
    }

    IEnumerator WaitingAnim( ) /// Dupa ce s-au executat animatiile, asteptam 0.1 secunde, apoi dezactivam animatiile.
    {
        yield return new WaitForSeconds(0.2f);
        UpCurs.GetComponent<Animator>( ).enabled = false;
        DownCurs.GetComponent<Animator>( ).enabled = false;
        LeftCurs.GetComponent<Animator>( ).enabled = false;
        RightCurs.GetComponent<Animator>( ).enabled = false;
    }
}
