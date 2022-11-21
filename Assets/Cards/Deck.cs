using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public string deckType;
    public GameObject uiparent1;
    public GameObject uiparent2;
    public GameObject cardPrefab;
    public GameObject[] temp;
    public GameObject[] deck;
    public int deckSize;
    public int position;
    public int maxValue;
    public int maxSuits;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i <= 10; i++)
        {
            int x = 2 * i;
            if(!Resources.Load<Texture2D>(deckType + x.ToString()))
            { 
                maxSuits = i - 1;
                break;
            }
        }
        
        //there should be only 1 of each value for each suit

        deckSize = maxValue * maxSuits;

        //this deck will be used for shuffling and then used for storage for the player

        temp = new GameObject[deckSize + 1];
        temp[0] = Instantiate(cardPrefab, new Vector3(95, 265, 0), Quaternion.identity);
        temp[0].transform.SetParent(uiparent1.transform, true);

        //this is the deck that will be played with

        deck = new GameObject[deckSize];
        for(int i = 0; i < deckSize; i++)
        //filling the whole deck
        {
            for(int j = 2; j < maxValue + 2; j++)
            //1 of each value, starting at 2 because aces are considered high and maxValue +2 to remove 0 and add aces to the end
            {
                for (int z = 1; z <= maxSuits; z++)
                //1 of each suit
                {
                    //create a new instance of the card prefab

                    deck[i] = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity);

                    //set the new instance as a child of the UI container for cards

                    deck[i].transform.SetParent(uiparent1.transform);

                    //set the suit and value of the cards

                    deck[i].GetComponent<Card>().CardDraw(j, z);

                    //set the suit art to the card aswell as the back of the card. card front art is stored as even integers, while the back is stored as odd integers
                    int x = 2 * z;
                    deck[i].GetComponent<Card>().suitDisplay.sprite = Resources.Load<Sprite>(deckType + x.ToString());
                    x--;
                    deck[i].GetComponent<Card>().cardBack.sprite = Resources.Load<Sprite>(deckType + x.ToString());
                    //deck[i].GetComponent<Card>().Print();
                    i++;
                }
            }
        }

        //this shuffles every position once, individual cards may be moved more than once

        for (int i = 0; i < deckSize; i++)
        {
            // Random for remaining positions.
            int r = i + Random.Range(0, deckSize - i);

            //swapping the location of the cards within the deck
            temp[0].transform.SetSiblingIndex(deck[r].transform.GetSiblingIndex());
            deck[r].transform.SetSiblingIndex(deck[i].transform.GetSiblingIndex());
            deck[i].transform.SetSiblingIndex(temp[0].transform.GetSiblingIndex());
        }
        temp[0].transform.SetParent(uiparent2.transform, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //removes a card from the play deck and places it in the temp deck. places on top of the temp deck
    void Pull()
    {

    }
    //removes a card from the temp deck and places it in the play deck. always pulls from the top of temp deck and places under the current card in the child index
    void place()
    {

    }
}
