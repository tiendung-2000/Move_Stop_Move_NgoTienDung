using System.Collections;
using UnityEngine;

public enum CameraState
{
    MainMenu = 0, Skin = 1, Gaming = 2
}
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    public Vector3[] offsetPositions;
    public Vector3[] offsetTargets;

    [SerializeField] private float speedFollow;
    [SerializeField] private float speedSwitch;

    private Vector3 currentOffsetPosition;
    private Vector3 currentOffsetTarget;
    private Vector3 startOffsetPos;
    private Vector3 startOffsetTarget;

    private float higherValue = 1.05f;

    public static CameraController instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentOffsetPosition = offsetPositions[(int)CameraState.MainMenu];
        currentOffsetTarget = offsetTargets[(int)CameraState.MainMenu];
        StartCoroutine(SwitchTo(CameraState.MainMenu));
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + currentOffsetPosition, speedFollow * Time.deltaTime);
        transform.LookAt(target.position + currentOffsetTarget);
    }

    public IEnumerator SwitchTo(CameraState cameraState)
    {
        startOffsetPos = currentOffsetPosition;
        startOffsetTarget = currentOffsetTarget;
        float duration = speedSwitch;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                currentOffsetPosition = Vector3.Lerp(startOffsetPos, offsetPositions[(int)cameraState], t);
                currentOffsetTarget = Vector3.Lerp(startOffsetTarget, offsetTargets[(int)cameraState], t);
            }
            yield return null;
        }
        yield return null;
    }

    public void StartCotoutineSwitchTo(CameraState cameraState)
    {
        StartCoroutine(SwitchTo(cameraState));
    }

    public void MoveHigher()
    {
        currentOffsetPosition *= higherValue;
        currentOffsetTarget *= higherValue;
    }

}
