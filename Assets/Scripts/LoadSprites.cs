using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TestWeb.MyRefactoring
{
    public class LoadSprites : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer[] spriteRenderer;
        [SerializeField]
        private string[] strings;

        private Dictionary<string, Sprite> spriteCache = new Dictionary<string, Sprite>();

        public void Load()
        {
            for (int i = 0; i < spriteRenderer.Length; i++)
            {
                StartCoroutine(LoadSprite(spriteRenderer[i], i));
            }
        }

        private IEnumerator LoadSprite(SpriteRenderer spriteRenderer, int number)
        {
            if (spriteCache.ContainsKey(strings[number]))
            {
                spriteRenderer.sprite = spriteCache[strings[number]];
            }
            else
            {
                var task = Addressables.LoadAssetAsync<Sprite>(strings[number]);
                yield return task;
                if (task.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
                {
                    Sprite loadedSprite = task.Result;
                    spriteCache[strings[number]] = loadedSprite; 
                    spriteRenderer.sprite = loadedSprite;
                }
                else
                {
                    Debug.LogError("Failed to load sprite for spriteRenderer: " + spriteRenderer.name);
                }
            }
        }
    }
}
