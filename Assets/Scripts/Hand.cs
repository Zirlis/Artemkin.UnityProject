using System;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [NonSerialized] public GameObject objectInHand;
    [SerializeField] public bool inHand = false;
    [NonSerialized] public float offset;
    private float smooth = 1.5f;
    [NonSerialized] public float maxDistance = 1.5f;    
    private bool canBeRaised = false;
    private float shiftMod = 0.5f;
    [NonSerialized] public float oldDrag;
    private float defaultDrag = 10f;
    Vector3 shift;
        

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("CanBeRaised") && !inHand)
        {
            objectInHand = other.gameObject;
            canBeRaised = true;
        }        
    }

    private void FixedUpdate()
    {   
        if (inHand)
        {
            shift = transform.right * shiftMod;
            objectInHand.GetComponent<Rigidbody>().AddForce((-objectInHand.transform.position + transform.position + shift) * smooth, ForceMode.Impulse);            
        }
    }

    private void Update()
    {
        if(inHand)
        {
            offset = Vector3.Distance(objectInHand.transform.position, transform.position);
                                   

            if (Input.GetKeyUp(KeyCode.Mouse0) || offset > maxDistance)
            {
                inHand = false;
                objectInHand.GetComponent<Rigidbody>().useGravity = true;                
                objectInHand.GetComponent<Rigidbody>().drag = oldDrag;
            }
            
        }

        if (Input.GetKey(KeyCode.Mouse0) && canBeRaised)
        {               
            objectInHand.GetComponent<Rigidbody>().useGravity = false;            
            oldDrag = objectInHand.GetComponent<Rigidbody>().drag;
            objectInHand.GetComponent<Rigidbody>().drag = defaultDrag;
            inHand = true;
        }

        canBeRaised = false;
    }
}
