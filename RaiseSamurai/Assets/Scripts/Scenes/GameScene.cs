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
        Managers.UI.BackGroundLayersMoveSwitch(true);
    }
    protected override void ObjectInit()
    {
        GameObject player = Managers.Actor.Spawn(Defines.Actors.Player, "Player/Player");
        Managers.UI.ShowSceneUI<UI_BackGround>("UI_BackGround");
        Managers.UI.ShowSceneUI<UI_GameGage>("UI_GameGage", player.transform);
        Managers.UI.ShowSceneUI<UI_GameInterface>("UI_GameInterface", player.transform);

        GameObject go = new GameObject { name = "SpawningPool" };
        SpawningPool pool = go.GetOrAddComponent<SpawningPool>();
        Managers.Actor.SpawningPool = pool;
        pool.SetMaxMonsterCount(100);
        pool.SetSpawnTime(1.0f);
    }

    public override void Clear()
    {

    }
}
