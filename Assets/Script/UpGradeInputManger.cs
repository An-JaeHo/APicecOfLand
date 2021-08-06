using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGradeInputManger : MonoBehaviour
{
    public Camera gameCamera;
    public Transform hitObj;

    void Start()
    {
        gameCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            TouchHit();
        }
        else
        {
            Mounshit();
        }
    }

    private void Mounshit()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = gameCamera.ScreenToWorldPoint(mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, gameCamera.transform.forward, 800);

            if (hit)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    switch (hit.transform.tag)
                    {
                        case "Army":
                            Debug.Log(hit.transform.tag);
                            break;
                    }
                }
            }
        }
    }

    private void TouchHit()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;
            touchPosition = gameCamera.ScreenToWorldPoint(touchPosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, gameCamera.transform.forward, 800);

            if (hit)
            {

                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    hitObj = hit.transform;

                    switch (hit.transform.tag)
                    {
                        case "Army":
                            if (hit.transform.GetComponent<SoldierManger>().movePoint)
                            {
                            }
                            break;
                    }
                }
            }

        }
    }
}
