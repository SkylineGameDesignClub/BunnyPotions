using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialougeManager : MonoBehaviour
{
    public TMP_Text _tmpProText;
    public string target;
    [SerializeField] Image Speakersprite;
    string dialouge;
    string speaker;
    public float delay = 0f;
    public float timeBetween = 0.1f;

    [SerializeField]
    [Range(0f, 10f)]
    float canvasSpriteRatio = 4;

    public bool dialogueInProgress = false;

    // Use this for initialization
    void Start()
    {
        DisableChildren();
    }

    private void Update()
    {
        _tmpProText.text = speaker + ": " + target;
    }

    public void DisableChildren()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++) 
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        
    }
    public void EnableChildren()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void Dialouge(string speak, Sprite sprite, string name)
    {
        dialouge = speak;
        speaker = name;
        Vector2 canvasSize = gameObject.GetComponent<RectTransform>().parent.GetComponent<RectTransform>().sizeDelta;
        Vector2 spriteSize = new Vector2(0,0);
        spriteSize.x = canvasSize.x / canvasSpriteRatio;
        spriteSize.y = (spriteSize.x/sprite.texture.width)* sprite.texture.height;
        Speakersprite.gameObject.GetComponent<RectTransform>().sizeDelta = spriteSize;
        Speakersprite.sprite = sprite;
        if (_tmpProText != null)
        {
            StartCoroutine("TypeWriterTMP");
        }
    }

    IEnumerator TypeWriterTMP()
    {
        target = "";
        dialogueInProgress = true;
        yield return new WaitForSeconds(delay);

        foreach (char c in dialouge)
        {
            target += c;
            yield return new WaitForSeconds(timeBetween);
        }
        dialogueInProgress = false;
    }
}