using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ExitPopup : UI_Popup
{
    enum ExitPopupButtons
    {
        OkButton,
        CancleButton,
    }
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(ExitPopupButtons));

        GetButton((int)ExitPopupButtons.OkButton).gameObject.BindEvent((PointerEventData) => { Application.Quit(); });
        GetButton((int)ExitPopupButtons.CancleButton).gameObject.BindEvent((PointerEventData) => { ClosePopupUI(); });
        return true;
    }

    public override void ClosePopupUI()
    {
        base.ClosePopupUI();
    }
}
