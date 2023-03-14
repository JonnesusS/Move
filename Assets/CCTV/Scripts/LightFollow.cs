using UnityEngine;

public class LightFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform CCTVTransform;
    [SerializeField] float maxDistance = 6f;
    float distanceToTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
    }

    void LookAtTarget()
    {
        distanceToTarget = Vector3.Distance(playerTransform.position, CCTVTransform.position);

        if (distanceToTarget <= maxDistance)
        {
            Vector3 lookVector = playerTransform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.01f);
        }
    }
}