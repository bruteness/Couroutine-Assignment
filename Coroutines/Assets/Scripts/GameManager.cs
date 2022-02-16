/* @author Ralph Burton */
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TypeText typeText;
    public MoveTowards moveTowards;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(typeText.PlayText());
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !moveTowards.IsMoving)
        {
            StartCoroutine(moveTowards.MoveCharacter());
        }
        else if(Input.GetKey(KeyCode.E))
        {
            moveTowards.ResetCharacter();
        }
    }
}
