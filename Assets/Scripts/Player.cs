using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player inst;

    [Header("Move")] 
	[SerializeField] private float speed = 16f;
	[SerializeField] private float rotSpeed = 0.75f;
	[SerializeField] private float modBackSpeed = 0.75f;
    [SerializeField] private float forceOfJump = 200f;
    [SerializeField] private float jumpCoolDown = 1f;

    [Header("Other")]
    [SerializeField] public int Key = 0;

    private bool canJump = false;
    private float timeAfterJump = 0;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * -speed * modBackSpeed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().MoveRotation(GetComponent<Rigidbody>().rotation * Quaternion.Euler(Vector3.up * -rotSpeed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().MoveRotation(GetComponent<Rigidbody>().rotation * Quaternion.Euler(Vector3.up * rotSpeed));
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * forceOfJump, ForceMode.Impulse);
            canJump = false;
            timeAfterJump = 0;
        }
    }

    void Update()
	{
        if (timeAfterJump >= jumpCoolDown)
        {
            canJump = true;
        }
        else
        {
            timeAfterJump += Time.deltaTime;
        }
    }
}
