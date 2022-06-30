using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorldLevelUp : UI_Base
{
    private TextMeshProUGUI _levelUpFont = null;

    enum Text
    {
        WorldLevelUpText,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindText(typeof(Text));

        _levelUpFont = GetText((int)Text.WorldLevelUpText);

        transform.position = transform.position + (Vector3.up * 1f);

        StartCoroutine(CoActive());

        return true;
    }

    private IEnumerator CoActive()
    {
        float fadeText = 1;

        while (true)
        {
            if (fadeText <= 0f)
                break;
            fadeText -= 0.05f;
            yield return new WaitForSeconds(0.01f);
            _levelUpFont.color = new Color(1f, 1f, 1f, fadeText);
        }

        Destroy(this.gameObject);
        StopCoroutine(CoActive());
    }

    private void Update()
    {
        transform.Translate(Vector3.up * 1.5f * Time.deltaTime);
    }
}
