using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update

    private Camera mainCam;
    private Vector3 offset;
    private float maxLeft;
    private float maxRight;
    private float maxDown;
    private float maxUp;


    void Start()
    {
        mainCam = Camera.main;
        StartCoroutine(SetBoundaries());

    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.activeTouches.Count > 0)
        {


            if (Touch.activeTouches[0].finger.index == 0)
            {
                Touch myTouch = Touch.activeTouches[0];
                Vector3 touchPos = myTouch.screenPosition;
                
                if(myTouch.tapCount == 1){
                    Debug.Log("Double Tap");
                }

#if UNITY_EDITOR
                if (touchPos.x == Mathf.Infinity)
                    return;
#endif
                touchPos = mainCam.ScreenToWorldPoint(touchPos);

                if (Touch.activeTouches[0].phase == TouchPhase.Began)
                {
                    offset = touchPos - transform.position;
                }
                touchPos.z = 0;
                if (Touch.activeTouches[0].phase == TouchPhase.Moved)
                {

                    transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);
                }

                if (Touch.activeTouches[0].phase == TouchPhase.Stationary)
                {
                    transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);
                }

            }


            transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxLeft, maxRight), Mathf.Clamp(transform.position.y, maxDown, maxUp), 0);


        }

    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(0.4f);
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.10f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.90f, 0)).x;
        maxDown = mainCam.ViewportToWorldPoint(new Vector2(0, 0.05f)).y;
        maxUp = mainCam.ViewportToWorldPoint(new Vector2(0, 0.6f)).y;
    }
}
