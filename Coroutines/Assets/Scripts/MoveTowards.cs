/* @author Ralph Burton */
using System.Collections;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public Transform goal;
    public float speed;
    bool resettingChar;

    // Variable so that the input for movement is only taken once, 
    // instead of the amount of frames that the button was held down.
    bool isMoving;
    public bool IsMoving{ get{return isMoving;} }

    // For resetting character position.
    Vector2 startPosition;
    
    void Start()
    {
        startPosition = transform.position;
    }

    public void ResetCharacter()
    {
        resettingChar = true;
        transform.position = startPosition;
    }

    public IEnumerator MoveCharacter()
    {
        resettingChar = false;
        isMoving = true;

        // Keep repeating until the player is close enough to the goal.
        // Also, break out of the loop if the player chose to reset the characters position.
        while(Vector2.Distance(transform.position, goal.transform.position) > 0.001f && !resettingChar)
        {
            transform.position = Vector2.Lerp(transform.position, goal.position, speed * Time.deltaTime);
            yield return null;
        }
        
        if(Vector2.Distance(transform.position, goal.transform.position) > 0.001f) 
        {
            isMoving = false;
            yield break;
        }

        // Moving the character along for correctness as long 
        // as the character is close enough before resetting.
        transform.position = goal.position;
        Debug.Log("Waiting");
        yield return new WaitForSeconds(3f);
        Debug.Log("Waited");
    }
}
