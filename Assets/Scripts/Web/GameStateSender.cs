namespace Web
{
    using Savvy.Infrastructure;
    using Savvy.Services.WebGL;
    using UnityEngine;

    public class GameStateSender : MonoSavvy
    {
        [SerializeField] private GameState _state;
        [SerializeField] private bool _sendOnEnable;
        [SerializeField] private bool _sendOnDisable;
        
        private IWebGLService _web;

        private IWebGLService Web => _web ??= GetService<IWebGLService>();

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
                    Web.GameIsReady();
                    break;
                case GameState.Start:
                    Web.GameplayStart();
                    break;
                case GameState.Stop:
                    Web.GameplayStop();
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