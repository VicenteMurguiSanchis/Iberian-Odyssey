using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    private ARRaycastManager rayManager;

    private GameObject plano;

    void Start ()
    {
        rayManager = FindObjectOfType<ARRaycastManager>();

        plano = transform.GetChild(0).gameObject;

        plano.SetActive(false);
    }

    void Update ()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
        
        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if(!plano.activeInHierarchy)
            {
                plano.SetActive(true);
            }
        }
    }
}
