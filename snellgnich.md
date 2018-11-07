# Singularity - Individual Reflection

*Nicholas Snellgrove (Snellgnich)  
The Puppy  
Responsible for Movement, AI, Guided Rocket, Minimap and Environment Layout/Code*  

---

## Code Discussion

These are the approximate contributions I made to the (most important) parts of the project, as best as I can recall.

Code| All | Most | Half | Some | Touched |
|---|---|---|---|---|---|
| Minimap | ✓ | | | | |
| Player Movement | ✓ | | | | |
| Enemy Swarm AI | ✓ | | | | |
| Guided Rocket | ✓ | | | | |
| Environment Force Emitter | ✓ | | | | |
| Weapon System | | | ✓ | | |
| Enemy Weapons | | | | | ✓ |
| Wormhole Teleportation | ✓ | | | | |
| Scenic Body Rotation | ✓ | | | | |
| Black Hole | ✓ | | | | |
| Wave System / Level Control | | ✓ | | | |
| Targeting System | | | | ✓ | |
| Boundary | | | | | ✓ |
| Player | | ✓ | | | |
| Menus (Pause, Main, Tutorial) | | | | ✓ | |

I think that the most interesting piece of code that I worked on, and also the part which I was most proud of was the Environment Force Emitter script. 

In our project we had collectively decided to use a 'swarm' behaviour for our AI, and to achieve this I had found a solution on the Unity forums for "Boid" behaviour, and adapted this to fit our project. However, we were still having problems with the entities colliding with scenery in the project. A discussion with the lecturer and some tutors brought up the idea of having a 'smart' environment and 'dumb' AI - something we had covered in lectures previously. From this idea, I did some investigation and found the concept of having environment pieces forcing other entities away from them. I did some further research, and came up with the script as it is now - using an inverse gravity equation to determine the force to apply from a scenic object to an enemy unit. This gave the illusion of object avoidance in the AI, and solved the problem of the AI being suicidal. There were some performance issues with this, but ultimately I think that this solution was a good way to solve a very complex problem in our project.



---

## Learning Reflection

This project has taught me a lot about the game development process, in both technical and management areas. The largest technical learning experience came in the form of learning to write code in an engine. Previously, most of my programming experience had come from environments in which the code was independent - functioning on its own without having to interact with another service. This is a drastically different feel to programming with Unity. In Unity, I found that there were a lot of ways to simplify the work that I was doing by working with the engine, as opposed to fighting against it, as I was at the start. 
One example of this is interfacing with the Unity UI (I.e. dragging a gameobject into a public field in the UI, instead of searching and assigning it in the code). Not only is it easier to work with the Engine, it is also more efficient. Once I learned this, my development improved significantly. 

Another lesson I learned from this project was how important it is to consider performance in a large scale project. In our project we always knew there would be a very large amount of independently thinking entities in the level at any one time, so optimising performance would be critical. Initially this was difficult, but later as I became more familiar with the Unity Engine, it became easier to optimise.  
One resource that was particularly helpful to me was the following diagram, which shows the computation process in Unity.

![Execution Order Diagram](https://docs.unity3d.com/uploads/Main/monobehaviour_flowchart.svg)

This helped me understand the difference between concepts like Update, LateUpdate, FixedUpdate etc, which helped me optimise the various computations in my code. For example, when writing the minimap code, I encountered significant performance hits when running the minimapComponent script on the enemies - it was firing in FixedUpdate, but when I changed it to LateUpdate the problem was solved. 

Besides the technical lessons learned, I also gained a lot of knowledge in the management and inter-personal aspects of a project. More specifically, what happens when communication in a project breaks down.  
At the start of this project we were all enthusiastic, ready and willing to participate. However, it didn't take long for attendance to start dropping, and the team turning into a "Designers and Programmers" situation which limited communication between the two "Sides". This, combined with poor time management on everyone's part, and sub-par leadership of the project overall led to a situation where everyone had a different idea of what was expected of them, and only performed to this (limited) expectation. For example, myself and the other programmers expected the design students to participate more in the actual design of the game (I.e. mechanics, level layout, how it feels, how it plays etc). Instead, the designers took on more of an 'asset producer' role in the project. Unfortunately, this was not realised until quite late, at which point the fracture was too great to correct before the project ended. As a result, the other programmers and I had to do a lot of this design focussed work ourselves at the last minute. 
These communication failings will certainly be my largest take-away from this project. In any future projects I work on I will make absolutely certain that the communication in the project is up to standard, and take on a much more active role in the project if required to achieve this (even if my role does not call for it, as was the case here). In addition, I will try to manage my time and organise the project milestones much more effectively. In this project, the milestones failed, as we all made excuses due to other university commitments. In future I will enforce this much more strictly, in order to maintain momentum in my future work.

Overall, the project started off strong, but quickly faltered due to sub-par communication, leadership, and time management. 






