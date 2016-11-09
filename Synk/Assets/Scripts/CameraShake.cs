using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    private float InterpolationTime = 0f;

    private Vector2 nextPosition = Vector2.zero;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {

    }

    public void ShakeFor(float time)
    {
        nextPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * shakeAmount;
        InterpolationTime = 0f;
        shakeDuration += time;
    }

    void Update()
    {
        InterpolationTime += 8f * Time.deltaTime;

        if (shakeDuration > 0)
        {
            if (InterpolationTime > 1f)
            {
                InterpolationTime = 0f;
                nextPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * shakeAmount;
            }
        }
        else
        {
            nextPosition = Vector2.zero;
        }
        
        camTransform.localPosition = new Vector3(
            Mathf.Lerp(camTransform.localPosition.x, nextPosition.x, InterpolationTime),
            Mathf.Lerp(camTransform.localPosition.y, nextPosition.y, InterpolationTime),
            0f);

        shakeDuration -= Time.deltaTime * decreaseFactor;
        shakeDuration = Mathf.Max(0f, shakeDuration);
    }
}