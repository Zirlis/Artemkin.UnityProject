using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player inst;

    [Header("Move")] 
	[SerializeField] private float speed = 16f;
	[SerializeField] private float rotSpeed = 120f;
	[SerializeField] private float modBackSpeed = 0.75f;
    [SerializeField] private float forceOfJump = 200f;
    [SerializeField] private float jumpCoolDown = 1f;
    [SerializeField] private float eulerY;
    [SerializeField] private float eulerX;

    [Header("Other")]
    [SerializeField] public int Key = 0;
    [SerializeField] Transform Camera;

    private bool canJump = false;
    private float timeAfterJump = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
            GetComponent<Rigidbody>().AddForce(transform.right * -speed * modBackSpeed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(transform.right * speed * modBackSpeed, ForceMode.Impulse);
        }
        

        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * forceOfJump, ForceMode.Impulse);
            canJump = false;
            timeAfterJump = 0;
        }
    }

    void Update()
	{
        float X = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        float Y = -Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
        eulerX = (Camera.rotation.eulerAngles.x + Y) % 360;
        eulerY = (transform.rotation.eulerAngles.y + X) % 360;        

        transform.rotation = Quaternion.Euler(0, eulerY, 0);
        if (eulerX >= 60 && eulerX <= 90)
            eulerX = 60;
        if (eulerX <= 270 && eulerX >= 250)
            eulerX = 270;

        Camera.rotation = Quaternion.Euler(eulerX, eulerY, 0);

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
