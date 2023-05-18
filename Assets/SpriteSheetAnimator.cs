using System.Collections;
using UnityEngine;
using UnityEditor;


public class SpriteSheetAnimator : MonoBehaviour
{
    public GameManager gameManager;

    public Sprite[] headSprite1;
    public Sprite[] headSprite1Walk;
    public Sprite[] headSprite2;
    public Sprite[] headSprite2Walk;

    public Sprite[] chestSprite1;
    public Sprite[] chestSprite1Walk;
    public Sprite[] chestSprite2;
    public Sprite[] chestSprite2Walk;

    public Sprite[] legSprite1;
    public Sprite[] legSprite1Walk;
    public Sprite[] legSprite2;
    public Sprite[] legSprite2Walk;

    public Sprite[] skinSprite;
    public Sprite[] skinSpriteWalk;

    int animationIndex = 0;

    public float timeInterval = 0.3f;
    private float timer = 0f;

    bool isWalk;

    void Start()
    {
        if (GameManager.Instance.headSprite.Length == 0) {
            GameManager.Instance.headSprite = headSprite1;
            GameManager.Instance.chestSprite = chestSprite1;
            GameManager.Instance.legSprite = legSprite1;
        }

        setSprites();
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= timeInterval)
        {
            timer = 0f;
            animationIndex++;
        }
        setSprites();
    }

    void setSprites() {
        // blame hunter for this code :) it's terrible but gets the job done.
        Sprite[] thiscode = GameManager.Instance.headSprite;
        Sprite[] sucks = GameManager.Instance.chestSprite;
        Sprite[] imsorryforwhat = GameManager.Instance.legSprite;
        Sprite[] ivedone = skinSprite;

        if (thiscode == headSprite1 && isWalk) {
            thiscode = headSprite1Walk;
        }
        if (thiscode == headSprite2 && isWalk) {
            thiscode = headSprite2Walk;
        }
        if (sucks == chestSprite1 && isWalk) {
            sucks = chestSprite1Walk;
        }
        if (sucks == chestSprite2 && isWalk) {
            sucks = chestSprite2Walk;
        }
        if (imsorryforwhat == legSprite1 && isWalk) {
            imsorryforwhat = legSprite1Walk;
        }
        if (imsorryforwhat == legSprite2 && isWalk) {
            imsorryforwhat = legSprite2Walk;
        }
        if (ivedone == skinSprite && isWalk) {
            ivedone = skinSpriteWalk;
        }

        // idle and walking have different length... this will make walk slightly favor 0-3 frames but who cares...
        int trueIndex = animationIndex;
        if (!isWalk) {
            trueIndex /= 3;
        }
        trueIndex = trueIndex % thiscode.Length;


        GameObject child = transform.GetChild(0).gameObject; // head
        SpriteRenderer renderer = child.GetComponent<SpriteRenderer>();
        renderer.sprite = thiscode[trueIndex];

        child = transform.GetChild(1).gameObject; // chest
        renderer = child.GetComponent<SpriteRenderer>();
        renderer.sprite = sucks[trueIndex];

        child = transform.GetChild(2).gameObject; // leg
        renderer = child.GetComponent<SpriteRenderer>();
        renderer.sprite = imsorryforwhat[trueIndex];

        child = transform.GetChild(3).gameObject; // Skin
        renderer = child.GetComponent<SpriteRenderer>();
        renderer.sprite = ivedone[trueIndex];
    }

    public void setWalk(bool isWalk) {
        this.isWalk = isWalk;
    }

    public void SetFlipX(bool flipX) {
        for (int i = 0; i < 4; i++) {
            transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().flipX = flipX;
        }
    }
}