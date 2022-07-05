using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_StatPage : UI_Popup
{
    private Dictionary<int, TextMeshProUGUI> _playerStatTexts = new Dictionary<int, TextMeshProUGUI>();

    private DynamicActor _parentActor = null;
    private enum PlayerStatTexts
    {
        LevelText,
        HpText,
        MpText,
        AttackText,
        AttackSpeedText,
        LuckyText,
        KillCountText,
    }
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindText(typeof(PlayerStatTexts));

        for (int i = 0; i < (int)(PlayerStatTexts.KillCountText) + 1; i++)
            _playerStatTexts.Add(i, GetText(i));


        //PageBack/UI_GameInterface/DynamicActor(Player)
        _parentActor = GameObject.Find("Player").GetComponent<DynamicActor>();

        return true;
    }

    private void Update()
    {
        SetPlayerStatInfo();
    }

    public void SetPlayerStatInfo()
    {
        _playerStatTexts[(int)PlayerStatTexts.LevelText].text = $"���� : {_parentActor.Level}";
        _playerStatTexts[(int)PlayerStatTexts.HpText].text = $"ü�� : {_parentActor.Hp} / {_parentActor.MaxHp}";
        _playerStatTexts[(int)PlayerStatTexts.MpText].text = $"���� : {_parentActor.Mp} / {_parentActor.MaxMp}";
        _playerStatTexts[(int)PlayerStatTexts.LuckyText].text = $"��� : {_parentActor.Lucky}";
        _playerStatTexts[(int)PlayerStatTexts.AttackText].text = $"���ݷ� : {_parentActor.Attack}";
        _playerStatTexts[(int)PlayerStatTexts.AttackSpeedText].text = $"���ݼӵ� : {_parentActor.AttackSpeed * 100}%";

        _playerStatTexts[(int)PlayerStatTexts.KillCountText].text = $"���� ���� �� : {Managers.Actor._playerKillCount}";
    }

}
