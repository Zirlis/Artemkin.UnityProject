using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] private GameObject Eye;
    [SerializeField] private int chanceToSpawn = 25;    


    private void OnTriggerEnter(Collider other)
    {
        int rnd = Random.Range(0, 100);
        if (other.CompareTag("MonsterTarget") && rnd <= chanceToSpawn)
        {            
            Instantiate(Eye, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
