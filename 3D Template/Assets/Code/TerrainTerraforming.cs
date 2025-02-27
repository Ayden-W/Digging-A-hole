using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
public class TerrainTerraforming:MonoBehaviour
{
    private MeshFilter meshFilter;
    private MeshCollider meshCollider;

    [SerializeField] LayerMask terrainLayer;
    [SerializeField] Transform player;
    [SerializeField] Camera Cam;
    [SerializeField] float playerReach;
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();
    }

    void Update()
    {
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Input.GetMouseButton(0) && Physics.Raycast(ray,out hitInfo, playerReach, terrainLayer))
        {
            TerraformTerrain(hitInfo.point, 0.01f, 5);
        }

        if (Input.GetMouseButton(1) && Physics.Raycast(ray, out hitInfo, playerReach, terrainLayer))
        {
            TerraformTerrain(player.position, -0.01f, 5);
        }
    }

    private Mesh mesh;
    private Vector3[] vertices;

    private void TerraformTerrain(Vector3 position, float height, float range)
    {
        mesh = meshFilter.sharedMesh;
        vertices = mesh.vertices;
        position -= meshFilter.transform.position;
        
        int i = 0;
        foreach (Vector3 vert in vertices)
        {
            if (Vector2.Distance(new Vector2(vert.x, vert.z), new Vector2(position.x, position.z)) <= range)
            {
                vertices[i] = vert + new Vector3(0, height, 0);
            }
            i++;
        }

        mesh.vertices = vertices;
        meshFilter.sharedMesh = mesh;
        meshCollider.sharedMesh = mesh;
    }



}
