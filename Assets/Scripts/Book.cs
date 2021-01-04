using System.Collections;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] GameObject Door1;
    [SerializeField] GameObject Door2;
    [SerializeField] GameObject Door3;
    [SerializeField] GameObject Door4;

    public bool door1WarRotated;
    public bool door2WarRotated;
    public bool door3WarRotated;
    public bool door4WarRotated;


    float rotSpeed = 90f;

    [SerializeField] private bool canTouch = false;    
    [SerializeField] private bool action = false;
    public float time = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTouch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTouch = false;
        }
    }

    IEnumerator RotateOfDoors()
    {
        if (Door1.transform.rotation == Quaternion.Euler(-90, 0, 0))
            door1WarRotated = false;
        else
            door1WarRotated = true;

        if (Door2.transform.rotation == Quaternion.Euler(-90, 0, 0))
            door2WarRotated = false;
        else
            door2WarRotated = true;

        if (Door3.transform.rotation == Quaternion.Euler(-90, 0, 0))
            door3WarRotated = false;
        else
            door3WarRotated = true;

        if (Door4.transform.rotation == Quaternion.Euler(-90, 0, 0))
            door4WarRotated = false;
        else
            door4WarRotated = true;

        while (action)
        {            
            time += Time.deltaTime;

            if (door1WarRotated)
            {
                Door1.transform.Rotate(Vector3.forward * -rotSpeed * Time.deltaTime);
            }
            else 
            {
                Door1.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
            }

            if (door2WarRotated)
            {
                Door2.transform.Rotate(Vector3.forward * -rotSpeed * Time.deltaTime);
            }
            else
            {
                Door2.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
            }

            if (door3WarRotated)
            {
                Door3.transform.Rotate(Vector3.forward * -rotSpeed * Time.deltaTime);
            }
            else
            {
                Door3.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
            }

            if (door4WarRotated)
            {
                Door4.transform.Rotate(Vector3.forward * -rotSpeed * Time.deltaTime);
            }
            else
            {
                Door4.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
            }

            if (time >= 90 / rotSpeed)
            {
                action = false;
                time = 0;
            }
            else
                yield return null;
        }                                     
    }

    void Update()
    {
        if(!action && canTouch && Input.GetKey(KeyCode.E))
        {
            action = true;
            StartCoroutine(RotateOfDoors());
        }      
    }
}
