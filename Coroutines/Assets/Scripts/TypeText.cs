/* @author Ralph Burton */
using UnityEngine;
using System.Collections;
using TMPro;

public class TypeText : MonoBehaviour
{
    public float waitDuration;
    TextMeshProUGUI text;
    string story;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        story = text.text;
        text.text = "";
    }

    public IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            text.text += c;
            yield return new WaitForSeconds(waitDuration);
        }
    }
}
