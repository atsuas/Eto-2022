using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Raycast : MonoBehaviour
{
    private ARRaycastManager m_RaycastManager;

    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    [SerializeField]
    private GameObject characterPrefab;
    
    void Start()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (m_RaycastManager.Raycast(touch.position, hitResults, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hitResults[0].pose;
                    GameObject character = Instantiate(characterPrefab, hitPose.position, hitPose.rotation);
                }
            }
        }
    }
}
