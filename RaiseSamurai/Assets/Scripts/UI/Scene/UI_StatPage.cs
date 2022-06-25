using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_StatPage : UI_GameInterface
{
    enum PlayerStatTexts
    {
        HelmetSlotText,
        WeaponSlotText,
        GloveSlotText,
        BootsSlotText,
        RelicSlotText,
        LevelText,
        HpText,
        MpText,
        AttackText,
        AttackSpeedText,
        LuckyText,
        KillCountText,
    }

    enum PlayerEquipImages
    {
        HelmetSlot,
        WeaponSlot,
        GloveSlot,
        BootsSlot,
        RelicSlot,
    }

    private Dictionary<int, Image> _playerEquitImgs = new Dictionary<int, Image>();
    private Dictionary<int, TextMeshProUGUI> _platerStatTexts = new Dictionary<int, TextMeshProUGUI>();

    public override void Init()
    {
        Canvas canvas = gameObject.GetOrAddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;

        BindImage(typeof(PlayerEquipImages));
        BindText(typeof(PlayerStatTexts));

        for (int i = 0; i < (int)(PlayerStatTexts.KillCountText) + 1; i++)
            _platerStatTexts.Add(i, GetText(i));

        for (int i = 0; i < (int)(PlayerEquipImages.RelicSlot) + 1; i++)
            _playerEquitImgs.Add(i, GetImage(i));
    }

}
