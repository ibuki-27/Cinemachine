using UnityEngine;

public class AutoWalk : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
