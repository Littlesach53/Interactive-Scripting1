using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
     private float startingFOV = 60f;
     private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject.transform.GetChild(0).GetComponent<Camera>();
        startingFOV = cam.fieldOfView;
    }

    // Update is called once per frame
   public void ZoomOut()
   {
cam.fieldOfView = startingFOV + 15;
   }

   public void DefaultZoom()
   {
cam.fieldOfView = startingFOV;
   }
}
