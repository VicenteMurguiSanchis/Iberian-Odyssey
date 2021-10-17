using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class ObjectSpawner : MonoBehaviour
    {
        // Start is called before the first frame update

        public GameObject objectToSpawn;
        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        List<ARAnchor> m_Anchors = new List<ARAnchor>();

        ARRaycastManager m_RaycastManager;

        ARAnchorManager m_AnchorManager;

        void Awake()
        {
            m_RaycastManager = FindObjectOfType<ARRaycastManager>();
            m_AnchorManager = FindObjectOfType<ARAnchorManager>();
        }


        public void DejarElemento ()
        {
            
            if(m_RaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2),
                                        s_Hits,TrackableType.Planes))
            {
                var hit = s_Hits[0];

                var anchor = CreateAnchor(hit);

                if(anchor)
                {                        
                    m_Anchors.Add(anchor);
                }

                else{
                    Debug.Log("Problema al crear anchor");
                }
            }
            
        }

        public void RemoveAllAnchors()
        {
            foreach (var anchor in m_Anchors)
            {
                Destroy(anchor.gameObject);
            }
            m_Anchors.Clear();
        }

        ARAnchor CreateAnchor(in ARRaycastHit hit)
        {
            ARAnchor anchor = null;

            if(hit.trackable is ARPlane plane){
                var planeManager = FindObjectOfType<ARPlaneManager>();
                if (planeManager)
                {
                    var oldPrefab = m_AnchorManager.anchorPrefab;
                    m_AnchorManager.anchorPrefab = objectToSpawn;
                    anchor = m_AnchorManager.AttachAnchor(plane, hit.pose);
                    m_AnchorManager.anchorPrefab = oldPrefab;
                    return anchor;
                }
            }
            return anchor;
        }
    }
}
