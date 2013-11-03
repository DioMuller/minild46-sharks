using UnityEngine;
using System.Collections;

public class SwimingBehavior : MonoBehaviour 
{
    #region Inspector Variables
    /// <summary>
    /// Water particle effects.
    /// </summary>
    public Transform waterEffect;

    /// <summary>
    /// Current Speed
    /// </summary>
    public float speed;

    /// <summary>
    /// Current Position
    /// </summary>
    public float position;

    /// <summary>
    /// Speed decay.
    /// </summary>
    public float decay;
    #endregion Inspector Variables
    
    #region Game Cycle Methods
    /// <summary>
    /// Use this for initialization.
	/// </summary>
	void Start () 
    {
	    position = transform.position.x;
	}
	
	/// <summary>
    ///  Update is called once per frame.
	/// </summary>
	void Update () 
    {
	    if( speed > 0f ) 
        {
            speed -= (decay * Time.deltaTime);
            position += (speed * Time.deltaTime);
        }
        
        if( waterEffect != null )
        {
            waterEffect.GetComponent<ParticleSystem>().emissionRate = speed * 5f;
        }

        // TODO: Remove this from here.
        transform.position = new Vector3( position, transform.position.y, transform.position.z );

	}
    #endregion Game Cycle Methods
}
