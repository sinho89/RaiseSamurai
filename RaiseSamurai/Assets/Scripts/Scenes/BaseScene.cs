using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class BaseScene : MonoBehaviour
{
    public Defines.Scenes SceneType { get; protected set; } = Defines.Scenes.Unknown;
    public string SceneName { get; protected set; } = "Unknown";

    private void Start()
    {
        Init();
        SceneSetting();
        ObjectInit();
    }

    protected virtual void Init()
    {
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj == null)
            Managers.Resource.Instantiate("Common/EventSystem").name = "@EventSystem";


        obj = GameObject.Find("ScreenFader");
        if(obj == null)
            Managers.Scene._screenFaderImg = Utils.FindChild<Image>(Managers.Resource.Instantiate("Common/ScreenFader"), "FadePanel", true);
        else
            Managers.Scene._screenFaderImg = Utils.FindChild<Image>((GameObject)obj, "FadePanel", true);

        Managers.Scene._screenFaderImg.raycastTarget = false;
        Managers.Scene._screenFaderImg.color = new Color(0, 0, 0, 1);

        StartCoroutine(SceneForFadeIn());
    }

    protected virtual void Update()
    {
        if(Managers.Scene._isSceneChange)
        {
            if(Managers.Scene._MovingScene == Defines.Scenes.Unknown)
            {
                Managers.Scene._isSceneChange = false;
                return;
            }

            StartCoroutine(SceneForFadeOut(Managers.Scene._MovingScene));
            Managers.Scene._isSceneChange = false;
        }
    }

    private IEnumerator SceneForFadeIn() // Scene Open
    {
        float fadeCount = 1f;
        while (fadeCount > 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            Managers.Scene._screenFaderImg.color = new Color(0, 0, 0, fadeCount);
        }

        Managers.Scene._screenFaderImg.raycastTarget = false;
    }
    private IEnumerator SceneForFadeOut(Defines.Scenes scene) // Scene Close
    {
        Managers.Scene._screenFaderImg.raycastTarget = true;

        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Managers.Scene._screenFaderImg.color = new Color(0, 0, 0, fadeCount);
        }

        Managers.Scene.LoadScene(scene);
    }


    // 각 Child Scene들에 필요한 공통적인 매서드 추상화
    protected abstract void SceneSetting();
    protected abstract void ObjectInit();
    public abstract void Clear();
}
