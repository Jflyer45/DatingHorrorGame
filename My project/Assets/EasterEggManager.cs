using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggManager : MonoBehaviour
{
    public GameObject SeanEasterEgg;

    // Start is called before the first frame update
    void Start()
    {
        Sean();
    }

    private void Sean()
    {
        Debug.Log(PlayerPrefs.GetString("SeanHorror"));
        Debug.Log(PlayerPrefs.GetString("SeanDate"));

        if (PlayerPrefs.GetString("SeanHorror") == "true"
            && PlayerPrefs.GetString("SeanDate") == "true")
        {
            SeanEasterEgg.SetActive(true);
        }
    }
}
