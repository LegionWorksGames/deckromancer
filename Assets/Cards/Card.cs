using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    weapon,
    healing,
    buffs,
    general
}

[CreateAssetMenu (menuName = "Card")]
public class Card : ScriptableObject {
    [HideInInspector]
    public delegate void Action();

    [SerializeField] string cardName;
    [SerializeField][TextArea] string description;
    [SerializeField] CardType type = CardType.general;
    [SerializeField] Sprite image;
    [SerializeField] int cost = 1;
    [SerializeField] Action action;
    [SerializeField] bool recycle = true;

    public string GetCardName() { return cardName; }
    public string GetDescription() { return description; }
    public CardType GetCardType() { return type; }
    public Sprite GetImage() { return image; }
    public int GetCost() { return cost; }
    public void CallAction() {
        if(action != null){
            action();
        }
    }
    public bool IsRecyclable() { return recycle; }
}