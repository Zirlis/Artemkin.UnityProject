using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book2 : MonoBehaviour
{
    [SerializeField] GameObject Door1;
    [SerializeField] GameObject Door2;
    [SerializeField] GameObject Door3;
    [SerializeField] GameObject Door4;

    [SerializeField] float rotSpeed = 90f;

    private bool canTouch = false;    
    private bool action = false;
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

    void Update()
    {
        if (!action && canTouch && Input.GetKey(KeyCode.E))
        {
            action = true;

            if (Door1.transform.rotation == Quaternion.Euler(-90, 0, 0))
            {
                Door1.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
            }
            else if (Door1.transform.rotation == Quaternion.Euler(-90, 90, 0))
            {
                Door1.transform.Rotate(Vector3.forward * -rotSpeed * Time.deltaTime);
            }

            if (Door2.transform.rotation == Quaternion.Euler(-90, 0, 0))
            {
                Door2.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
            }
            else if (Door2.transform.rotation == Quaternion.Euler(-90, 90, 0))
            {
                Door2.transform.Rotate(Vector3.forward * -rotSpeed * Time.deltaTime);
            }

            if (Door3.transform.rotation == Quaternion.Euler(-90, 0, 0))
            {
                Door3.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
            }
            else if (Door3.transform.rotation == Quaternion.Euler(-90, 90, 0))
            {
                Door3.transform.Rotate(Vector3.forward * -rotSpeed * Time.deltaTime);
            }

            if (Door4.transform.rotation == Quaternion.Euler(-90, 0, 0))
            {
                Door4.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
            }
            else if (Door4.transform.rotation == Quaternion.Euler(-90, 90, 0))
            {
                Door4.transform.Rotate(Vector3.forward * -rotSpeed * Time.deltaTime);
            }
        }

        if (action)
        {
            float time = Time.deltaTime;
            if (time >= 90 / rotSpeed)
            {
                time = 0;
                action = false;
            }
        }

    }
}
