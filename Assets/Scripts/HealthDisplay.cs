using UnityEngine;
using TMPro;
public class HealthDisplay : MonoBehaviour
{
    TextMeshProUGUI textComponent = null;
    Player player = null;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();

        textComponent.text = player.GetHealth().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = player.GetHealth().ToString();
    }
}
