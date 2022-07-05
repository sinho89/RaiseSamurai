using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameInterface : UI_Popup
{
    private DynamicActor _parentActor = null;

    enum GameUIButtons
    {
        StatPageButton,
        SkillPageButton,
        BuffPageButton,
        OptionPageButton,
    }
    enum GameUITexts
    {
        StatPageText,
        SkillPageText,
        BuffPageText,
        OptionPageText,
        UI_LevelText
    }

    enum PagingObjects
    {
        UI_StatPage,
        UI_SkillPage,
        UI_BuffPage,
        UI_OptionPage,
    }

    enum GageImgs
    {
        UI_ExpGage,
    }

    enum GameUISliders
    {
        UI_TimeSlider,
    }

    private Dictionary<int, Button> _gameUIButtons = new Dictionary<int, Button>();
    private Dictionary<int, TextMeshProUGUI> _gameUITexts = new Dictionary<int, TextMeshProUGUI>();
    private Dictionary<int, GameObject> _gameUIObjects = new Dictionary<int, GameObject>();
    private Dictionary<int, Transform> _gameUIObjTransform = new Dictionary<int, Transform>();

    private UI_StatPage _playerStateUI = null;
    private Image _playerExpGage = null;
    private TextMeshProUGUI _playerLevelText = null;
    private Slider _stageTimeGage = null;

    private float _stageTime = 0f;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _stageTime = 0f;

        BindButton(typeof(GameUIButtons));
        BindText(typeof(GameUITexts));
        BindObject(typeof(PagingObjects));
        BindImage(typeof(GageImgs));
        BindSlider(typeof(GameUISliders));

        _playerExpGage = GetImage((int)GageImgs.UI_ExpGage);
        _playerLevelText = GetText((int)GameUITexts.UI_LevelText);
        _stageTimeGage = GetSlider((int)GameUISliders.UI_TimeSlider);
        _parentActor = transform.parent.GetComponent<DynamicActor>();

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

        _gameUIButtons[(int)GameUIButtons.SkillPageButton].gameObject.BindEvent((PointerEventData) => { ChangeTextColorAndPageSetActive((int)GameUIButtons.SkillPageButton); });
        _gameUIButtons[(int)GameUIButtons.BuffPageButton].gameObject.BindEvent((PointerEventData) => { ChangeTextColorAndPageSetActive((int)GameUIButtons.BuffPageButton); });
        _gameUIButtons[(int)GameUIButtons.OptionPageButton].gameObject.BindEvent((PointerEventData) => { ChangeTextColorAndPageSetActive((int)GameUIButtons.OptionPageButton); });

        return true;
    }

    private void Update()
    {
        _stageTime += Time.deltaTime;

        if (_playerExpGage != null)
            _playerExpGage.fillAmount = (float)_parentActor.Exp / _parentActor.MaxExp;

        if (_playerLevelText != null)
            _playerLevelText.text = $"Lv.{_parentActor.Level}";

        if (_stageTimeGage != null)
            _stageTimeGage.value = _stageTime / Defines.MAX_STAGE_TIME;
    }

    private void ChangeTextColorAndPageSetActive(int idx)
    {
        if (_init == false)
            return;

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
