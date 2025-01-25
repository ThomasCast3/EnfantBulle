using UnityEngine;
using UnityEditor; // Nécessaire pour la sauvegarde des prefabs dans l'éditeur

public class WorldBuilder : MonoBehaviour
{
    [Header("Letter Prefabs")]
    public GameObject[] letterPrefabs; // Liste des prefabs des lettres A à Z.

    [Header("Word Settings")]
    public string wordToBuild; // Le mot à construire.
    public float letterSpacing = 1.0f; // L'espacement entre les lettres.

    [Header("Parent Object")]
    public Transform parentTransform; // L'objet parent temporaire.

    [Header("Prefab Settings")]
    public string savePath = "Assets/Prefabs/Lettre"; // Chemin où sauvegarder le prefab.

    [ContextMenu("Build And Save Word")]
    public void BuildAndSaveWord()
    {
        if (letterPrefabs == null || letterPrefabs.Length != 26)
        {
            Debug.LogError("Assurez-vous que 26 prefabs de lettres (A à Z) sont assignés dans la liste.");
            return;
        }

        // Supprime tout ancien contenu dans l'objet parent.
        foreach (Transform child in parentTransform)
        {
            DestroyImmediate(child.gameObject);
        }

        // Construit le mot.
        for (int i = 0; i < wordToBuild.Length; i++)
        {
            char letter = wordToBuild[i];
            int index = char.ToUpper(letter) - 'A'; // Calcule l'index (A=0, B=1, etc.).

            if (index >= 0 && index < letterPrefabs.Length)
            {
                // Instancie le prefab de la lettre.
                GameObject letterPrefab = Instantiate(letterPrefabs[index], parentTransform);

                // Positionne la lettre.
                letterPrefab.transform.localPosition = new Vector3(i * letterSpacing, 0, 0);
                letterPrefab.transform.localRotation = Quaternion.Euler(0, 190, 0); // Applique une rotation de 190° en Y.
                letterPrefab.transform.localScale = Vector3.one;
            }
            else
            {
                Debug.LogWarning($"Le caractère '{letter}' n'est pas une lettre valide.");
            }
        }

        // Sauvegarde l'objet parent comme prefab.
        SaveAsPrefab();
    }

    private void SaveAsPrefab()
    {
        if (!AssetDatabase.IsValidFolder(savePath))
        {
            Debug.LogError($"Le chemin de sauvegarde '{savePath}' est invalide. Assurez-vous qu'il existe dans le projet.");
            return;
        }

        // Crée un chemin pour le prefab.
        string prefabPath = $"{savePath}/{wordToBuild}.prefab";

        // Supprime tout prefab existant au même chemin.
        if (AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath) != null)
        {
            AssetDatabase.DeleteAsset(prefabPath);
        }

        // Sauvegarde le GameObject comme prefab.
        PrefabUtility.SaveAsPrefabAssetAndConnect(parentTransform.gameObject, prefabPath, InteractionMode.UserAction);
        Debug.Log($"Le prefab '{wordToBuild}' a été sauvegardé à : {prefabPath}");
    }
}
