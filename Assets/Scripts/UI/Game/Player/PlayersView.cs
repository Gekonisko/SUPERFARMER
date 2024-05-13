using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;

namespace Players
{
    public class PlayersView : MonoBehaviour
    {
        [SerializeField] private GameObject[] players;

        [Inject]
        private GameService _gameService;

        private void Start()
        {
            var i = 0;
            var playersNumber = _gameService.GetPlayersCount();
            players.ToList().ForEach(p => players[i].SetActive(i++ < playersNumber));
        }
    }
}