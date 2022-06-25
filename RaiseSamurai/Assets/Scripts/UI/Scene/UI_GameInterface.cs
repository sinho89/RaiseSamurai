using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameInterface : UI_Scene
{
    enum GameUIButtons
    {
        StatPageButton,
        BagPageButton,
        RelicPageButton,
        BuffPageButton,
    }
    enum GameUITexts
    {
        StatPageText,
        BagPageText,
        RelicPageText,
        BuffPageText,
    }

    enum PagingObjects
    {
        UI_StatPage,
        UI_BagPage,
        UI_RelicPage,
        UI_BuffPage, 
    }

    private Dictionary<int, Button> _gameUIButtons = new Dictionary<int, Button>();
    private Dictionary<int, TextMeshProUGUI> _gameUITexts = new Dictionary<int, TextMeshProUGUI>();
    private Dictionary<int, GameObject> _gameUIObjects = new Dictionary<int, GameObject>();

    public override void Init()
    {
        Canvas canvas = gameObject.GetOrAddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;

        BindButton(typeof(GameUIButtons));
        BindText(typeof(GameUITexts));
        BindObject(typeof(PagingObjects));

        for (int i = 0; i < (int)(GameUIButtons.BuffPageButton) + 1; i++)
        {
            _gameUIButtons.Add(i, GetButton(i));
            _gameUITexts.Add(i, GetText(i));
            _gameUIObjects.Add(i, GetObject(i));
        }

        ChangeTextColorAndPageSetActive((int)GameUIButtons.StatPageButton);

        _gameUIButtons[(int)GameUIButtons.StatPageButton].gameObject.BindEvent((PointerEventData) => { ChangeTextColorAndPageSetActive((int)GameUIButtons.StatPageButton); });
        _gameUIButtons[(int)GameUIButtons.BagPageButton].gameObject.BindEvent((PointerEventData) => { ChangeTextColorAndPageSetActive((int)GameUIButtons.BagPageButton); });
        _gameUIButtons[(int)GameUIButtons.RelicPageButton].gameObject.BindEvent((PointerEventData) => { ChangeTextColorAndPageSetActive((int)GameUIButtons.RelicPageButton); });
        _gameUIButtons[(int)GameUIButtons.BuffPageButton].gameObject.BindEvent((PointerEventData) => { ChangeTextColorAndPageSetActive((int)GameUIButtons.BuffPageButton); });
    }

    private void ChangeTextColorAndPageSetActive(int idx)
    {
        for (int i = 0; i < (int)(GameUIButtons.BuffPageButton) + 1; i++)
        {
            if (i == idx)
            {
                GetText(i).color = new Color(0f, 1f, 0f);
                GetObject(i).gameObject.SetActive(true);
            }
            else
            {
                GetText(i).color = new Color(1f, 1f, 1f);
                GetObject(i).gameObject.SetActive(false);

            }
        }

    }
}
