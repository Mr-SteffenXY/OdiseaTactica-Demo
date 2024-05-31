using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the slots in the game, including initializing them with cards.
/// </summary>
public class SlotManager : MonoBehaviour
{
    public GameObject[] cardPrefabs;
    public Transform[] slots;
    private List<GameObject> cards;
    private int maxCards = 5;

    void Start()
    {
        cards = new List<GameObject>(cardPrefabs);
        StartCoroutine(InitializeSlotsWithCards());
    }

    IEnumerator InitializeSlotsWithCards()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (cards.Count > 0)
            {
                int randomIndex = Random.Range(0, cards.Count);
                AddCardToSlot(i, cards[randomIndex]);
                cards.RemoveAt(randomIndex);
                yield return null;
            }
        }
    }

    public void AddCardToSlot(int slotIndex, GameObject cardPrefab)
    {
        if (slotIndex < slots.Length && slots[slotIndex].childCount == 0)
        {
            Vector3 cardPosition = slots[slotIndex].position + new Vector3(0, 100, 0);
            GameObject newCard = Instantiate(cardPrefab, cardPosition, Quaternion.identity, slots[slotIndex]);
        }
    }

    public void FillSlotWithNewCard()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].childCount == 0)
            {
                if (cards.Count > 0)
                {
                    int randomIndex = Random.Range(0, cards.Count);
                    AddCardToSlot(i, cards[randomIndex]);
                    cards.RemoveAt(randomIndex);
                }
                break;
            }
        }
    }
}
