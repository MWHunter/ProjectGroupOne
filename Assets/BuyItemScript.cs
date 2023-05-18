using UnityEngine;
using UnityEngine.UI;

public class BuyItemScript : MonoBehaviour
{
    public int itemCost;
    public int buttonId;

    public GameObject player;
    private Button myButton;

    public SpriteSheetAnimator spriteSheetAnimator;

    private void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(HandleButtonClick);

        spriteSheetAnimator = player.GetComponent<SpriteSheetAnimator>();
    }

    private void HandleButtonClick()
    {
        if (GameManager.Instance.balance >= itemCost)
        {
            GameManager.Instance.DeductBalance(itemCost);

            // Hunter wrote this, it's terrible code and you should never write code like this.
            // it's just faster to do it wrong and it shouldn't matter since it's a school project
            if (buttonId == 1)
            {
                // Button for upgraded hat that gives 25% at a bonus $50 per question
                GameManager.Instance.headSprite = spriteSheetAnimator.headSprite2;
                GameManager.Instance.bonusChance = 0.25;
            }
            else if (buttonId == 2)
            {
                // A shirt to add an extra $50 per question
                GameManager.Instance.chestSprite = spriteSheetAnimator.chestSprite2;
                GameManager.Instance.bonusConstant = 50;
            }
            else if (buttonId == 3) {
                // Pants to double the extra money for each question
                GameManager.Instance.legSprite = spriteSheetAnimator.legSprite2;
                GameManager.Instance.bonusMultiplier = 2;
            }
        }
    }
}
