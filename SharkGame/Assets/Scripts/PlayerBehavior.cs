using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour 
{
    private SwimingBehavior swimming;
    public KeyCode next;
    public float winPosition;

    private float buttonX;
    private float buttonY;

    public string nextLevel;

    public bool showGUI = true;

	// Use this for initialization
	void Start () 
    {
        next = NextKey();
        buttonX = Screen.width / 2 - 30;
        buttonY = Screen.height / 2 - 30;
	    swimming = transform.GetComponent<SwimingBehavior>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if( Input.GetKey(next) ) 
        {
            AddSpeed();
        }  

        if( transform.position.x > winPosition )
        {
            Application.LoadLevel(nextLevel);
        }
	}

    void OnGUI()
    {
        if( showGUI )
        {
            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            Rect position = new Rect(buttonX, buttonY, 30, 30);
            if( GUI.Button( position, ((char) next).ToString().ToUpper()) )
            {
                AddSpeed();
            }
        }
    }

    KeyCode NextKey()
    {
        return (KeyCode)(Random.Range(0, 26) + 'a');
    }

    void AddSpeed()
    {
        KeyCode temp = NextKey();

        swimming.speed += (1.5f * swimming.decay);

        if (swimming.speed > 25f) swimming.speed = 25f;

        while (temp == next) temp = NextKey();

        next = temp;
        buttonX = Random.Range(100, Screen.width - 100);
        buttonY = Random.Range(100, Screen.height - 100);
    }
}
