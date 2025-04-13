using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialougeManager : MonoBehaviour
{
    public TMP_Text _tmpProText;
    public string target;
    Image Speakersprite;
    string dialouge;
    string speaker;
    public float delay = 0f;
    public float timeBetween = 0.1f;

    // Use this for initialization
    void Start()
    {

    }

    private void Update()
    {
        _tmpProText.text = speaker + ": " + target;
    }

    [ContextMenu("CallDialgue")]
    public void Dialouge(string speak, Image sprite, string name)
    {
        dialouge = speak;
        speaker = name;
        Speakersprite = sprite;
        if (_tmpProText != null)
        {
            StartCoroutine("TypeWriterTMP");
        }
    }

    IEnumerator TypeWriterTMP()
    {
        yield return new WaitForSeconds(delay);

        foreach (char c in dialouge)
        {
            if (target.Length > 0)
            {
                target = target.Substring(0, target.Length);
            }
            target += c;
            yield return new WaitForSeconds(timeBetween);
        }
    }
}