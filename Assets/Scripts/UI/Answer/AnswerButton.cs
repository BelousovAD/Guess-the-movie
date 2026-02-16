namespace UI.Answer
{
    using BelousovGameDev.UI.Button;
    using global::Answer;
    using UnityEngine;

    public class AnswerButton : AbstractButton
    {
        [SerializeField] private Answer _answer;
        
        public override void HandleClick() =>
            _answer.Choose();
    }
}
