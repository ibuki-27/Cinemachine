using UnityEngine;
using Unity.Cinemachine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private float radius = 5f;
    [SerializeField] private float height = 2f;
    [SerializeField] private float rotationSpeed = 45f;

    private CinemachineFollow follow;
    private float angle;

    private void Awake()
    {
        follow = GetComponent<CinemachineFollow>();
    }

    private void LateUpdate()
    {
        if (follow == null) return;

        angle += rotationSpeed * Time.deltaTime;

        float rad = angle * Mathf.Deg2Rad;

        float x = Mathf.Cos(rad) * radius;
        float z = Mathf.Sin(rad) * radius;

        follow.FollowOffset = new Vector3(x, height, z);
    }
}
