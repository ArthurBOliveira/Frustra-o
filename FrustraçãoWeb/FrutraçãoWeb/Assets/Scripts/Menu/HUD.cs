using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] HeartsSprites;

    public Image[] HeartUI;

    private Player player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (player.curHealth)
        {
            case 0 :
                HeartUI[0].sprite = HeartsSprites[1];
                HeartUI[1].sprite = HeartsSprites[1];
                HeartUI[2].sprite = HeartsSprites[1];
                break;

            case 1:
                HeartUI[0].sprite = HeartsSprites[0];
                HeartUI[1].sprite = HeartsSprites[1];
                HeartUI[2].sprite = HeartsSprites[1];
                break;

            case 2:
                HeartUI[0].sprite = HeartsSprites[0];
                HeartUI[1].sprite = HeartsSprites[0];
                HeartUI[2].sprite = HeartsSprites[1];
                break;

            case 3:
                HeartUI[0].sprite = HeartsSprites[0];
                HeartUI[1].sprite = HeartsSprites[0];
                HeartUI[2].sprite = HeartsSprites[0];
                break;
        }
    }
}
