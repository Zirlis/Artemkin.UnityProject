using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boll : MonoBehaviour
{
    [SerializeField] private Transform Door;
    [SerializeField] GameObject Sphere;
    [SerializeField] private float rotSpeed = -30f;
    [SerializeField] private bool openDoor = false;
    private bool doorIsOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Floor"))
        {
            openDoor = true;
            Destroy(Sphere, 3);
        }
    }

    private void Update()
    {
        if (openDoor && Door.transform.rotation != Quaternion.Euler(-90, -90, 0))
        {
            Door.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
            if(!doorIsOpen)
            {
                doorIsOpen = true;
                Door.GetComponent<AudioSource>().Play();
            }
        }
    }    
}
