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

    private Animation openDoor1;
    private Animation openDoor2;
    private Animation openDoor3;
    private Animation openDoor4;

    //float rotSpeed = 90f;

    [SerializeField] private bool canTouch = false;    
    [SerializeField] private bool action = false;
    public float time = 0;

    private void Awake()
    {
        openDoor1 = Door1.GetComponent<Animation>();
        openDoor2 = Door2.GetComponent<Animation>();
        openDoor3 = Door3.GetComponent<Animation>();
        openDoor4 = Door4.GetComponent<Animation>();
    }

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
                openDoor1.Play("DoorAnimationLeft");
            }
            else
            {
                openDoor1.Play("DoorAnimationRight");
            }

            if (door2WarRotated)
            {
                openDoor2.Play("DoorAnimationLeft");
            }
            else
            {
                openDoor2.Play("DoorAnimationRight");
            }

            if (door3WarRotated)
            {
                openDoor3.Play("DoorAnimationLeft");
            }
            else
            {
                openDoor3.Play("DoorAnimationRight");
            }

            if (door4WarRotated)
            {
                openDoor4.Play("DoorAnimationLeft");
            }
            else
            {
                openDoor4.Play("DoorAnimationRight");
            }

            if (time >= 1)
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
