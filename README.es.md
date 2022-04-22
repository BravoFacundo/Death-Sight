# DeathSight

[En progreso] Videojuego de VR (Realidad Virtual) basado en Raycast y Físicas. Hecho en Unity, C#.

*If you prefer, you can read this in [English](README.md)*

# Tecnologías

Desarrollado utilizando:
- Lenguaje C#
- Unity 2021

# Idea y desarrollo

Este videojuego está diseñado para explorar el desarrollo de un videojuego de realidad virtual que utiliza físicas de muñecas de trapo.

El desafío propuesto es implementar una jugabilidad que solo requiera como Inputs el movimiento de la cabeza.

# Implementación

Se creó un sistema de Raycast visible a través de LineRenderer que funciona como rayos láser disparados desde la cabeza del jugador.
Estos rayos se activan y desactivan con la mirada del jugador y cuentan con una batería que se recarga cuando el jugador no los está utilizando.

El jugador está estático en el centro de un escenario de 360° donde se generan enemigos (Zombies) que avanzan lentamente hacia el.

La dificultad del juego se basa en la óptima utilización del rayo por parte del jugador.
Si el rayo no es desactivado antes de quedarse sin carga entonces el jugador deberá esperar a que se recargue por completo, 
requiriendo que el rayo sea activado y desactivado correctamente para que durante el tiempo de recarga no sea alcanzado por los enemigos.

# Créditos y links

Assets utilizados:
- [“Mremireh o desbiens”](https://www.mixamo.com/#/?page=1&query=zombie&type=Character)
