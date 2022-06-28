using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_StatPage : UI_GameInterface
{
    private Dictionary<int, TextMeshProUGUI> _playerStatTexts = new Dictionary<int, TextMeshProUGUI>();

    protected override void Init()
    {
        Canvas canvas = gameObject.GetOrAddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;

        BindText(typeof(PlayerStatTexts));

        for (int i = 0; i < (int)(PlayerStatTexts.KillCountText) + 1; i++)
            _playerStatTexts.Add(i, GetText(i));


        //PageBack/UI_GameInterface/DynamicActor(Player)
        _parentActor = transform.parent.parent.parent.GetComponent<DynamicActor>();

        SetPlayerStatInfo();
    }

    public void SetPlayerStatInfo()
    {
        _playerStatTexts[(int)PlayerStatTexts.LevelText].text = $"레벨 : {_parentActor.Level}";
        _playerStatTexts[(int)PlayerStatTexts.HpText].text = $"체력 : {_parentActor.Hp} / {_parentActor.MaxHp}";
        _playerStatTexts[(int)PlayerStatTexts.MpText].text = $"마력 : {_parentActor.Mp} / {_parentActor.MaxMp}";
        _playerStatTexts[(int)PlayerStatTexts.LuckyText].text = $"행운 : {_parentActor.Lucky}";
        _playerStatTexts[(int)PlayerStatTexts.AttackText].text = $"공격력 : {_parentActor.Attack}";
        _playerStatTexts[(int)PlayerStatTexts.AttackSpeedText].text = $"공격속도 : {_parentActor.AttackSpeed * 100}%";

        _playerStatTexts[(int)PlayerStatTexts.KillCountText].text = $"잡은 몬스터 수 : {Managers.Actor._playerKillCount}";
    }

}
