using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPositin = target.position + offset;

            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPositin, smoothSpeed);

            transform.position = smoothPosition;
        }
    }
}
