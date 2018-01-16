using Foundation.Databinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/UITest/UITestMenu")]
public class UITestMenu : ObservableBehaviour
{
    private bool isVisible;

    public bool IsVisible
    {
        get { return isVisible; }
        set
        {
            //Prevent stack overflows
            if (isVisible == value)
                return;
            //set the value
            isVisible = value;
            //notify bound listeners that this has changed
            NotifyProperty("IsVisible", value);
            Debug.Log("ExampleMainMenu.IsVisible " + value);
        }
    }
    public string GameName;
    public UIButton Button;
    public IEnumerator OpenOptions()
    {
        //switch visibility
        IsVisible = false;
        Button.IsVisible = !Button.IsVisible;

        //wait for the options menu to close
        while (Button.IsVisible)
        {
            yield return 1;
        }

        //switch visibility on
        IsVisible = true;
    }
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("ExampleMainMenu.Awake");
    }
}
