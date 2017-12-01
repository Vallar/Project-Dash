using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance = null;

    [SerializeField] private GameObject[] hearts;
    [SerializeField] private GameObject storyPanel;
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private TextMeshProUGUI wavesText;
    [SerializeField] private TextMeshProUGUI hopeText;
    private int storyCounter = 0;
    private PlayerStats stats;

    private void Awake()
    {
        instance = this;

        stats = GameManager.instance.player.GetComponent<PlayerStats>();
    }

    public void UpdateHealth()
    {
        hearts[stats.currentHealth].SetActive(false);
    }

    public void UpdateWave()
    {
        wavesText.text = GameManager.instance.wave.ToString();
    }

    public void UpdateHope()
    {
        hopeText.text = GameManager.instance.hope.ToString();
    }


    public void ShowStory()
    {
        switch (storyCounter)
        {
            case 0:
                storyText.text = "As all stories, this one started at the beginning; there was a dream; with it hope was born.";
                break;
            case 1:
                storyText.text = "Then you discover the long path as you guard that precious little hope. On to the first pedestal you jump!";
                break;
            case 2:
                storyText.text = "They weren't there before, but things come to existence, they feel rather... uncomfortable. A necessary evil, perhaps? Perhaps not?";
                break;
            case 3:
                storyText.text = "Some seem to persistently try to stop you to the point that your entire world suddenly revolves around them! Indeed, probably an evil that you must defeat";
                break;
            case 4:
                storyText.text = "But you slowly realize it isn't always the case. After all you become stronger as you pass through these... things. You find yourself calling them obstacles.";
                break;
            case 5:
                storyText.text = "Turns, tides and what not. Your hope shines, glimmers before you, you feel it is quite reachable. But so is the long over stretched path to it.";
                break;
            case 6:
                storyText.text = "The dream flickers as the montonous days slog by and while you used to jump to a few pedestals a day, now not so much. Will your energy waver?";
                break;
            case 7:
                storyText.text = "A true test arrises, it is to face the monsterous shadow of procrastination. You say defeat it and you prevail.";
                break;
            case 8:
                storyText.text = "Indeed you prevail, but you realize, it isn't the big obstacles that are dangerous, but those pesky little ones!";
                break;
            case 9:
                storyText.text = "Abstractly you turn inwards -- to yourself. This hope... while it attracted the obstacles, it also seems to imbue with this elusive power, perhaps it has a use afterall?";
                break;
            case 10:
                storyText.text = "Better late than never, you realize that hope is your powers' fuel and with that, hope is renewed. You can do this!";
                break;
            case 11:
                storyText.text = "Unfortunately obstacles have caught wind of your new found ability and are devicing their own plot. You wonder if it is something you can overcome!";
                break;
        }

        storyPanel.SetActive(true);
        storyCounter += 1;
    }
    
    public void HideStory()
    {
        storyPanel.SetActive(false);
    }

}
