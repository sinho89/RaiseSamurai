using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorldLevelUp : UI_Base
{
    private CircleCollider2D _parentCollider = null;
    private TextMeshProUGUI _levelUpFont = null;

    enum Text
    {
        WorldLevelUpText,
    }

    protected override void Init()
    {
        BindText(typeof(Text));

        _parentCollider = transform.parent.GetComponent<CircleCollider2D>();
        _levelUpFont = GetText((int)Text.WorldLevelUpText);

        transform.position = transform.parent.position + (Vector3.up * _parentCollider.radius * 1.5f);

        StartCoroutine(Active());
    }

    private IEnumerator Active()
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
        StopCoroutine(Active());
    }

    private void Update()
    {
        transform.Translate(Vector3.up * 1f * Time.deltaTime);
    }
}
