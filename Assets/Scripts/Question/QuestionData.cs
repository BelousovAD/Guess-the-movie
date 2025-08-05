namespace Question
{
    using Answer;
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(QuestionData), menuName = nameof(Question) + "/" + nameof(QuestionData))]
    public class QuestionData : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private AnswerData _rightAnswer;

        public Sprite Icon =>
            _icon;

        public AnswerData RightAnswer =>
            _rightAnswer;
    }
}
