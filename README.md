# Interactive 3D Fastfood Menu App (Augmented Reality)

An interactive Fastfood Menu application built using **Unity Engine** and **Vuforia SDK**. This project is designed to project highly detailed 3D food models onto real-world paper menus or image markers using a smartphone camera.
<p align="center">
  <img src="https://github.com/user-attachments/assets/86e26516-de2f-40b0-bbac-73edf089a457" width="15%" alt="1" />
  <img src="https://github.com/user-attachments/assets/4a957604-f1db-4166-86e8-2892a35bf0cf" width="15%" alt="2" />
  <img src="https://github.com/user-attachments/assets/e1032206-371e-4061-9112-db6c9d23b061" width="15%" alt="3" />
</p>
---



## 🚀 Key Features
* **Real-time 3D Projection:** Visualizes premium 3D food models instantly when the camera detects the designated image target.
* **Touch Screen Gestures:** Interactive manipulation allowing users to **Rotate**, **Scale**, and **Translate** (move) the 3D objects directly on their screens.
* **Audio & Text Narrations:** Automatically displays a description card and plays an audio guide summarizing the selected food item upon detection.
* **Beginner-Friendly UI:** Includes an intuitive user guide screen on the main menu page for easy navigation.

---

## 🛠️ Tech Stack & Requirements
* **Game Engine:** Unity (Recommended version: `2022.3 LTS` or equivalent LTS version used during development)
* **AR SDK:** Vuforia Engine SDK
* **Programming Language:** C# (C-Sharp)
* **Target Platforms:** Android (.apk) / iOS

---

## 📦 Step-by-Step Guide for Beginners (How to Clone & Run)

Follow these simple steps to download and run this project on your local machine:

1. Prerequisites
Make sure you have downloaded and installed Unity Hub (https://unity.com/download) and a stable version of Unity Editor.

2. Clone the Repository
Open your Command Prompt (CMD) or terminal, navigate to your desired directory, and run the following command:
git clone https://github.com/mburimata/augmented-reality-fastfood.git

3. Open the Project in Unity
- Open Unity Hub.
- Click the Add button at the top right.
- Select the cloned folder (augmented-reality-fastfood).
- Unity will automatically detect the configuration and download the necessary Vuforia Engine Package dependencies listed in manifest.json. (This might take a couple of minutes on the first boot).

4. Locate the Target Databases
The pre-configured local Image Target tracking files (.dat and .xml) are securely saved inside the project structure at: Assets/StreamingAssets/Vuforia/

5. Build to Your Phone
- In Unity Editor, go to File > Build Settings.
- Switch the platform to Android or iOS.
- Click Build and Run while your smartphone is connected via USB debugging.
