using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    private static UIController _instance;
    public static UIController Instance { get { return _instance; } }
    private UIControl[] uiControl;

    private void Awake()
    {
        uiControl = GetComponentsInChildren<UIControl>();
        //Debug.Log(uiControl.Length);

        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void UpdateHearts(int i)
    {
        uiControl[i].UpdateHeart();
    }

}
