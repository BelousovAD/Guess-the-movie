namespace Question
{
    using Answer;
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(QuestionData), menuName = nameof(Question) + "/" + nameof(QuestionData))]
    public class QuestionData : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private AnswerData _rightAnswer;

        public Sprite Sprite =>
            _sprite;

        public AnswerData RightAnswer =>
            _rightAnswer;
    }
}
