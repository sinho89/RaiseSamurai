using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TitleInterface : UI_Scene
{
    enum TitleButtons
    {
        StartButton,
        AchievementsButton,
        ShopButton,
        ExitButton,
    }

    public override void Init()
    {
        Canvas canvas = gameObject.GetOrAddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;

        BindButton(typeof(TitleButtons));
        //Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name; // ItemNameText 텍스트 UI의 텍스트를 _name 으로 변경
        GetButton((int)TitleButtons.StartButton).gameObject.BindEvent((PointerEventData) => 
        { 
            Managers.Scene._MovingScene = Defines.Scenes.Game;
            Managers.Scene._IsSceneChange = true; 
        });
        GetButton((int)TitleButtons.AchievementsButton).gameObject.BindEvent((PointerEventData) => { Managers.UI.ShowPopupUI<UI_AchievePopup>("UI_AchievePopup"); });
        GetButton((int)TitleButtons.ShopButton).gameObject.BindEvent((PointerEventData) => { Managers.UI.ShowPopupUI<UI_ShopPopup>("UI_ShopPopup"); });
        GetButton((int)TitleButtons.ExitButton).gameObject.BindEvent((PointerEventData) => { Managers.UI.ShowPopupUI<UI_ExitPopup>("UI_ExitPopup"); });
    }
}
