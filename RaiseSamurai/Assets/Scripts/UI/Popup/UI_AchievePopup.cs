using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_AchievePopup : UI_Popup
{
    enum AchieveButtons
    {
        CloseButton,
    }
    protected override void Init()
    {
        Canvas canvas = gameObject.GetOrAddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;

        BindButton(typeof(AchieveButtons));
        //Bind<GameObject>(typeof(ShopTexts));
        //Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name; // ItemNameText �ؽ�Ʈ UI�� �ؽ�Ʈ�� _name ���� ����
        //Get<GameObject>((int)ShopButtons.CloseButton).BindEvent((PointerEventData) => { ClosePopupUI(); });
        GetButton((int)AchieveButtons.CloseButton).gameObject.BindEvent((PointerEventData) => { ClosePopupUI(); });
    }

    public override void ClosePopupUI()
    {
        base.ClosePopupUI();
    }
}
