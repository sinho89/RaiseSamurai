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
    public override void Init()
    {
        Canvas canvas = gameObject.GetOrAddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;

        BindButton(typeof(ExitPopupButtons));
        //Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name; // ItemNameText �ؽ�Ʈ UI�� �ؽ�Ʈ�� _name ���� ����
        //Get<GameObject>((int)SmallPopupButtons.CancleButton).BindEvent((PointerEventData) => { ClosePopupUI(); });
        GetButton((int)ExitPopupButtons.CancleButton).gameObject.BindEvent((PointerEventData) => { ClosePopupUI(); });
    }

    public override void ClosePopupUI()
    {
        base.ClosePopupUI();
    }
}
