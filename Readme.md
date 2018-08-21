# Comp313 Project 2: Game Prototype
Programmer: Nicholas Snellgrove
Design Team mate: Vivian Chen

## Concept
This prototype, named "Singularity", is set in space, at a small mining station which has fallen under attack from an unknown entity. 
As the entity and its forces attack the station, the player must defend it at all costs, and find some way of stopping this singularity.
The player controls a single starfighter, and must defend the station against waves of enemies.  
The presence of this entity causes wormholes to open up in the area, which will teleport the player between them if they fly into one. These can be used to make
a quick getaway, or get the drop on an unsuspecting foe. As time goes on, more and more of these portals will spawn, making travel in the area ever more unpredictable.

## Instructions
W: Thrusters forward
S: Brake
A/D: Bank Left/Right
Left Ctrl/Left Mouse Button: Fire Autolaser
Mouse Up: Pull Ship up
Mouse Down: Ship down
Mouse left: Ship turn left
Mouse Right: Ship turn right

Escape: Pause game/unpause game
From the pause menu, you can resume, reset, and quit the game using the buttons. 
***Note, at time of submission the exe and app sometimes break the buttons on the main menu. No idea why, spent way too much time trying to figure it out...***

**Bonus: Try moving the mouse to one side, then quickly moving it back to the other side. If you get it right, you can do a little barrel roll!**

### Drivers
`: Destroy Ship
TAB: Speed to 0

## Main Game Loop
In this prototype, there are no objectives implemented to handle the pacing of the game. The player can fly around the level, and 5 'enemies' will randomly fly around the level too. 
The game loop handles the spawning of new pairs of wormholes every 30 seconds. There could be between 1 and 3 pairs of wormholes generated each time this event fires. 
The LevelController also checks that the player is not dead. If they are, it will call the appropriate methods to 'end the game' (hiding panels, playing animations etc).
Over time, the level will fill with more and more wormholes, as the previous wormholes persist once the new ones are made.
The level controller also handles the main music and the 'wormhole spawn' music. These are managed by Audio Sources. The Music plays on awake, and loops indefinitely. The wormhole spawn is triggered every 30 seconds.

### How it works
Each destructable entity in the scene has a 'Targetable' script which handles things like health, damage, death etc. Only the player can travel through wormholes - the wormholes are instantiated from a prefab, and linked only to their paired wormhole.
Any attempts to enter the Singularity will kill the player - this uses a similar method to the detection for teleporting through the smaller wormholes, but with death, instead of teleportation...

## Technically challenging/interesting.
With a fast paced space shooter that we are trying to achieve with this prototype, it is critical that the movement and controls of the ship 'feel good' to the player. To this end, developing a robust movement control system was one of the more technically challenging parts of the prototype to achieve. There is plenty of documentation on this issue, but a lot of it just didn't feel right. This particular problem was holding up development for over a week, before I found the spaceflight controls library, linked below. This library handles very well, and allows for a high degree of customisation. This customisation allowed me to tweak and balance the movement so that the player feels agile, powerful and awesome when flying around the level. The ship handles very well, it can perform tight turns and tricks, and the camera work feels great. 
Getting this library into the project was a great success, and certainly helped to make the movement controls in the game very interesting and entertaining.


## Learning Resources
### Contains links to material used during the development of this project. Libraries, tutorials etc...

* https://unity3d.com/learn/tutorials/projects/2d-ufo-tutorial/following-player-camera  
To make the camera follow the player ship
* https://answers.unity.com/questions/199716/bullet-targeting-cursor.html
To improve targetting reticule later(?)
* Library to handle movement and steering - https://assetstore.unity.com/packages/tools/input-management/spaceflight-controls-24532
Search String: 'unity 3d spaceship controls'
* Plenty of learning resources from: https://www.youtube.com/user/Brackeys
* Pacing the shooting system, and visuals for weapon system (LineRenderer): https://www.youtube.com/watch?v=l86gpYbQFzY&feature=youtu.be&t=13m32s
* Black Hole: https://www.youtube.com/watch?v=g9ey3jQna9g

## Assets
### Links for assets used in the project
* Player Explosion/Enemy Explosion -  Unity Particle Pack (https://assetstore.unity.com/packages/essentials/asset-packs/unity-particle-pack-73777)
* Skyboxes - Nebula Skybox Pack (https://assetstore.unity.com/packages/2d/textures-materials/sky/nebula-skybox-pack-8964)
* Sun (Lens Flare) - Unity Standard Assets: https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-32351
* Jupiter/Asteroid Belts -  https://item.taobao.com/item.htm?spm=a1z09.2.0.0.72ae2e8dC2MxhQ&id=537662936323&_u=l1vagq6ga815
* Free Droid - https://assetstore.unity.com/packages/3d/vehicles/space/space-droid-32200
* Weapon Impact - https://assetstore.unity.com/packages/tools/input-management/spaceflight-controls-24532
* Black Hole tools: Shader Forge (https://assetstore.unity.com/packages/tools/visual-scripting/shader-forge-14147)
* Nonstop (Game Music) and Thunder Dreams (Main Menu Music) - Kevin Macleod: https://incompetech.com/music/
* Laser sound effect: https://freesound.org/people/deleted_user_2731495/sounds/427396/
* Portal Open Sound Effect: https://freesound.org/people/roper1911/sounds/152322/download/152322__roper1911__heavy-beam-weapon.mp3
* Weapon impact sound effect: https://freesound.org/people/unfa/sounds/193429/download/193429__unfa__projectile-hit.flac
