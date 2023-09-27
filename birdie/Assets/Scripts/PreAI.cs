using UnityEngine;
public class PreAI : MonoBehaviour
{
    [SerializeField] private Vector3 _randomPos;
    [SerializeField] private Vector3 _minPos;
    [SerializeField] private Vector3 _maxPos;
    [SerializeField] private GameObject ps;
    private Score _score;

    private void Start()
    {
        _score = GameObject.FindObjectOfType<Score>();
        _randomPos = new Vector3(Random.Range(_minPos.x, _maxPos.x), Random.Range(_minPos.y, _maxPos.y), Random.Range(_minPos.z, _maxPos.z));
    }

    private void Update()
    {
        if (Vector3.Distance(_randomPos, transform.position) <= 0.2f)
        {
            _randomPos = new Vector3(Random.Range(_minPos.x, _maxPos.x), Random.Range(_minPos.y, _maxPos.y), Random.Range(_minPos.z, _maxPos.z));
        }

        transform.LookAt(_randomPos);
        transform.position += transform.forward * Time.deltaTime * 2;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null) 
        {
            Instantiate(ps, transform.position, Quaternion.identity);
            _randomPos = new Vector3(Random.Range(_minPos.x, _maxPos.x), Random.Range(_minPos.y, _maxPos.y), Random.Range(_minPos.z, _maxPos.z));
            transform.position = _randomPos;
            _score.score++;
            _score.text.text= _score.score.ToString();
        }
    }
}