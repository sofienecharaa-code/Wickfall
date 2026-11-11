# 🕯️ WICKFALL

**WICKFALL** is a top-down 2D action-RPG built in Unity. You play as a small candle golem navigating through a dark, treacherous environment. Your wax serves a dual purpose: it acts as both your health bar and your light source in the pitch black.

---

## 🎮 Game Overview & Concept

In **WICKFALL**, light is survival. As you explore the dark realm, taking damage or spending time in the shadows diminishes your candle wax, reducing both your health and your visual radius. To stay alive, you must defeat dark entities, collect wax pickups, activate checkpoint braziers, and navigate your way to safety.

---

## ✨ Key Features

* **Dual-Mechanic Health System:** Your wax gauge controls both player health and the 2D lighting intensity around your character.
* **Top-Down 2D Controls:** Smooth 4-directional player movement and real-time enemy combat.
* **Dynamic Lighting & Shadow:** Fully integrated Unity 2D Light & Dynamic Shadow systems creating a dark, atmospheric environment.
* **Enemy AI:** Enemies detect player proximity, chase, and deal damage upon contact.
* **Checkpoint & Rest Stops:** Interactive braziers act as safe havens to replenish lost wax and light.
* **Seamless Audio Experience:** Persistent background music transitioning smoothly between scenes via a dedicated `DontDestroyOnLoad` audio manager.
* **Complete Game Loop:** Main menu, pause functionality, instant scene reloading, game over screens, and victory conditions.

---

## 🕹️ Controls

| Action | Key / Input |
| :--- | :--- |
| **Move Up / Down / Left / Right** | `W` / `A` / `S` / `D` or `Arrow Keys` |
| **Attack** | `Spacebar` / `Left Mouse Button` |
| **Interact (Braziers)** | `E` |
| **Restart Game (Game Over)** | Click **Play Again** or press `Enter` |

---

## 🛠️ Built With

* **Engine:** [Unity](https://unity.com/) (2D URP / Universal Render Pipeline)
* **Language:** C#
* **Version Control:** Git & GitHub

---

## 🚀 Setup & Installation Instructions

### Prerequisites
* **Unity Editor:** Version `2022.3.x LTS` or higher.
* **Git:** Installed on your local machine.

### Running in Unity Editor
1. Clone the repository to your local machine:
   ```bash
   git clone https://github.com/your-username/Wickfall.git
   ```
2. Open **Unity Hub**.
3. Click **Add > Add project from disk** and select the root project folder (`Wickfall`).
4. Select Unity Editor version `2022.3.x` (or your installed LTS version) to open the project.
5. In the `Assets/Scenes/` folder, open **`SampleScene`** (Main Menu) and press the **Play** button.

---

## 📦 Deliverables & Project Structure

```text
Wickfall/
├── Assets/
├── Packages/
├── ProjectSettings/
├── .gitignore
└── README.md
```

---

## 📝 License & Credits

Developed as part of the **2D Animation & Game Development** project curriculum.  
All code scripts, UI elements, audio integration, and scene setups were developed for **WICKFALL**.