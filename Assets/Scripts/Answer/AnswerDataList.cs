namespace Answer
{
    using System.Collections.Generic;

    public class AnswerDataList
    {
        private AnswerDataListData _data;

        public IEnumerable<AnswerData> AnswerDatas => _data?.AnswerDatas;

        public void SetData(AnswerDataListData data) =>
            _data = data;
    }
}