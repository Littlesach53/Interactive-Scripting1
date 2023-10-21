using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{

    // The only thing I couldnt figure out or make work was being able to adjust the random range in the Inspector.

    [SerializeField]
    GameObject prefabCube;
    
    public int cubeAmount = 25;
    public float cubeInterval = 2f;

    public string[] names = {"Tony, Steve, Bruce"};

 public Color[] colors;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnLoop());
        Debug.Log("The first name in the array is" + names[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
        StartCoroutine(spawnLoop());
        }
        if(Input.GetKeyDown(KeyCode.P)) {
    StartCoroutine(CollectCubes());
}
    }

    GameObject SpawnCube()  {
GameObject cube = Instantiate(prefabCube);

cube.transform.position = new Vector3(Random.Range(-20, 20), 2, Random.Range(-20, 20));


cube.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];

cube.name = names[Random.Range(0, names.Length)];

return cube;
    }

    IEnumerator CollectCubes() {
    GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

    int i = 0;
   // yield return new WaitForEndOfFrame();
    while(i < cubes.Length) {
        cubes[i].transform.position = new Vector3(0,2,0);
        yield return new WaitForSeconds(.02f);
        i += 1;
         

    }

}
    IEnumerator spawnLoop() {
        int counter = 0;
        while (counter < cubeAmount) {
            counter +=1;
            SpawnCube();
            yield return new WaitForSeconds(cubeInterval);

        }
    }
}
