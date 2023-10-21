using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInput : MonoBehaviour
{
    [SerializeField] private CamController camcon;
    private ShipMovement shipMove;


    // Start is called before the first frame update
    void Start()
    {
        if (camcon == null) camcon = this.gameObject.GetComponent<CamController>();
        shipMove = this.GetComponent<ShipMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) camcon.ZoomOut();
        if (Input.GetKeyUp(KeyCode.Mouse1)) camcon.DefaultZoom();

         if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            WreckingBall.Instance.Launch();
        }
    }

    void FixedUpdate() 
    {
        shipMove.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }
}
