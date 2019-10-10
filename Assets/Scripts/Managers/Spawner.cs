using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    [SerializeField]
    private Renderer _platform;
    [SerializeField]
    private int _maxAmountOfVisiblePlatforms;
    [SerializeField]
    private Transform _platformHolder;
    [SerializeField]
    private Transform _dropableHolder;

    private float _platformLength, _platformHeight;
    private float _spawnZ;
    private int _amountOfVisiblePlatforms;
    private int[] lanes = { -3,0,3};

    // Start is called before the first frame update
    void Start()
    {
        _platformLength = _platform.bounds.size.z;
        _platformHeight = _platform.bounds.size.y;
        _spawnZ = 0;
        
        while (_amountOfVisiblePlatforms < _maxAmountOfVisiblePlatforms)
            SpawnPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        while (_amountOfVisiblePlatforms < _maxAmountOfVisiblePlatforms)
        {
            GameObject g = SpawnPlatform();
            populatePlatform(g.transform);
        }
    }

    void populatePlatform(Transform t)
    {
        foreach(int lane in lanes)
        {
            if(Random.Range(0,100) < 25)
            {
                GameObject g = getRandomDroppable();
                Vector3 pos = t.position;
                pos.x = lane;
                pos.y = g.GetComponent<Collider>().bounds.size.y / 2;
                //pos.y = _platformHeight/2 + g.GetComponent<Renderer>().bounds.size.y/2;
                pos.y = _platformHeight / 2 + g.GetComponent<Collider>().bounds.size.y / 2;
                g.transform.position = pos;
            }
        }
    }

    public GameObject getRandomDroppable()
    {
        float r = Random.Range(0, 100);
        GameObject g;
        if (r < 25)
        {
            g = BlueSpherePool.Instance.GetObject().gameObject;
        }
        else if (r < 50)
        {
            g = BombPool.Instance.GetObject().gameObject;
        }
        else if (r < 75)
        {
            g = CoinPool.Instance.GetObject().gameObject;
        }
        else
        {
            g = IronBallPool.Instance.GetObject().gameObject;
        }
        g.SetActive(true);
        g.transform.SetParent(_dropableHolder);
        return g;
    }

    public void OnPlatformDestroyed()
    {
        _amountOfVisiblePlatforms--;
    }

    public GameObject SpawnPlatform()
    {
        GameObject g = PlatformPool.Instance.GetObject().gameObject;
        g.SetActive(true);
        g.transform.position = Vector3.forward * _spawnZ;
        g.transform.SetParent(_platformHolder);
        _spawnZ += _platformLength;
        _amountOfVisiblePlatforms++;
        return g;
    }
}
