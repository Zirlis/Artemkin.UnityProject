using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private GameObject objectInHand;
    private bool inHand = false;
    private Vector3 offset;
    private float smooth = 5f;
    private float maxDistance;

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKey(KeyCode.E) && other.CompareTag("CanBeRaised") && !inHand)
        {
            objectInHand = GameObject.FindWithTag("CanBeRaised");
            objectInHand.transform.position = transform.position;
            inHand = true;
        }
    }

    private void Update()
    {
        if(inHand && Input.GetKey(KeyCode.E))

        if (inHand)
        {
            transform.position = Vector3.Lerp(transform.position, objectInHand.transform.position + offset, Time.deltaTime * smooth);
        }
    }
}
