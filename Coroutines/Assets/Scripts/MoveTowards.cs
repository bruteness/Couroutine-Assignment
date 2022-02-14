/* @author Ralph Burton */
using System.Collections;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public Transform goal;
    public float speed;
    public bool resettingChar;
    Vector2 startPosition;
    
    void Start()
    {
        startPosition = transform.position;
    }

    public void ResetCharacter()
    {
        transform.position = startPosition;
    }

    public IEnumerator MoveCharacter()
    {
        while(Vector2.Distance(transform.position, goal.transform.position) > 0.0001f && !resettingChar)
        {
            transform.position = Vector2.Lerp(transform.position, goal.position, (speed / 100) * Time.fixedDeltaTime);
            yield return null;
        }
        Debug.Log("Waiting");
        yield return new WaitForSeconds(3f);
        Debug.Log("Waited");
    }
}
