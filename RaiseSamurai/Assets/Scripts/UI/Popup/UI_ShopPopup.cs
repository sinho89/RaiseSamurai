using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ShopPopup : UI_Popup
{
    enum ShopButtons
    {
        CloseButton,
    }
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(ShopButtons));
        //Bind<GameObject>(typeof(ShopTexts));
        //Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name; // ItemNameText �ؽ�Ʈ UI�� �ؽ�Ʈ�� _name ���� ����
        //Get<GameObject>((int)ShopButtons.CloseButton).BindEvent((PointerEventData) => { ClosePopupUI(); });
        GetButton((int)ShopButtons.CloseButton).gameObject.BindEvent((PointerEventData) => { ClosePopupUI(); });

        return true;
    }

    public override void ClosePopupUI()
    {
        base.ClosePopupUI();
    }
}
