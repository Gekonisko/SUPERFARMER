using TMPro;
using UnityEngine;
using Zenject;

namespace Players
{

    public class AnimalView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Animal _type;
        [SerializeField] private int _playerId;

        [Inject]
        private GameService _gameService;

        private void Awake()
        {
            _gameService.PlayerFarmUpdate += OnPlayerFarmUpdate;
        }

        private void Start()
        {
            text = GetComponentInChildren<TextMeshProUGUI>();

            var player = _gameService.GetPlayer(_playerId);
            text.text = player.animals[_type].ToString();
        }

        private void OnPlayerFarmUpdate(int playerId, Animal type)
        {
            if (playerId == _playerId && type == _type)
            {
                var player = _gameService.GetPlayer(_playerId);
                text.text = player.animals[_type].ToString();
            }
        }

        private void OnDestroy()
        {
            _gameService.PlayerFarmUpdate -= OnPlayerFarmUpdate;
        }
    }
}