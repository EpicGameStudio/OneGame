using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleTriggleZoneHolder : MonoBehaviour {

    private DialogManager dialogManager;
    public string[] dialogLines;
    // Use this for initialization
    void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == null)
            return;
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetButtonDown("A"))
            {
                StartCoroutine(StartBattle());
            }
        }
    }

    private IEnumerator ShowMessage()
    {
        if (!dialogManager.isDialogBoxActive)
        {
            dialogManager.dialogLines = dialogLines;
            dialogManager.currentLine = 0;
            dialogManager.SetDialogActive(true);
        }
        return null;
    }

    private IEnumerator StartBattle()
    {
        //yield return StartCoroutine(ShowMessage());
        SceneManager.LoadScene(SencesName.BattleSence);
        yield return null;
    }
}
