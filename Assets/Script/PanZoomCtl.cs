using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoomCtl : MonoBehaviour
{
    Vector3 touchStart;

    public float dragMagnitude = 0.5f;
    
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

    private Bounds _cameraBounds;
    private Vector3 _targetPosition;

    private Camera _mainCamera;
    
    [SerializeField]public static bool enabled;
    // static PanZoomCtl Instance;
    //
    private void Awake()
    {
        _mainCamera = Camera.main;;
    }

    private void Start()
    {
        var height = _mainCamera.orthographicSize;
        var width = height * _mainCamera.aspect;

        var minX = Globals.WorldBounds.min.x + width;
        var maxX = Globals.WorldBounds.extents.x - width;

        var minY = Globals.WorldBounds.min.y + height;
        var maxY = Globals.WorldBounds.extents.y - height;

        _cameraBounds = new Bounds();
        _cameraBounds.SetMinMax(
            new Vector3(minX, minY, 0.0f),
            new Vector3(maxX, maxY, 0.0f)
        );
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && enabled)
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.touchCount == 2 && enabled)
        {
            Touch touchZero = Input.GetTouch(0); // first touch
            Touch touchOne = Input.GetTouch(1); // second touch
            
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition; // position of the first touch in the previous frame
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition; // position of the second touch in the previous frame
            
            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude; // distance between touches in the previous frame
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude; // distance between touches in the current frame
            
            float difference = currentMagnitude - prevMagnitude; // difference between the distances
            
            zoom(difference * 0.01f);
        }

        if (Input.GetMouseButton(0) && enabled)
        {
            
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(direction.magnitude > dragMagnitude)
                Camera.main.transform.position += direction;
            // _targetPosition = Camera.main.transform.position + direction;
            // _targetPosition = GetCameraBounds();
            //
            // Camera.main.transform.position = _targetPosition;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }
    
    private Vector3 GetCameraBounds()
    {
        return new Vector3(
            Mathf.Clamp(_targetPosition.x, _cameraBounds.min.x, _cameraBounds.max.x),
            Mathf.Clamp(_targetPosition.y, _cameraBounds.min.y, _cameraBounds.max.y),
            transform.position.z
        );
    }
    
    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
