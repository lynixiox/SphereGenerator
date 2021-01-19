using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera camera;
    public GameObject parent;

    public float zoomSensitivity = 20.0f;
    public float zoomSpeed = 20.0f;
    public float zoomMin = 5.0f;
    public float zoomMax = 80.0f;

    private float zoom;


    // Start is called before the first frame update
    void Start()
    {
        zoom = camera.fieldOfView;
        camera.transform.LookAt(parent.transform.position);
        //comment//
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float h = 5 * Input.GetAxis("Mouse Y");
            float y = (5 * Input.GetAxis("Mouse X")) * -1;

            Vector3 axisOfRotation = new Vector3(h, y, 0) * 10;
            camera.transform.LookAt(parent.transform.position);
            camera.transform.RotateAround(parent.transform.position, axisOfRotation, 30 * Time.deltaTime);
            camera.transform.Rotate(0, Time.deltaTime * 30, 0, Space.Self);

        }

        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);


    }


    void LateUpdate()
    {
        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoom, Time.deltaTime * zoomSpeed);   
    }
}
