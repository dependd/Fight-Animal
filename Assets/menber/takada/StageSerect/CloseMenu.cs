using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour{

    public GameObject MenuScreen;

    public void OnClick()
    {
        MenuScreen.SetActive(false);
    }

}
