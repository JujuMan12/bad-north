using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float dragSpeed = 3;
    [SerializeField] private float angleMin = 10f;
    [SerializeField] private float angleMax = 80f;

    private void Update()
    {
        DragCamera();
        ConfineCamera();
    }

    private void DragCamera()
    {
        if (Input.GetButton("Camera Rotation"))
        {
            float dragX = Input.GetAxis("Mouse Y") * dragSpeed;
            float dragY = Input.GetAxis("Mouse X") * dragSpeed;

            Vector3 rotationDrag = new Vector3(dragX, dragY, 0f);
            transform.Rotate(rotationDrag);
        }
    }

    private void ConfineCamera()
    {
        float angleX = transform.rotation.eulerAngles.x;
        angleX = Mathf.Clamp(angleX, angleMin, angleMax);
        transform.rotation = Quaternion.Euler(angleX, transform.rotation.eulerAngles.y, 0f);
    }
}
