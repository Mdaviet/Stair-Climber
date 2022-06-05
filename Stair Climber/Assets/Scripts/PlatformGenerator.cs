using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platform;
    public Queue platformOrder = new Queue();

    GameObject lastPlatform;

    // Start is called before the first frame update
    void Start()
    {
        lastPlatform = Instantiate(platform);

        for (int i = 0; i < 10; i++)
        {
            createPlatform();
        }
        Debug.Log("finish");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createPlatform()
    {
        float rng = Random.value; // returns 0 or 1
        int nextStep = (int)(rng * 2);

        Debug.Log(nextStep);


        if (nextStep == 1) // Right step
        {
            Instantiate(platform, new Vector3((lastPlatform.transform.position.x + 1), (lastPlatform.transform.position.y + (float)0.5), 0), Quaternion.identity);
            lastPlatform.transform.position = lastPlatform.transform.position + new Vector3(1, (float)0.5, 0);

            platformOrder.Enqueue('r');
        }
        else if (nextStep == 0) // Left step
        {
            Instantiate(platform, new Vector3((lastPlatform.transform.position.x - 1), (lastPlatform.transform.position.y + (float)0.5), 0), Quaternion.identity);
            lastPlatform.transform.position = lastPlatform.transform.position + new Vector3(-1, (float)0.5, 0);

            platformOrder.Enqueue('l');
        }
    }
}
