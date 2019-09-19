using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class TerrainGenerator : MonoBehaviour
{
    private Mesh _Mesh;
    private int[] _Triangles;
    private Vector3[] _Verticies;

    public int xSize = 20;
    public int zSize = 20;

    // Start is called before the first frame update
    void Start()
    {
        _Mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _Mesh;
        var co = StartCoroutine(CreateShape());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMesh();
    }

    private IEnumerator CreateShape(){
        _Verticies = new Vector3[(xSize + 1) * (zSize + 1)];
        _Triangles = new int[xSize * zSize * 6];

        for (int i = 0, z = 0; z <= zSize; ++z)
        {
            for (int x = 0; x <= xSize; ++x)
            {
                _Verticies[i] = new Vector3(x, 0, z);
                ++i;
            }
        }

        for (int vert = 0, tris = 0, z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                _Triangles[tris + 0] = vert + 0;
                _Triangles[tris + 1] = vert + xSize + 1;
                _Triangles[tris + 2] = vert + 1;
                _Triangles[tris + 3] = vert + 1;
                _Triangles[tris + 4] = vert + xSize + 1;
                _Triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
                yield return new WaitForSeconds(.001f);
            }
            vert++;
        }
    }

    private void UpdateMesh(){
        _Mesh.Clear();
        _Mesh.vertices = _Verticies;
        _Mesh.triangles = _Triangles;
    }

    private void OnDrawGizmos() {
        if(_Verticies == null) return;
        for (int i = 0; i < _Verticies.Length; i++)
        {
            Gizmos.DrawSphere(_Verticies[i], .1f);
        }
    }
}
