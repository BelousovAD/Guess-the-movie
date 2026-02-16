namespace Loading
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Answer;
    using JetBrains.Annotations;
    using Question;
    using Reflex.Attributes;
    using Topic;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.ResourceManagement.AsyncOperations;

    public class DataLoader : MonoBehaviour
    {
        public const float MinProgress = 0f;
        public const float MaxProgress = 1f;
        
        [SerializeField] private List<KeyValuePair<TopicType, AssetReference>> _answerLists;
        [SerializeField] private List<KeyValuePair<TopicType, AssetReference>> _questionLists;

        private Dictionary<TopicType, AssetReference> _answerListReferences;
        private Dictionary<TopicType, AssetReference> _questionListReferences;
        private AsyncOperationHandle<AnswerDataListData> _answerListDataLoader;
        private AsyncOperationHandle<QuestionDataListData> _questionListDataLoader;
        private AnswerDataList _answerDataList;
        private QuestionDataList _questionDataList;
        private Topic _topic;
        private float _progress;

        public event Action ProgressUpdated;

        public float Progress
        {
            get
            {
                return _progress;
            }

            set
            {
                if (Mathf.Approximately(Mathf.Clamp(value, MinProgress, MaxProgress), _progress) == false)
                {
                    _progress = value;
                    ProgressUpdated?.Invoke();
                }
            }
        }
        
        [Inject]
        private void Initialize(AnswerDataList answerDataList, QuestionDataList questionDataList, Topic topic)
        {
            _answerDataList = answerDataList;
            _questionDataList = questionDataList;
            _topic = topic;
        }

        private void Start()
        {
            InitializeDictionary(out _answerListReferences, _answerLists);
            InitializeDictionary(out _questionListReferences, _questionLists);
            StartCoroutine(LoadData());
        }

        private static void InitializeDictionary(out Dictionary<TopicType, AssetReference> dictionary,
            List<KeyValuePair<TopicType, AssetReference>> pairList) =>
            dictionary = pairList.ToDictionary(pair => pair.Key, pair => pair.Value);

        private IEnumerator LoadData()
        {
            RefreshLoader(ref _answerListDataLoader, _answerListReferences);
            RefreshLoader(ref _questionListDataLoader, _questionListReferences);

            while ((_answerListDataLoader.IsDone && _questionListDataLoader.IsDone) == false)
            {
                Progress = (_answerListDataLoader.PercentComplete + _questionListDataLoader.PercentComplete) / 2;
                yield return null;
            }

            _answerDataList.SetData(_answerListDataLoader.Result);
            _questionDataList.SetData(_questionListDataLoader.Result);
            Progress = MaxProgress;
        }

        private void RefreshLoader<T>(ref AsyncOperationHandle<T> loader,
            Dictionary<TopicType, AssetReference> dictionary)
        {
            if (loader.IsValid())
            {
                Addressables.Release(loader);
            }
            
            loader = dictionary[_topic.Current].LoadAssetAsync<T>();
        }
        
        [Serializable]
        private class KeyValuePair<T, K>
        {
            public T Key;
            public K Value;
        }
    }
}
