using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open_Door_002 : MonoBehaviour
{

    public GameObject TextDisplay;
    public float TheDistance = PlayerCasting.DistanceFromTarget;
    public GameObject FirstDoor_2;
    public GameObject SecondDoor_2;

    void Update( )
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                StartCoroutine(OpenTheDoors( ));
            }
        }
    }

    void OnMouseOver( )
    {
        if (TheDistance <= 2)
            TextDisplay.GetComponent<Text>( ).text = "Press Button";

    }

    void OnMouseExit( )
    {
        TextDisplay.GetComponent<Text>( ).text = "";
    }
    IEnumerator OpenTheDoors( )
    {
        FirstDoor_2.GetComponent<Animator>( ).enabled = true; /// Enable la animatie
        SecondDoor_2.GetComponent<Animator>( ).enabled = true;
        yield return new WaitForSeconds(1); ///Astept o secunda pana se deschide
        FirstDoor_2.GetComponent<Animator>( ).enabled = false; /// Facem disable la animatie dupa ce s-a deschis
        SecondDoor_2.GetComponent<Animator>( ).enabled = false;
        yield return new WaitForSeconds(5); ///Cat timp sta usa dechisa
        FirstDoor_2.GetComponent<Animator>( ).enabled = true; ///Enable animatie inchidere
        SecondDoor_2.GetComponent<Animator>( ).enabled = true;
        yield return new WaitForSeconds(1); /// Inchidere animatie
        FirstDoor_2.GetComponent<Animator>( ).enabled = false; /// Disable la animatie
        SecondDoor_2.GetComponent<Animator>( ).enabled = false;
    }
}