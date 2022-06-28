using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHPBar : UI_Base
{
    DynamicActor _parentComponent = null;
    CircleCollider2D _parentCollider = null;
    enum Image
    {
        HpGage,
    }

    protected override void Init()
    {
        BindImage(typeof(Image));

        _parentComponent = transform.parent.GetComponent<DynamicActor>();
        _parentCollider = transform.parent.GetComponent<CircleCollider2D>();

        transform.position = transform.parent.position + (Vector3.up * _parentCollider.radius);
        //transform.position = _parentCollider.radius;

        if (_parentComponent.ActType == Defines.Actors.Player)
            GetImage((int)Image.HpGage).color = new Color(0.6f, 0.99f, 0.3f, 1f);
        else if(_parentComponent.ActType == Defines.Actors.Monster)
            GetImage((int)Image.HpGage).color = new Color(0.99f, 0.3f, 0.3f, 1f);

    }

    private void Update()
    {
        transform.position = transform.parent.position + (Vector3.up * _parentCollider.radius);
        //transform.position = _parentCollider.transform.up;
        GetImage((int)Image.HpGage).fillAmount = (float)_parentComponent.Hp / _parentComponent.MaxHp;

    }
}
