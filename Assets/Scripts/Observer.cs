using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float timeToLife = 1;
    

    void Start()
    {
        int rnd = Random.Range(0, 5);
        Destroy(gameObject, timeToLife + rnd);
    }

    void Update()
    {
        gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }    
}
