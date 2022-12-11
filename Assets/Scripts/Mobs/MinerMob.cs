using UnityEngine;
public class MinerMob : Mob
{
    [SerializeField] private GameObject _cardPrefab;
    protected override void DropLoot()
    {
        Instantiate(_cardPrefab, transform.position + new Vector3(Random.Range(0, .5f), Random.Range(0, .5f)), Quaternion.identity);
    }
}
