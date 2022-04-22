# DeathSight

[Work in progress] VR (Virtual Reality) video game based on Raycast and Physics. Made in Unity, C#.

*Si lo prefieres, puedes leer esto en [español](README.es.md)*

# Tecnologías

Developed using:
- C# Language
- Unity 2021

# Idea y desarrollo

This game is designed to explore the development of a virtual reality game that uses ragdoll physics.

The proposed challenge is to implement a gameplay that only requires head movement as inputs.

# Implementation

A visible Raycast system was created through LineRenderer that works like laser beams fired from the player's head.
These beams are activated and deactivated by the player's gaze and have a battery that recharges when the player is not using them.

The player is static in the center of a 360° stage where enemies (Zombies) are spawned and slowly move towards him.

The difficulty of the game is based on the optimum use of the beam by the player.
If the beam is not deactivated before running out of charge then the player must wait for it to fully recharge, 
requiring the beam to be activated and deactivated correctly so that during the recharge time it is not hit by enemies.

# Créditos y links

Used Assets:
- [“Mremireh o desbiens”](https://www.mixamo.com/#/?page=1&query=zombie&type=Character)

