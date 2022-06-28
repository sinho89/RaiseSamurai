using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameScene : BaseScene
{
    private UI_GameOver _gameOverScreen = null;
    protected override void Init()
    {
        base.Init();
    }
    protected override void Update()
    {
        base.Update();

        if(Managers.Actor._isGameOver && _gameOverScreen != null)
            _gameOverScreen.gameObject.SetActive(true);
    }
    protected override void SceneSetting()
    {
        SceneType = Defines.Scenes.Game;
        SceneName = "Game";
        Managers.UI.BackGroundLayersMoveSwitch(true);
        Managers.Sound.Play("BGM/GameBgm", Defines.Sounds.Bgm);
        Managers.Actor._isGameOver = false;
        Managers.Actor._playerKillCount = 0;
    }
    protected override void ObjectInit()
    {
        GameObject player = Managers.Actor.Spawn(Defines.Actors.Player, "Player/Player");
        Managers.UI.ShowSceneUI<UI_BackGround>("UI_BackGround");
        Managers.UI.ShowSceneUI<UI_GameInterface>("UI_GameInterface", player.transform);
        _gameOverScreen = Managers.UI.ShowSceneUI<UI_GameOver>("UI_GameOver");

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
