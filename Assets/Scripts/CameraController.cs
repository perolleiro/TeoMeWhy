using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Sensitivity;
    public float Smoothing;

    public float YHighLimit;
    public float YLowLimit;

    private Vector2 look;
    private Vector2 smooth;

    private Vector2 scaleVector;

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        scaleVector = new Vector2(Sensitivity * Smoothing, Sensitivity * Smoothing);

        playerTransform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseMov = GetMouseMovement();

        mouseMov = Vector2.Scale(mouseMov, scaleVector);

        smooth.x = Mathf.Lerp(smooth.x, mouseMov.x, 1 / Smoothing);
        smooth.y = Mathf.Lerp(smooth.y, mouseMov.y, 1 / Smoothing);

        look += smooth;

        look.y = Mathf.Clamp(look.y, -YLowLimit, YHighLimit);

        transform.localRotation = Quaternion.AngleAxis(-look.y, Vector3.right);

        playerTransform.localRotation = Quaternion.AngleAxis(look.x, playerTransform.up);
    }

    private Vector2 GetMouseMovement()
    {
        return new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}
