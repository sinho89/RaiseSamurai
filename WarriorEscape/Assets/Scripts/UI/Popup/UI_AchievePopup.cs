using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_AchievePopup : UI_Popup
{
    enum AchieveButtons
    {
        CloseButton,
    }
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(AchieveButtons));
        //Bind<GameObject>(typeof(ShopTexts));
        //Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name; // ItemNameText 텍스트 UI의 텍스트를 _name 으로 변경
        //Get<GameObject>((int)ShopButtons.CloseButton).BindEvent((PointerEventData) => { ClosePopupUI(); });
        GetButton((int)AchieveButtons.CloseButton).gameObject.BindEvent((PointerEventData) => { ClosePopupUI(); });

        return true;
    }

    public override void ClosePopupUI()
    {
        base.ClosePopupUI();
    }
}
