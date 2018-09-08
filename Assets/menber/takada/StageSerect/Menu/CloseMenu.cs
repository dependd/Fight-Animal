using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour{

    public GameObject MenuScreen;
	[SerializeField] GameObject Menu;
	OpenMenu openMenu;
	private void Start(){
		openMenu = Menu.GetComponent<OpenMenu>();
	}

    public void OnClick()
    {
		MenuScreen.SetActive(false);
		openMenu.touchFlag = true;
    }

}
