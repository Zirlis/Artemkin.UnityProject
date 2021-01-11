using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject Door;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Door.GetComponent<AudioSource>().Play();
            Destroy(Door, 3);
            Destroy(gameObject);
        }
    }
}
