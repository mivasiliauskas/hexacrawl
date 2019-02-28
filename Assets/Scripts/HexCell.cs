using UnityEngine;

public class HexCell : MonoBehaviour
{
    public Sprite[] characters;

    static System.Random random = new System.Random();

    public Color color;

    public HexCoordinates coordinates;

    public RectTransform uiRect;

    public HexGridChunk chunk;
    AudioSource audioSource;

    Transform sprite;

    float speed = 5.97f;
    float delta = 0.35f;
    int index;

    void Awake()
    {
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        sprite = transform.Find("Sprite");
        index = random.Next(characters.Length);
        GetComponentInChildren<SpriteRenderer>().sprite = characters[index];
    }
    void Update()
    {
        float z = (((audioSource.time + delta) / (audioSource.clip.length + delta)) * 100 % speed) / speed;
        if (index < 50){
            sprite.localPosition = new Vector3(0, 1, z * 2);
        } else {
            sprite.rotation = Quaternion.Euler(90, 0, z * 15);
        }
    }
}