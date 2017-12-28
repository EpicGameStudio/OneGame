using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour {

    public GameObject PauseMenu;
    public bool IsActive;

    // Use this for initialization
    void Start () {
        SetPauseMenuActive(IsActive);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            IsActive = !IsActive;
            SetPauseMenuActive(IsActive);
        }
	}

    public void SetPauseMenuActive(bool isActive)
    {
        PauseMenu.SetActive(isActive);
    }
}
