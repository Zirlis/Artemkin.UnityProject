using UnityEngine;

public class Button : MonoBehaviour
{   

    [SerializeField] private float rotSpeed = 30f;
    [SerializeField] private bool openDoor = false;
    [SerializeField] private float speedToFall = 0.06f;
    [SerializeField] private Transform Door;


    private void Update()
    {
        if (openDoor && Door.transform.rotation != Quaternion.Euler(90, 0, 0))
        {
            Door.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
            gameObject.transform.Translate(Vector3.up * -speedToFall * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openDoor = true;
            Destroy(gameObject, 3);
        }
    }
}
