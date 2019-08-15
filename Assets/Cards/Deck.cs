using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {
    [SerializeField] List<Card> availiableCards = new List<Card> ();
    [SerializeField] CardBehavior cardBehavior;
    [SerializeField] GameObject handUI;
    List<Card> deck = new List<Card> ();
    List<CardBehavior> hand = new List<CardBehavior> ();
    Queue<Card> library = new Queue<Card> ();

    // Start is called before the first frame update
    void Start () {
        foreach (var item in availiableCards) {
            deck.Add (item);
        }
        ShuffleDeck();
        DrawHand();
    }

    void DrawHand() {
        while(hand.Count < 5 && library.Count > 0) {
            // Pull card from library
            Card c = library.Dequeue();
            // Spawn card for hand GUI
            var draw = Instantiate(cardBehavior, handUI.transform);
            // Setup that card
            draw.Initialize(c);
            // Add it to the List of hand
            hand.Add(draw);
        }
    }

    void ShuffleDeck () {
        List<Card> newDeck = deck;
        // TODO make better shuffle
        for (int i = 0; i < newDeck.Count; i++) {
            var temp = newDeck[i];
            int randomIndex = Random.Range (i, newDeck.Count);
            newDeck[i] = newDeck[randomIndex];
            newDeck[randomIndex] = temp;
        }
        foreach (var item in deck)
        {
            library.Enqueue(item);
        }
    }
}