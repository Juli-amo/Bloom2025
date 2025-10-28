# 🌸 Bloom – Interactive 2D Storytelling Game

**Bloom** is an interactive 2D storytelling game set in nature.  
Players nurture plants, advance their technology and watch the ecosystem evolve — until beautiful, fast-growing invasive species and creeping signs of **automation and industrialization** slowly begin to change the world they once cared for.  

Through purely visual and auditory storytelling, *Bloom* explores themes of **greed, sustainability, technological ambition, and ecological balance**.  
Every action has a consequence, and the player must ultimately decide between **maintaining beauty, embracing efficiency, or restoring harmony**.

---

### 🪴 Core Ideas
- Environmental storytelling without text  
- Symbolic narrative through visuals, sound, and color  
- Reflection on sustainability, industrial growth, and human impact  

---

### 🗂️ Project Structure
📁 <Repo-Root>
│
├── 📁 Assets
│   │
│   ├── 📁 Art
│   │   ├── 📁 Backgrounds
│   │   ├── 📁 Plants
│   │   ├── 📁 UI
│   │   └── 📁 Materials
│   │
│   ├── 📁 Audio
│   │   ├── 📁 Music
│   │   └── 📁 SFX
│   │
│   ├── 📁 Prefabs
│   │
│   ├── 📁 Scenes
│   │   ├── 🎮 Title.unity
│   │   ├── 🎮 Garden.unity
│   │   ├── 🎮 Decision.unity
│   │   └── 🎮 Outcome.unity
│   │
│   ├── 📁 Scripts
│   │   ├── 📁 Core          # GameState, EventBus, Utilities, Extensions
│   │   ├── 📁 Systems       # PlantGrowth, GardenHealth, Time/GrowthTimers
│   │   ├── 📁 UI            # HUD, Menus, Popups, TMP-Bindings
│   │   ├── 📁 Net           # ApiClient, Telemetry, Edge-Calls
│   │   ├── 📁 Data          # Plain C# Models, DTOs
│   │   └── 📁 Analytics     # Event wrappers, sampling, offline queue
│   │
│   ├── 📁 Settings
│   │   ├── 📁 Balancing     # ScriptableObjects: growth rates, thresholds
│   │   ├── 📁 Colors        # ScriptableObjects: palettes per state
│   │   └── 📁 Addressables  # (optional) Addressables profiles/groups
│   │
│   ├── 📁 Shaders           # If we have time
│   ├── 📁 Animation         # Anim Controller, Clips
│   ├── 📁 ThirdParty        # ThirdParty-Assets (with Lizenz-Readme)
│   │
│   └── 📁 Tests
│       ├── 📁 EditMode
│       └── 📁 PlayMode
│
├── 📁 ProjectSettings       # Unity-Projectsetting
├── 📁 Packages              # Dependencies
│
└── 📁 Docs
    ├── 📝 Brief.md
    ├── 📝 Architecture.md
    └── 📝 ArtGuidelines.md


