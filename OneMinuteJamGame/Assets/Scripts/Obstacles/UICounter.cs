using UnityEngine;

public class UICounter : MonoBehaviour
{
    public TMPro.TMP_Text text;

    public void ReDrawText(string text)
    {
        this.text.text = text;
    }
}
