using UnityEngine;
using System.Collections;

public class SharkBehavior : MonoBehaviour
{
    #region Inspector Variables
    /// <summary>
    /// Blood particle.
    /// </summary>
    public Transform bloodParticle;

    public string nextLevel;
    #endregion Inspector Variables

    #region Private Attributes
    /// <summary>
    /// Has the coroutine started?
    /// </summary>
    private bool coroutineStarted = false;
    #endregion Private Attributes

    /// <summary>
    /// Called when the shark collides with other objects.
    /// </summary>
    /// <param name="other">Other Object.</param>
    void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Player" )
        {
            if( bloodParticle != null )
            {
                bloodParticle.GetComponent<ParticleSystem>().Play();
            }

            if( !coroutineStarted )
            {
                coroutineStarted = true;
                StartCoroutine(DestroyPlayer(other));
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (bloodParticle != null)
        {
            bloodParticle.GetComponent<ParticleSystem>().Stop();
        }
    }

    IEnumerator DestroyPlayer(Collider other)
    {
        yield return new WaitForSeconds(5f);
        Destroy(other.gameObject);
        Application.LoadLevel(nextLevel);
    }
}
