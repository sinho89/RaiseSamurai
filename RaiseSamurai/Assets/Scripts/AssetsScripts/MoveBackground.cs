using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : BackGround 
{
	public float speed;
	private float x;
	public float PontoDeDestino;
	public float PontoOriginal;
	public bool _isMoving = true;

	protected override void Init()
	{
		base.Init();
	}
	protected override void Update()
	{
		base.Update();

		if (_isMoving == true)
		{
			x = transform.position.x;
			x += speed * Time.deltaTime;
			transform.position = new Vector3(x, transform.position.y, transform.position.z);

			if (x <= PontoDeDestino)
			{
				x = PontoOriginal;
				transform.position = new Vector3(x, transform.position.y, transform.position.z);
			}
		}
	}

	public override void Clear()
	{

	}
}
