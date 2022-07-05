using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameOver : UI_Popup
{
    private bool _gameOverDraw = false;
    enum Image
    {
        GameOverImg,
    }
    enum Text
    {
        GameOverText,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindImage(typeof(Image));
        BindText(typeof(Text));

        GetImage((int)Image.GameOverImg).raycastTarget = false;
        GetImage((int)Image.GameOverImg).gameObject.BindEvent((PointEventData) => 
        {
            Managers.Scene._MovingScene = Defines.Scenes.Title;
            Managers.Scene._isSceneChange = true;
            ResetUI();
        });
        gameObject.SetActive(false);

        return true;
    }

    private void Update()
    {
        if(Managers.Actor._isGameOver && !_gameOverDraw)
        {
            _gameOverDraw = true;
            StartCoroutine(CoGameOverFade());
        }
    }

    private IEnumerator CoGameOverFade()
    {
        float fadeImageCount = 0;
        float fadeTextCount = 0;
        while (true)
        {
            if(fadeImageCount <= 0.49f)
                fadeImageCount += 0.005f;
            if (fadeTextCount <= 1f)
            {
                fadeTextCount += 0.005f;
            }
            else
            {
                GetImage((int)Image.GameOverImg).raycastTarget = true;
                break;
            }

            yield return new WaitForSeconds(0.01f);
            GetImage((int)Image.GameOverImg).color = new Color(0f, 0f, 0f, fadeImageCount);
            GetText((int)Text.GameOverText).color = new Color(1f, 1f, 1f, fadeTextCount);
        }

        StopCoroutine(CoGameOverFade());
    }
    private void ResetUI()
    {
        GetImage((int)Image.GameOverImg).raycastTarget = false;
        GetImage((int)Image.GameOverImg).color = new Color(0f, 0f, 0f, 0f);
        GetText((int)Text.GameOverText).color = new Color(1f, 1f, 1f, 0f);
        _gameOverDraw = false;
        gameObject.SetActive(false);
    }
}
