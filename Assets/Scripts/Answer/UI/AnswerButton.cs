namespace Answer.UI
{
    using BelousovGameDev.UI.Button;
    using UnityEngine;

    public class AnswerButton : AbstractButton
    {
        [SerializeField] private Answer _answer;
        
        public override void HandleClick() =>
            _answer.Choose();
    }
}
