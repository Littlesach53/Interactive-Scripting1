using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBall : MonoBehaviour

{
    public static WreckingBall Instance { get; set; }
    [SerializeField]
    private float returnDelay = 1;
     [SerializeField]
    private float launchForce = 30;

    private Rigidbody rb;
    private Transform ballStart;

    private bool readyToLaunch = true;

    [SerializeField]
    AnimationCurve curve;


    [SerializeField]
    private float intervalInSeconds = 1;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        ballStart = GameObject.Find("BallStart").transform;
    }
    
    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.Mouse0))
       // {
       //     Launch();
       // }

        if (readyToLaunch)
        {
            this.transform.position = ballStart.position;
            this.transform.rotation = ballStart.rotation;
        }
    }

    public void Launch()
    {
        StartCoroutine(Return());
        readyToLaunch = false;
        rb.isKinematic = false;
        rb.AddForce(ballStart.forward * launchForce, ForceMode.Impulse);
    }

    private IEnumerator Return()
    {
        yield return new WaitForSeconds(returnDelay);
        rb.isKinematic = true;
       // this.transform.localPosition = new Vector3(0, 0, 0);
      //  this.transform.localRotation = Quaternion.identity;

        float counter = 0;
      //  float intervalInSeconds = 1;
        Vector3 startPosition = this.transform.position;
      //  Vector3 endPosition = ballStart.position;
      Quaternion startRotation = this.transform.rotation;

        while (counter < intervalInSeconds)
        {
            counter += Time.deltaTime;
         this.transform.position = Vector3.Lerp(startPosition, ballStart.position, curve.Evaluate(counter / intervalInSeconds));
         this.transform.rotation = Quaternion.Lerp(startRotation, ballStart.rotation, curve.Evaluate(counter / intervalInSeconds));
         yield return new WaitForEndOfFrame();
        }

        readyToLaunch = true; 
}
}
