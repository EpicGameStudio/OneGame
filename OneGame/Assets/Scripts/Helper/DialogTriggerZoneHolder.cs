using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriggerZoneHolder : MonoBehaviour {


    private DialogManager dialogManager;
    public string[] dialogLines;
    private PlayerMovement movement;
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
            movement = collision.gameObject.GetComponent<PlayerMovement>();
            movement.IsBusy = true;
            if (Input.GetButtonDown("A"))
            {
                if (!dialogManager.isDialogBoxActive)
                {
                    StartCoroutine(StartDialog());
                }
                
            }
        }
    }

    private IEnumerator StartDialog()
    {
        yield return dialogManager.StartDialog(dialogLines);
        if (movement != null)
            movement.IsBusy = false;
    }
    
}
