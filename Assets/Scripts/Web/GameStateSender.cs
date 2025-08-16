namespace Web
{
    using Infrastructure;
    using Reflex.Attributes;
    using UnityEngine;

    public class GameStateSender : MonoBehaviour
    {
        [SerializeField] private GameState _state;
        [SerializeField] private bool _sendOnEnable;
        [SerializeField] private bool _sendOnDisable;

        private ServicesProvider _servicesProvider;

        [Inject]
        private void Initialize(ServicesProvider servicesProvider) =>
            _servicesProvider = servicesProvider;

        private void OnEnable()
        {
            if (_sendOnEnable)
            {
                SendState();
            }
        }
        
        private void OnDisable()
        {
            if (_sendOnDisable)
            {
                SendState();
            }
        }

        public void SendState()
        {
            switch (_state)
            {
                case GameState.Ready:
                    _servicesProvider.Web.GameIsReady();
                    break;
                case GameState.Start:
                    _servicesProvider.Web.GameplayStart();
                    break;
                case GameState.Stop:
                    _servicesProvider.Web.GameplayStop();
                    break;
            }
        }

        private enum GameState
        {
            Ready = 0,
            Start,
            Stop
        }
    }
}