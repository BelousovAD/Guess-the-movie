namespace Loading
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SceneLoaderAfterDataLoaded : MonoBehaviour
    {
        [SerializeField] private DataLoader _dataLoader;
        [SerializeField] private string _sceneName;
        [SerializeField] private float _delayInSeconds;

        private void OnEnable()
        {
            _dataLoader.ProgressUpdated += CheckProgress;
            CheckProgress();
        }

        private void OnDisable() =>
            _dataLoader.ProgressUpdated -= CheckProgress;

        private void CheckProgress()
        {
            if (Mathf.Approximately(_dataLoader.Progress, DataLoader.MaxProgress))
            {
                StartCoroutine(LoadSceneAfterDelay());
            }
        }

        private IEnumerator LoadSceneAfterDelay()
        {
            yield return new WaitForSecondsRealtime(_delayInSeconds);
            SceneManager.LoadScene(_sceneName);
        }
    }
}