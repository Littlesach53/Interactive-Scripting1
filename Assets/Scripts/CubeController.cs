using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
  private SpawnCubes spawnC;
public int cubeSpeed;
public int riseSpeed;


   [Header("Audio Clips")]
    [SerializeField] private AudioClip ascend;
    [SerializeField] private AudioClip descend;

    private AudioSource aud;
    void Start()
    {
        spawnC = this.GetComponent<SpawnCubes>();
      cubeSpeed = Random.Range(1, 10);
       aud = this.GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
         this.transform.Translate(0, riseSpeed * Time.deltaTime, 0);
    }


    public void GetCollected() {
       aud.pitch += Random.Range(.5f, 1.2f);
        if(cubeSpeed > 6){
         gameObject.GetComponent<Renderer>().material.color = Color.green;
         riseSpeed += 5;
          this.GetComponent<Rigidbody>().isKinematic = true;
          aud.PlayOneShot(ascend);
          Destroy(gameObject, 5f);
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            aud.PlayOneShot(descend);
            Destroy(gameObject, 1f);
        }
    }
}
