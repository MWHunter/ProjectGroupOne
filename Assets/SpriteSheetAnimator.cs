using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;


public class SpriteSheetAnimator : MonoBehaviour
{
    public Sprite[] headSprite1;
    public Sprite[] headSprite2;

    public Sprite[] chestSprite1;
    public Sprite[] chestSprite2;

    public Sprite[] legSprite1;
    public Sprite[] legSprite2;

    public Sprite[] skinSprite;

    public int headIndex = 0;
    public int chestIndex = 0;
    public int legIndex = 0;
    int animationIndex = 0;

    public float timeInterval = 0.3f;
    private float timer = 0f;

    private Sprite[] headSprite;
    private Sprite[] chestSprite;
    private Sprite[] legSprite;

    void Start()
    {
        headSprite = Random.Range(0, 2) == 1 ? headSprite1 : headSprite2;
        chestSprite = Random.Range(0, 2) == 1 ? chestSprite1 : chestSprite2;
        legSprite = Random.Range(0, 2) == 1 ? legSprite1 : legSprite2;
        setSprites();
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= timeInterval)
        {
            timer = 0f;
            animationIndex++;
            animationIndex = animationIndex % 4;
        }
        setSprites();
    }

    void setSprites() {

        GameObject child = transform.GetChild(0).gameObject; // head
        SpriteRenderer renderer = child.GetComponent<SpriteRenderer>();
        renderer.sprite = headSprite[animationIndex];

        child = transform.GetChild(1).gameObject; // chest
        renderer = child.GetComponent<SpriteRenderer>();
        renderer.sprite = chestSprite[animationIndex];

        child = transform.GetChild(2).gameObject; // leg
        renderer = child.GetComponent<SpriteRenderer>();
        renderer.sprite = legSprite[animationIndex];

        child = transform.GetChild(3).gameObject; // Skin
        renderer = child.GetComponent<SpriteRenderer>();
        renderer.sprite = skinSprite[animationIndex];
    }

    public void SetFlipX(bool flipX) {
        for (int i = 0; i < 4; i++) {
            transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().flipX = flipX;
        }
    }
}