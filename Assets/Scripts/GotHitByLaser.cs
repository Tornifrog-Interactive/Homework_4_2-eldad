using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GotHitByLaser : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    public Text lifeText;
    private string tagOfThisObject;
    public int livesCount = 3;
    private int lives;
    void Start()
    {
        // Get the tag of the object this script is attached to and store it in tagOfThisObject
        tagOfThisObject = gameObject.tag;
        lives = livesCount;
        lifeText.text = tagOfThisObject + ": " + lives + " lives left";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Contains(triggeringTag) && !other.tag.Contains(tagOfThisObject) && enabled)
        {
            if (--lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log($"Game over! - {tagOfThisObject} lost!");
                Application.Quit();
            }
            Destroy(other.gameObject);
            lifeText.text = tagOfThisObject + ": " + lives + " lives left";
        }
    }
}
