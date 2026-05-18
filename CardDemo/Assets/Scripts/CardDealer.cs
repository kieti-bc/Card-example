using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{

}
public class CardDealer : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> cardPlaces;
    public GameObject cardPrefab;
    private List<GameObject> activeCards;

    List<Card> playerHand;

    private IEnumerator DealCoroutine;

    void Start()
    {
        activeCards = new List<GameObject>();
        DealCoroutine = DealCards(5);

        BoxCollider test = cardPrefab.GetComponent<BoxCollider>();
        // Prefab GameObjects are in their initial
        // state until Instantiated and their scripts
        // are not executed when scene starts
        CardController c = cardPrefab.GetComponent<CardController>();
        if (c)
        {
            Debug.Log($"Prefab card value is {c.CardValue}");
        }
}

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject card in activeCards)
        {
            Debug.DrawLine(transform.position, card.transform.position, Color.red);
        }

    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(100, 100, 300, 1920));
        if (GUILayout.Button("Deal"))
        {
            StartDealing();
        }
        for (int i = 0; i < playerHand.Count; i++)
        {
            if (GUILayout.Button($"Card {i + 1}"))
            {
                GameObject card = GameObject.Find($"Place_{i + 1}");
				CardAdjuster c = card.GetComponentInChildren<CardAdjuster>();
				c.DoFlip();
			}    
        }
        GUILayout.EndArea();
    }

    void StartDealing()
    {
        StartCoroutine(DealCoroutine);
    }

    IEnumerator DealCards(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            activeCards.Add(Instantiate(cardPrefab, transform.position, Quaternion.identity));
            activeCards[i].GetComponent<CardController>().SetTarget(cardPlaces[i].transform);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
