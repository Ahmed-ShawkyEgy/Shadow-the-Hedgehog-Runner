using UnityEngine;

public class PlatformManager : Singleton<PlatformManager>
{
    [SerializeField]
    private GameObject _platform;
    [SerializeField]
    private int _maxAmountOfVisiblePlatforms;
    [SerializeField]
    private Transform _platformHolder;

    private float _platformLength;
    private float _spawnZ;
    private int _amountOfVisiblePlatforms;

    // Start is called before the first frame update
    void Start()
    {
        _platformLength = _platform.GetComponent<Renderer>().bounds.size.z;
        _spawnZ = 0;
        while (_amountOfVisiblePlatforms < _maxAmountOfVisiblePlatforms)
            SpawnPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        while (_amountOfVisiblePlatforms < _maxAmountOfVisiblePlatforms)
            SpawnPlatform();
    }

    public void DestroyPlatform(GameObject platform)
    {
        Destroy(platform);
        _amountOfVisiblePlatforms--;
    }

    public GameObject SpawnPlatform()
    {
        GameObject g = Instantiate(_platform, Vector3.forward * _spawnZ, Quaternion.identity,_platformHolder);
        _spawnZ += _platformLength;
        _amountOfVisiblePlatforms++;
        return g;
    }
}
