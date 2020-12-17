using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player inst;

	[SerializeField] private float speed = 6;
	[SerializeField] private float rotSpeed = 35;

	void Start()
	{
		
	}

	
	void Update()
	{
		var ver = Input.GetAxis("Vertical");

		if (ver != 0)
		{
			transform.Translate(transform.forward * Time.deltaTime * speed * ver);
		}

		var hor = Input.GetAxis("Horizontal");

		if (hor != 0)
		{
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + Time.deltaTime * rotSpeed * hor, 0);
		}
	}
}
