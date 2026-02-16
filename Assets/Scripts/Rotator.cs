using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 _rotatePerSecond;
    
    private void Update() =>
        transform.Rotate(_rotatePerSecond * Time.deltaTime);
}