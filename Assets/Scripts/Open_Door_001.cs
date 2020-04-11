using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open_Door_001 : MonoBehaviour
{

    public GameObject TextDisplay;
    public float TheDistance = PlayerCasting.DistanceFromTarget;
    public GameObject TheDoor;
    public GameObject SecondDoor;
    public GameObject ObjectiveComplete;

    void Update( )
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver( )
    {
        if (TheDistance <= 2)
            TextDisplay.GetComponent<Text>( ).text = "Press Button";
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                StartCoroutine(OpenTheDoors( ));
                ObjectiveComplete.SetActive(true);
            }
        }
    }

    void OnMouseExit( )
    {
        TextDisplay.GetComponent<Text>( ).text = "";
    }
    IEnumerator OpenTheDoors( )
    {
        TheDoor.GetComponent<Animator>( ).enabled = true; /// Enable la animatie
        SecondDoor.GetComponent<Animator>( ).enabled = true;
        yield return new WaitForSeconds(1); ///Astept o secunda pana se deschide
        TheDoor.GetComponent<Animator>( ).enabled = false; /// Facem disable la animatie dupa ce s-a deschis
        SecondDoor.GetComponent<Animator>( ).enabled = false;
        yield return new WaitForSeconds(5); ///Cat timp sta usa dechisa
        TheDoor.GetComponent<Animator>( ).enabled = true; ///Enable animatie inchidere
        SecondDoor.GetComponent<Animator>( ).enabled = true;
        yield return new WaitForSeconds(1); /// Inchidere animatie
        TheDoor.GetComponent<Animator>( ).enabled = false; /// Disable la animatie
        SecondDoor.GetComponent<Animator>( ).enabled = false;
    }
}