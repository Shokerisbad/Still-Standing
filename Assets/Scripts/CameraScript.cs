using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Camera camera;
    private float aspect, windowAspect, scaleHeight, scaleWidth, sWidth, sHeight;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        if (Application.platform != RuntimePlatform.Android)
        {
            camera.transform.Find("BorderW").gameObject.SetActive(false);
            camera.transform.Find("BorderE").gameObject.SetActive(false);
        }

        aspect = 16.0f / 9.0f;
        sWidth = Screen.width;
        sHeight = Screen.height;
        setCamera();
    }

    private void Update()
    {
        if (Screen.width != sWidth || Screen.height != sHeight)
        {
            sWidth = Screen.width;
            sHeight = Screen.height;
            setCamera();
        }
    }

    void setCamera()
    {
        if (Application.platform == RuntimePlatform.Android)
            return;

        windowAspect = (float)Screen.width / (float)Screen.height;
        scaleHeight = windowAspect / aspect;
        scaleWidth = 1.0f / scaleHeight;

        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}
