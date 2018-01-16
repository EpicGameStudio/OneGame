using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Foundation.Databinding;
public class UIButton :  ObservableBehaviour
{
    private bool _isVisible = true;

    public bool IsVisible
    {
        get { return _isVisible; }
        set
        {
            if (_isVisible == value)
                return;
            _isVisible = value;
            NotifyProperty("IsVisible", value);
        }
    }

    protected override void Awake()
    {
        base.Awake();
    }

}
