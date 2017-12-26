using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMessageBoxManager : MonoBehaviour {

    #region Fields
    public GameObject dialogBox;
    public Text dialogText;
    //public Image dialogHeaderRight;
    //public Image dialogHeaderLeft;
    public string[] dialogLines;
    public int currentLine;
    public bool isDialogBoxActive;

    /// <summary>
    /// when box is not foucsed, pressing doesn't work
    /// </summary>
    public bool isFoucs;

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
        if (!isFoucs)
            return;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (dialogLines == null || (dialogLines != null && dialogLines.Length <= 0))
                return;
            if (currentLine >= dialogLines.Length)
            {
                //SetDialogActive(false);
                currentLine = 0;
            }
            dialogText.text = dialogLines[currentLine];
            currentLine++;
            Debug.Log("" + currentLine);
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
