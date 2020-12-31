using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject Door;   
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            Destroy(Door);
            Destroy(gameObject);
        }
    }
}
