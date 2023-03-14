using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform CCTVTransform;
    [SerializeField] float maxDistance = 6f;
    float distanceToTarget;
    [SerializeField] float delayTimer = 2f;
    float tick;
    bool scanReady = true;

    // Start is called before the first frame update
    void Start()
    {
        tick = delayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        Scan();
    }

    bool IsReadyToScan()
    {
        if (tick < delayTimer)
        {
            tick += Time.deltaTime;
            return false;
        }

        return true;
    }

    void Scan()
    {
        distanceToTarget = Vector3.Distance(playerTransform.position, CCTVTransform.position);
        scanReady = IsReadyToScan();

        if (distanceToTarget <= maxDistance)
        {

            if (scanReady == true)
            {
                tick = 0f;
                Debug.Log("Object in range");
            }
        }
    }
}