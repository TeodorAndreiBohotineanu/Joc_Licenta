using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp9mm : MonoBehaviour
{
    public float TheDistance = PlayerCasting.DistanceFromTarget;
    public GameObject TextDisplay; // dupa ce luam arma de pe cutie, putem activa cutia in care scrie 9mm, mai sus de ammo

    public GameObject FakeGun;
    public GameObject RealGun;
    public GameObject ObjectiveComplete;
    public GameObject AmmoDisplay;
    public AudioSource PickUpAudio;

    void Update( )
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver( )
    {
        if (TheDistance <= 2)
        {
            TextDisplay.GetComponent<Text>( ).text = "Take 9mm Pistol";
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                StartCoroutine(TakeNineMil( ));
                ObjectiveComplete.SetActive(true);
            }
        }
    }

    void OnMouseExit( )
    {
        TextDisplay.GetComponent<Text>( ).text = "";
    }

    IEnumerator TakeNineMil( )
    {
        PickUpAudio.Play( ); /// Dam drumul la sunet cand luam arma
        transform.position = new Vector3(0, -1000, 0); /// "Teleportam" modelul intr-o parte in care nu vom ajunge vreodata, "off map area"
        FakeGun.SetActive(false); /// Arma de pe cutie va disparea
        RealGun.SetActive(true); /// Activam modelul armei "adevarate" 
        AmmoDisplay.SetActive(true); /// Activam descrierea armei : 9mm
        yield return new WaitForSeconds(0.1f);
    }
}