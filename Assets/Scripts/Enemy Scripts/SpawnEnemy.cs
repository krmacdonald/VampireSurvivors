using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public LayerMask buttonLayer; // Detecting the layer. We probably will not need this down the line. 
    public GameObject enemyPrefab; // This is where enemies go
    public GameObject spawnObject; //just an empty game object to reference where to spawn this enemy

    void Update()
    {
        if (Input.GetButtonDown("Interact")) // casting a ray
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, buttonLayer))
            {
                // Check if the ray hit a button
                ButtonClicked(hit.collider.gameObject);
                Debug.Log("button was hit");
            }
        }
    }

    void ButtonClicked(GameObject button)
    {
        // Generate the enemy. This can be flexible for when we just want to spawn enemies generally. I just have this raycast running for the purpose of testing
        Instantiate(enemyPrefab, spawnObject.transform.position, spawnObject.transform.rotation);
    }
}