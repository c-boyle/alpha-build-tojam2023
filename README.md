# Alpha Build
A top-down multiplayer game where you battle as customizable, modular robos. 
The heart of a robo is its power crystal, break it with a hit from your robo-mods or smash it on a wall to destroy your opponent.

![AlphaBuildGif](https://github.com/c-boyle/alpha-build-tojam2023/assets/62191940/d64f03f3-96d2-4dde-a9f9-a8aa74cfe491)

# Screenshots & Videos

### Gameplay video
https://github.com/c-boyle/alpha-build-tojam2023/assets/62191940/ede109ff-dce1-44ed-aa97-26e18188a824

### Arena selection menu
![arena-selection](https://github.com/c-boyle/alpha-build-tojam2023/assets/62191940/cac862a0-316e-4e1b-a2c7-0309ae339e61)

### Flamethrower battle
![image](https://github.com/c-boyle/alpha-build-tojam2023/assets/62191940/f31e0852-ca62-4cbb-95e0-cf482f1de888)

# [TOJam 2023](https://www.tojam.ca/)
This game was built during and for TOJam 2023. This repository is a duplicate of the original project repository. I made this duplicate to preserve and show off what we accomplished during the jam in a public repo. Note: due to the duplication process the commit dates are innacurrate.

# Built with
- [Unity](https://unity.com/)
- C#

# Features

- Local multiplayer using [**Unity's Input System**](https://unity.com/features/input-system)
- [Modular character creation](./Assets/Scripts/Combat/Robo.cs)
- [Robust combat system (handles status effects, specific types of contact like passive or attack contact and can be easily extended)](./Assets/Scripts/Robomod.cs)
  - Handles timed status effects
  - Accounts for specific types of contact like passive or attack
  - Some attacks can be charged to do more damage, while others can be held continuously for a long strike
  - Engineered to be easily extendable
- [Arena selection menu](./Assets/Scripts/UI/ArenaSelectModal.cs)

# Goals
- Character creation menu (almost finished but we didn't have time)
- Singleplayer rogue-like mode where you upgrade your robo
- More robo-mods and supported stats

# Team
### Caleb Boyle (Developer and project manager)

### Joel Boyle (Artist)

### Finn Suckow-Crowell (Artist)



