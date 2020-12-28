using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float rotSpeed = 25f;   
    [SerializeField] private float timeToCycle = 5f;
    [SerializeField] private float timeToLife = 0f;
    public Player player;
    float time = 0;
    void Update()
    {
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);       
        time += Time.deltaTime;

        if(time % timeToCycle < timeToCycle/2)
        {
            
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            
        }
        else
        {
            transform.Translate(Vector3.up * -speed * Time.deltaTime);
        }

        if(time >= timeToCycle)
        {
            time -= timeToCycle;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.Key ++;
            Destroy(gameObject, timeToLife);
        }
    }
}
