using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameInterface : UI_Scene
{
    protected DynamicActor _parentActor = null;
    protected enum PlayerStatTexts
    {
        LevelText,
        HpText,
        MpText,
        AttackText,
        AttackSpeedText,
        LuckyText,
        KillCountText,
    }

    enum GameUIButtons
    {
        StatPageButton,
        EffectPageButton,
        BuffPageButton,
        OptionPageButton,
    }
    enum GameUITexts
    {
        StatPageText,
        EffectPageText,
        BuffPageText,
        OptionPageText,
    }

    enum PagingObjects
    {
        UI_StatPage,
        UI_BagPage,
        UI_RelicPage,
        UI_BuffPage, 
    }

    enum GageImgs
    {
        UI_ExpGage,
    }

    private Dictionary<int, Button> _gameUIButtons = new Dictionary<int, Button>();
    private Dictionary<int, TextMeshProUGUI> _gameUITexts = new Dictionary<int, TextMeshProUGUI>();
    private Dictionary<int, GameObject> _gameUIObjects = new Dictionary<int, GameObject>();
    private Dictionary<int, Transform> _gameUIObjTransform = new Dictionary<int, Transform>();

    private UI_StatPage _playerStateUI = null;
    private Image _playerExpGage = null;

    protected override void Init()
    {
        Canvas canvas = gameObject.GetOrAddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;
        _parentActor = transform.parent.GetComponent<DynamicActor>();

        BindButton(typeof(GameUIButtons));
        BindText(typeof(GameUITexts));
        BindObject(typeof(PagingObjects));
        BindImage(typeof(GageImgs));

        _playerExpGage = GetImage((int)GageImgs.UI_ExpGage);

        for (int i = 0; i < (int)(GameUIButtons.OptionPageButton) + 1; i++)
        {
            _gameUIButtons.Add(i, GetButton(i));
            _gameUITexts.Add(i, GetText(i));
            _gameUIObjects.Add(i, GetObject(i));
        }

        _playerStateUI = _gameUIObjects[(int)(PagingObjects.UI_StatPage)].GetComponent<UI_StatPage>();

        ChangeTextColorAndPageSetActive((int)GameUIButtons.StatPageButton);

        _gameUIButtons[(int)GameUIButtons.StatPageButton].gameObject.BindEvent((PointerEventData) => 
        { 
            ChangeTextColorAndPageSetActive((int)GameUIButtons.StatPageButton);
            _playerStateUI.SetPlayerStatInfo();
        });
        _gameUIButtons[(int)GameUIButtons.EffectPageButton].gameObject.BindEvent((PointerEventData) => { ChangeTextColorAndPageSetActive((int)GameUIButtons.EffectPageButton); });
        _gameUIButtons[(int)GameUIButtons.BuffPageButton].gameObject.BindEvent((PointerEventData) => { ChangeTextColorAndPageSetActive((int)GameUIButtons.BuffPageButton); });
        _gameUIButtons[(int)GameUIButtons.OptionPageButton].gameObject.BindEvent((PointerEventData) => { ChangeTextColorAndPageSetActive((int)GameUIButtons.OptionPageButton); });
    }

    private void Update()
    {
        if(_playerExpGage != null)
            _playerExpGage.fillAmount = (float)_parentActor.Exp / _parentActor.MaxExp;
    }

    private void ChangeTextColorAndPageSetActive(int idx)
    {
        for (int i = 0; i < (int)(GameUIButtons.OptionPageButton) + 1; i++)
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
