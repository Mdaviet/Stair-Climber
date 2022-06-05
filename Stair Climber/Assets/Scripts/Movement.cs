using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    char[] array = new char[] { 'l', 'l', 'l', 'l', 'r', 'r', 'l' };
    public int i = 0;

    char dir = 'l';
    char next;

    PlatformGenerator platformGenerator;
    [SerializeField] GameObject stepGeneration;
    
    //GameObject StepGeneration;
    //StepGeneration.GetComponent<PlatformGenerator>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        platformGenerator = stepGeneration.GetComponent<PlatformGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            next = (char)platformGenerator.platformOrder.Dequeue();

            if (dir == next)
            {
                if (next == 'l')
                    gameObject.transform.position = new Vector2(transform.position.x - 1, transform.position.y + (float)0.5);

                else if (next == 'r')
                    gameObject.transform.position = new Vector2(transform.position.x + 1, transform.position.y + (float)0.5);

                platformGenerator.createPlatform();
            }

            else
            {
                gameObject.SetActive(false);
                Debug.Log("You fell off!");
            }
        }

        if (Input.GetKeyDown("left ctrl"))
        {
            next = (char)platformGenerator.platformOrder.Dequeue();

            if (dir != next)
            {
                if (next == 'l')
                {
                    gameObject.transform.position = new Vector2(transform.position.x - 1, transform.position.y + (float)0.5);
                    gameObject.transform.Rotate(Vector3.forward * 180);
                    dir = 'l';
                }

                else if (next == 'r')
                {
                    gameObject.transform.position = new Vector2(transform.position.x + 1, transform.position.y + (float)0.5);
                    gameObject.transform.Rotate(Vector3.forward * -180);
                    dir = 'r';
                }

                platformGenerator.createPlatform();
            }

            else
            {
                gameObject.SetActive(false);
                Debug.Log("You fell off!");
            }
            /*if (array[i] != array[i + 1])
            {
                if (array[i + 1] == 'l')
                {
                    gameObject.transform.position = new Vector2(transform.position.x - 1, transform.position.y + (float)0.5);
                    gameObject.transform.Rotate(Vector3.forward * 180);
                }

                else if (array[i + 1] == 'r')
                {
                    gameObject.transform.position = new Vector2(transform.position.x + 1, transform.position.y + (float)0.5);
                    gameObject.transform.Rotate(Vector3.forward * -180);
                }

                i++;
            }

            else
            {
                i = 0;
                gameObject.transform.position = new Vector2(0, -4.6f);
            }*/
        }
    }
}
