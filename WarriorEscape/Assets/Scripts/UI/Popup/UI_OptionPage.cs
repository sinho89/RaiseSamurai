using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_OptionPage : UI_Popup
{
    private enum OptionButtons
    {
        UI_BackButton,
        UI_QuitButton
    }
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(OptionButtons));

        GetButton((int)OptionButtons.UI_BackButton).gameObject.BindEvent((PointerEventData) => 
        {
            Managers.Scene._MovingScene = Defines.Scenes.Title;
            Managers.Scene._isSceneChange = true;
        });
        GetButton((int)OptionButtons.UI_QuitButton).gameObject.BindEvent((PointerEventData) => { Application.Quit(); });
        
        return true;
    }
}
