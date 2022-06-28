using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorldDmg : UI_Base
{
    private DynamicActor _parentComponent       = null;
    private CircleCollider2D _parentCollider    = null;
    private float _popPower                     = 0f;
    private Vector3 _popDir                     = Vector3.zero;
    private Color _fontColor                    = Color.white;
    private TextMeshProUGUI _dmgFont            = null;

    public float Damage { get; set; }
    enum Text
    {
        DamageText,
    }

    protected override void Init()
    {
        BindText(typeof(Text));

        _parentComponent = transform.parent.GetComponent<DynamicActor>();
        _parentCollider = transform.parent.GetComponent<CircleCollider2D>();
        _popPower = Random.Range(0.5f, 1f);
        _dmgFont = GetText((int)Text.DamageText);

        transform.position = transform.parent.position + (Vector3.up * _parentCollider.radius * 1.5f);

        if (_parentComponent.ActType == Defines.Actors.Player)
        {
            _fontColor = _dmgFont.color = new Color(0.99f, 0.3f, 0.3f, 1f);
            _popDir = new Vector3(-Random.Range(0, 0.5f), Random.Range(0.5f, 1f), 0).normalized;
        }
        else if (_parentComponent.ActType == Defines.Actors.Monster)
        {
            _fontColor = _dmgFont.color = new Color(1f, 1f, 1f, 1f);
            _popDir = new Vector3(Random.Range(0, 0.5f), Random.Range(0.5f, 1f), 0).normalized;
        }

        StartCoroutine(Active());
    }

    private IEnumerator Active()
    {
        float fadeText = 1;
        _dmgFont.text = Damage.ToString();

        while (true)
        {
            if (fadeText <= 0f)
                break;
            fadeText -= 0.05f;
            yield return new WaitForSeconds(0.01f);

            _dmgFont.color = new Color(_fontColor.r, _fontColor.g, _fontColor.b, fadeText);
        }

        Destroy(this.gameObject);
        StopCoroutine(Active());
    }

    private void Update()
    {
        transform.Translate(_popDir * _popPower * Time.deltaTime);
    }
}
