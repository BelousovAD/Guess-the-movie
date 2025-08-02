namespace Question
{
    using System.Collections.Generic;

    public class QuestionDataList
    {
        private QuestionDataListData _data;

        public IEnumerable<QuestionData> QuestionDatas => _data?.QuestionDatas;

        public void SetData(QuestionDataListData data) =>
            _data = data;
    }
}