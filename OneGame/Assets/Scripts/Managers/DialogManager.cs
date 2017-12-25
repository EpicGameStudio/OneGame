using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {


    #region Fields
    public GameObject dialogBox;
    public Text dialogText;
    public Image dialogHeaderRight;
    public Image dialogHeaderLeft;
    public string[] dialogLines;
    public int currentLine;
    public bool isDialogBoxActive;

    #endregion


    private void Awake()
    {
        SetDialogActive(isDialogBoxActive);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (currentLine >= dialogLines.Length)
            {
                SetDialogActive(false);
                currentLine = 0;
            }
            dialogText.text = dialogLines[currentLine];
            currentLine++;
        }
    }

    #region Methods
    public void SetDialogActive(bool isActive)
    {
        if (dialogBox != null)
        {
            isDialogBoxActive = isActive;
            dialogBox.SetActive(isDialogBoxActive);
        }
    }


    #endregion
}
