using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZScore75 : MonoBehaviour
{
    public GameObject ObjectiveComplete;
    void DeductPoints (int DamageAmount)
    {
        GlobalScore.CurrentScore += 75;
        ObjectiveComplete.SetActive(true);
    }
}
