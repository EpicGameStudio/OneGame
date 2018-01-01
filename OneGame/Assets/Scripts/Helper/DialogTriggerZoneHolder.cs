using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriggerZoneHolder : MonoBehaviour {


    private DialogManager dialogManager;
    public string[] dialogLines;
	// Use this for initialization
	void Start () {
        dialogManager = FindObjectOfType<DialogManager>();

    }
	
	// Update is called once per frame
	void Update () {
        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == null)
            return;
        if (collision.gameObject.name == "Player")
        {
            if (Input.GetButtonDown("A"))
            {
                if (!dialogManager.isDialogBoxActive)
                {
                    dialogManager.dialogLines = dialogLines;
                    dialogManager.currentLine = 0;
                    dialogManager.SetDialogActive(true);                   
                }
                
            }
        }
    }
}
