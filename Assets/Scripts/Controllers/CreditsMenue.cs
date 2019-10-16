using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenue : MonoBehaviour
{

    public void OnCreditsEnd()
    {
        MainMenueManager.Instance.DisplayOptionsMenue();
    }
}
