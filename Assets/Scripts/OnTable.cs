using UnityEngine;

public class OnTable : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] private float rotSpeed = -30f;

    [SerializeField] GameObject Bone1;
    [SerializeField] GameObject Bone2;
    [SerializeField] GameObject Bone3;
    [SerializeField] GameObject Bone4;
    [SerializeField] GameObject Bone5;

    [SerializeField] bool boneOnTable1 = false;
    [SerializeField] bool boneOnTable2 = false;
    [SerializeField] bool boneOnTable3 = false;
    [SerializeField] bool boneOnTable4 = false;
    [SerializeField] bool boneOnTable5 = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Bone1)
            boneOnTable1 = true;
        if (other.gameObject == Bone2)
            boneOnTable2 = true;
        if (other.gameObject == Bone3)
            boneOnTable3 = true;
        if (other.gameObject == Bone4)
            boneOnTable4 = true;
        if (other.gameObject == Bone5)
            boneOnTable5 = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Bone1)
            boneOnTable1 = false;
        if (other.gameObject == Bone2)
            boneOnTable2 = false;
        if (other.gameObject == Bone3)
            boneOnTable3 = false;
        if (other.gameObject == Bone4)
            boneOnTable4 = false;
        if (other.gameObject == Bone5)
            boneOnTable5 = false;
    }

    private void Update()
    {
        if(boneOnTable1 && boneOnTable2 && boneOnTable3 && boneOnTable4 && boneOnTable5)
        {
            Destroy(Bone1);
            Destroy(Bone2);
            Destroy(Bone3);
            Destroy(Bone4);
            Destroy(Bone5);

            if (Door.transform.rotation != Quaternion.Euler(-90, 0, 0))
            {
                Door.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
            }
        }
    }
}
