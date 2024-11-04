using UnityEngine;
using UnityEngine.UI;

public class PokemonSelector : MonoBehaviour
{
    [System.Serializable]
    public class Pokemon
    {
        public string name;
        public Sprite image;
        public string height;
        public string category;
        public float weight;
        public string[] abilities;
        public string type;
        public string weakness;
        public int hp;
        public int attack;
        public int defense;
        public int specialAttack;
        public int specialDefense;
        public int speed;
    }
    public Pokemon[] pokemons;
    public Button[] alternateButtons;
    public GameObject statsPanel;
    public Image pokemonImage;
    public Text pokemonName;
    public Text heightText;
    public Text categoryText;
    public Text weightText;
    public Text abilitiesText;
    public Text typeText;
    public Text weaknessText;
    public Slider hpSlider;
    public Slider attackSlider;
    public Slider defenseSlider;
    public Slider specialAttackSlider;
    public Slider specialDefenseSlider;
    public Slider speedSlider;
    public Button backButton;


    private void Start()
    {
        backButton.onClick.AddListener(CloseStatsPanel);
        statsPanel.SetActive(false);

        for (int i = 0; i < pokemons.Length; i++)
        {
            CreatePokemonButton(pokemons[i]);
            
            if (i < alternateButtons.Length)
            {
                int index = i;
                alternateButtons[index].onClick.AddListener(() => ShowStatsPanel(pokemons[index]));
            }
        }
    }

    private void CreatePokemonButton(Pokemon pokemon)
    {
        GameObject button = new GameObject(pokemon.name + " Button");
        Button btn = button.AddComponent<Button>();
        Text btnText = button.AddComponent<Text>();
        btnText.text = pokemon.name;

        btn.onClick.AddListener(() => ShowStatsPanel(pokemon));

        button.transform.SetParent(this.transform, false);
    }

    private void ShowStatsPanel(Pokemon pokemon)
    {
        pokemonImage.sprite = pokemon.image;
        pokemonName.text = pokemon.name;
        heightText.text = pokemon.height;
        categoryText.text = pokemon.category;
        weightText.text = pokemon.weight + " kg";
        abilitiesText.text = string.Join(", ", pokemon.abilities);
        typeText.text = pokemon.type;
        weaknessText.text = pokemon.weakness;
        
        hpSlider.value = pokemon.hp;
        attackSlider.value = pokemon.attack;
        defenseSlider.value = pokemon.defense;
        specialAttackSlider.value = pokemon.specialAttack;
        specialDefenseSlider.value = pokemon.specialDefense;
        speedSlider.value = pokemon.speed;

        statsPanel.SetActive(true);
    }

    private void CloseStatsPanel()
    {
        statsPanel.SetActive(false);
    }
}
