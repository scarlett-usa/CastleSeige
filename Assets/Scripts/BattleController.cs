using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public int BOARD_X = 3;
    public int BOARD_Y = 6;
    public GameObject SpawnPrefab;


    #region Private Properties
    private const float _SPACER = 0.5f;
    private const float _MOVESPEED = 1f;
    private List<GameObject> _Anchors { get; set; }
    private GameObject SelectedTile {get; set;}
    private bool searching;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _CreateAnchors();//Create Anchors
    }

    // Update is called once per frame
    void Update()
    {


    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && !searching)
        {
            searching = true;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.transform.tag == "Anchor"){
                    if(SelectedTile != null) _MoveTile(_GetClosestTile(hit.transform));
                }
                else if(hit.transform.tag == "Tile"){
                    if(SelectedTile == null){
                        SelectedTile = hit.transform.gameObject;
                    }
                }
            }
            searching = false;
        }
    }

    private void _CreateAnchors()
    {
        _Anchors = new List<GameObject>();
        var anchorContainer = new GameObject("Anchors");
        for (int x = 0; x < BOARD_X; x++)
        {
            for (int y = 0; y < BOARD_Y; y++)
            {
                var anchor = Instantiate(SpawnPrefab, new Vector3(x + _SPACER, 0f, y + _SPACER), SpawnPrefab.transform.rotation);
                anchor.name = $"Anchor-{x}-{y}";
                _Anchors.Add(anchor);
                anchor.transform.SetParent(anchorContainer.transform, true);
            }
        }
    }

    private void _MoveTile(Transform anchor){
        TileController tile = SelectedTile.GetComponent<TileController>();
        tile.SetTarget(anchor.position, _SPACER);
        SelectedTile = null;
    }

    private Transform _GetClosestTile(Transform hit){
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = hit.position;
        foreach(GameObject tile in _Anchors)
        {
            Vector3 directionToTarget = tile.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = tile.transform;
            }
        }
        return bestTarget;
    }
}
