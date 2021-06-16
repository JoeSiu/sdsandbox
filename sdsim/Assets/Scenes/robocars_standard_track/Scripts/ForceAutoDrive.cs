using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAutoDrive : MonoBehaviour
{
    private MenuHandler menuHandler;
    private bool toggled = false;

    private void Awake()
    {
        menuHandler = GameObject.FindObjectOfType<MenuHandler>().GetComponent<MenuHandler>();
    }

    public void ToggleAutoDrive()
    {
        if (!toggled)
        {
            if (menuHandler.PIDContoller != null)
                menuHandler.PIDContoller.SetActive(true);

            if (menuHandler.carJSControl != null)
                menuHandler.carJSControl.SetActive(false);

            if (menuHandler.PIDControls != null)
                menuHandler.PIDControls.SetActive(true);
        }
        else
        {
            if (menuHandler.PIDContoller != null)
                menuHandler.PIDContoller.SetActive(false);

            if (menuHandler.carJSControl != null)
                menuHandler.carJSControl.SetActive(false);

            if (menuHandler.PIDControls != null)
                menuHandler.PIDControls.SetActive(false);
        }

        toggled = !toggled;
    }
}
