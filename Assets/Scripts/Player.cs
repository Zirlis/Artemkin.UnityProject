using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player inst;

	[SerializeField] private float speed = 3.2f;
	[SerializeField] private float rotSpeed = 50f;
	[SerializeField] private float modBackSpeed = 0.6f;
	[SerializeField] public int Key = 0;	

	[SerializeField]
    private void Start()
    {
    }
	
	void Update()
	{
		//var ver = Input.GetAxis("Vertical");

		//if (ver != 0)
		//{
		//	transform.Translate(transform.forward * Time.deltaTime * speed * ver);
		//}

		//var hor = Input.GetAxis("Horizontal");

		//if (hor != 0)
		//{
		//	transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + Time.deltaTime * rotSpeed * hor, 0);
		//}

		if(Input.GetKey(KeyCode.W))
        {
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.forward * -speed * modBackSpeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(Vector3.up * -rotSpeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
		}		
	}    
}
