using UnityEngine;

public class PlantPlotSimpleGrowth : MonoBehaviour
{
    public enum State { Empty, Seed, Growing, Bloom }
    public State state = State.Empty;

    [Header("Renderers")]
    public SpriteRenderer soil;      // PlantPlot (braun)
    public SpriteRenderer plant;     // Kind 'PlantVisual' (grün)
    public SpriteRenderer waterBar;  // Kind 'WaterBar' (cyan)

    [Header("Water")]
    [Range(0,100)] public int water = 0;
    public int waterPerPress = 20;        // F erhöht um 20
    public int growingThreshold = 30;     // ab 30 -> Growing
    public int bloomThreshold   = 70;     // ab 70 -> Bloom

    bool inRange;

    void Awake() {
        if (!soil)  soil  = GetComponent<SpriteRenderer>();
        if (!plant) plant = GetComponentInChildren<SpriteRenderer>(true);
        UpdateVisual();
        UpdateWaterBar();
    }

    void Update() {
        if (!inRange) return;

        if (Input.GetKeyDown(KeyCode.E)) PlantIfEmpty(); // pflanzen
        if (Input.GetKeyDown(KeyCode.F)) Water();        // gießen
    }

    public void PlantIfEmpty() {
        if (state == State.Empty) {
            state = State.Seed;
            water = 0;
            UpdateVisual();
            UpdateWaterBar();
        }
    }

    public void Water() {
        if (state == State.Empty) return; // erst E drücken zum Pflanzen
        water = Mathf.Clamp(water + waterPerPress, 0, 100);

        // State aus Wasser ableiten
        if (water >= bloomThreshold)      state = State.Bloom;
        else if (water >= growingThreshold) state = State.Growing;
        else                               state = State.Seed;

        UpdateVisual();
        UpdateWaterBar();
    }

    void UpdateVisual() {
        if (soil) soil.color = new Color(0.545f, 0.42f, 0.30f); // braun

        if (!plant) return;
        if (state == State.Empty) { plant.gameObject.SetActive(false); return; }

        plant.gameObject.SetActive(true);
        if (state == State.Seed)   { plant.color = new Color(0.70f,0.90f,0.70f); plant.transform.localScale = Vector3.one * 0.35f; }
        if (state == State.Growing){ plant.color = new Color(0.50f,0.85f,0.50f); plant.transform.localScale = Vector3.one * 0.60f; }
        if (state == State.Bloom)  { plant.color = new Color(0.95f,0.50f,0.85f); plant.transform.localScale = Vector3.one * 0.90f; }
    }

    void UpdateWaterBar() {
        if (!waterBar) return;
        float pct = water / 100f;
        var t = waterBar.transform;
        t.localScale = new Vector3(0.8f * Mathf.Clamp01(pct), 0.08f, 1f);
    }

    void OnTriggerEnter2D(Collider2D other) { if (other.CompareTag("Player")) inRange = true; }
    void OnTriggerExit2D(Collider2D other)  { if (other.CompareTag("Player")) inRange = false; }
}