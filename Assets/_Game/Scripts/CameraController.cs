
using System.Collections.Generic;
using UnityEngine;
class CameraController : MonoBehaviour
{
    [ReadOnly] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothnessMovement;
    private void Start()
    {
    }
    private void Update()
    {
        if(target != null)
            Move();
    }
    void Move()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 finalPos = Vector3.Lerp(transform.position, desiredPos, smoothnessMovement * Time.deltaTime);
        transform.position = finalPos;
    }

    public void AssignTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
