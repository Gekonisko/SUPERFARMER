using System.Linq;
using TMPro;
using UnityEngine;

public class PlayersView : MonoBehaviour
{
    [SerializeField] private GameObject[] players;


    private void Awake()
    {
        AddPlayer.Click += OnAddPlayer;
        DeletePlayer.Click += OnDeletePlayer;
        PlayButton.Click += OnPlayButton;
    }

    private void OnPlayButton()
    {
        for (int i = 0; i < GameManager.Instance.playersNumber; i++)
        {
            var name = players[i].GetComponentInChildren<TextMeshProUGUI>().text;
            GameManager.Instance.AddPlayer(name);
        }
    }

    private void OnAddPlayer()
    {
        if (GameManager.Instance.playersNumber < GameManager.MAX_Players)
        {
            GameManager.Instance.playersNumber += 1;
            foreach (var player in players)
            {
                if (player.activeInHierarchy == false)
                {
                    player.SetActive(true);
                    break;
                }
            }
        }
    }

    private void OnDeletePlayer()
    {
        if (GameManager.Instance.playersNumber > GameManager.MIN_Players)
        {
            GameManager.Instance.playersNumber -= 1;
            foreach (var player in players.Reverse())
            {
                if (player.activeInHierarchy == true)
                {
                    player.SetActive(false);
                    break;
                }
            }
        }
    }

    private void OnDestroy()
    {
        AddPlayer.Click -= OnAddPlayer;
        DeletePlayer.Click -= OnDeletePlayer;
        PlayButton.Click -= OnPlayButton;
    }
}
