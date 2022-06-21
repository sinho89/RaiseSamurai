using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ShopPopup : UI_Popup
{
    enum ShopButtons
    {
        CloseButton,
    }
    public override void Init()
    {
        Canvas canvas = gameObject.GetOrAddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;

        BindButton(typeof(ShopButtons));
        //Bind<GameObject>(typeof(ShopTexts));
        //Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name; // ItemNameText 텍스트 UI의 텍스트를 _name 으로 변경
        //Get<GameObject>((int)ShopButtons.CloseButton).BindEvent((PointerEventData) => { ClosePopupUI(); });
        GetButton((int)ShopButtons.CloseButton).gameObject.BindEvent((PointerEventData) => { ClosePopupUI(); });
    }

    public override void ClosePopupUI()
    {
        base.ClosePopupUI();
    }
}
