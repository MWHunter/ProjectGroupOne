using UnityEngine;
using UnityEngine.UI;

public class ChangeImageOnClick : MonoBehaviour
{
    public Sprite[] images; // an array of images you want to cycle through
    public Image image; // reference to the Image component of your game object

    private int currentImageIndex = 0; // keep track of which image to show next

    public void ChangeImage()
    {
        currentImageIndex = (currentImageIndex + 1) % images.Length; // cycle through images using modulo operator
        image.sprite = images[currentImageIndex]; // update the sprite of the Image component
    }
}
