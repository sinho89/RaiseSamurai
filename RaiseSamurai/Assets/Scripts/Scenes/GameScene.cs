using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void SceneSetting()
    {
        SceneType = Defines.Scenes.Game;
        SceneName = "Game";
    }
    protected override void ObjectInit()
    {
        Managers.Actor.Spawn(Defines.Actors.Player, "Player/Player");
        Managers.UI.ShowSceneUI<UI_BackGround>("UI_BackGround");
    }

    public override void Clear()
    {
        Debug.Log($"{SceneName} Clear");
    }
}
