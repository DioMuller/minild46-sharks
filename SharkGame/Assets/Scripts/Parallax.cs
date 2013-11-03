using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour 
{
    public float width;
    public float speed = 10f;
    public bool isMain = false;

    private float trueWidth;

    void Start()
    {
        trueWidth = width - (Screen.width/2);
    }

	// Update is called once per frame
	void Update () 
    {
        transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime),
                                         transform.position.y,
                                         transform.position.z);

        if (transform.position.x < -trueWidth)
        {
            transform.position = new Vector3(trueWidth + (Screen.width),
                                         transform.position.y,
                                         transform.position.z);
        }	
	}
}
