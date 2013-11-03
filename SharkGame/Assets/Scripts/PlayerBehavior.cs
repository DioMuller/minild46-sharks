using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour 
{
    private SwimingBehavior swimming;
    public KeyCode next;

	// Use this for initialization
	void Start () 
    {
        next = NextKey();
	    swimming = transform.GetComponent<SwimingBehavior>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if( Input.GetKey(next) ) 
        {
            KeyCode temp = NextKey();

            swimming.speed += (1.5f * swimming.decay);

            if( swimming.speed > 25f ) swimming.speed = 25f;

            while( temp == next ) temp = NextKey();

            next = temp;
        }  
	}

    void OnGUI()
    {
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        Rect position = new Rect(Screen.width / 2 - 30, Screen.height/ 2 - 30, 30, 30);
        GUI.Box( position, "" );
        GUI.Label( position, ((char) next).ToString().ToUpper()); 
    }

    KeyCode NextKey()
    {
        return (KeyCode)(Random.Range(0, 26) + 'a');
    }
}
