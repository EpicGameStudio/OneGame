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
        if (Input.GetButtonDown("A"))
        {
            if (dialogLines == null||(dialogLines!=null&& dialogLines.Length<=0))
                return;
            if (currentLine >= dialogLines.Length)
            {
                SetDialogActive(false);
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

    public IEnumerator StartDialog(string[] strings)
    {
        dialogLines = strings;
        currentLine = 0;
        SetDialogActive(true);
        if (dialogLines == null || (dialogLines != null && dialogLines.Length <= 0))
           yield return null;
        while (currentLine < dialogLines.Length)
        {
            if (Input.GetButtonDown("A"))
            {
                dialogText.text = dialogLines[currentLine];
                currentLine++;
                yield return null;
            }
            
        }
        SetDialogActive(false);
        currentLine = 0;
    }


    #endregion
}
