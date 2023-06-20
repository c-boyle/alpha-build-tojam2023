# Alpha Build
A top-down multiplayer game where you battle as customizable, modular robos. 
The heart of a robo is its power crystal, break it with a hit from your robo-mods or smash it on a wall to destroy your opponent.

# Screenshots & Videos

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



