using UnityEngine;
using Unity.Cinemachine;

public class CameraRise : MonoBehaviour
{
    [SerializeField] private float startHeight = -0.8f;
    [SerializeField] private float endHeight = 1.5f;
    [SerializeField] private float duration = 3f;

    private CinemachineFollow follow;
    private float elapsedTime;
    private bool isRasing;

    private void Awake()
    {
        follow = GetComponent<CinemachineFollow>();
    }

    public void StartRise()
    {
        elapsedTime = 0f;
        isRasing = true;

        if (follow != null)
        {
            Vector3 offset = follow.FollowOffset;
            offset.y = startHeight;
            follow.FollowOffset = offset;
        }
    }

    private void LateUpdate()
    {
        if (!isRasing || follow == null) return;

        elapsedTime += Time.deltaTime;

        float t = Mathf.Clamp01(elapsedTime / duration);

        // Å‰‚ÆÅŒã‚ðŠŠ‚ç‚©‚É‚·‚é
        t = Mathf.SmoothStep(0f, 1f, t);

        Vector3 offset = follow.FollowOffset;

        offset.y = Mathf.Lerp(startHeight, endHeight, t);

        follow.FollowOffset = offset;

        if (elapsedTime >= duration)
        {
            isRasing = false;
        }
    }
}
