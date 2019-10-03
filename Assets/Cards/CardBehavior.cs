using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBehavior : MonoBehaviour
{
    Card card;
    Text[] texts;
    Image[] images;
    [SerializeField] Sprite[] foreground;
    [SerializeField] Sprite[] icons;

    // Start is called before the first frame update
    public void Initialize(Card card)
    {
        texts = GetComponentsInChildren<Text>();
        images = GetComponentsInChildren<Image>();
        this.card = card;
        switch (card.GetCardType())
        {
            case CardType.weapon:
                images[1].sprite = foreground[1];
                images[2].sprite = icons[1];
                break;
            case CardType.healing:
                images[1].sprite = foreground[2];
                images[2].sprite = icons[2];
                break;
            case CardType.buff:
                images[1].sprite = foreground[3];
                images[2].sprite = icons[3];
                break;
            default:
                images[1].sprite = foreground[0];
                images[2].sprite = icons[0];
                break;
        }
        images[0].sprite = card.GetImage();

        texts[0].text = card.GetCost().ToString();
        texts[1].text = card.GetCardName();
        texts[2].text = card.GetDescription();

        if(!card.IsRecyclable()){
            images[3].gameObject.SetActive(false);
        }
    }

    public Card GetCard(){ return card; }
}
