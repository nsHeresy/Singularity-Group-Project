# Singularity - Individual Reflection

Jack Porter (porterjack)  
The Bear 

Responsible for team organisation and comunication, boundary, game over menu, AI shooting,

---

## Code Discussion

Code| All | Most | Half | Some | Touched |
|---|---|---|---|---|---|
| Minimap | | | | ✓ | |
| AI shooting | ✓ | | | | |
| Boundary | ✓ | | | | |
| Player | | | | | ✓ |
| Game over menu | | ✓ | | | |

The most interesting code and also the code that I'm most proud of is the AI shooting script. This script finds the player as it starts and then keeps track of the distance between the AI and player ships at a low priority on update. If this distance is below the set range value, the ship will fire at the player. In order to do this, the direction to the player is found and then a random value between -accuracy and accuracy is added to the x, y and z values of this direction to intoduce spread to the shooting and prevent the ships being too deadly. A raycast is then sent out in this direction and a line is drawn on screen to show the laser. If the raycast hits the player, they are damaged.

I beleive this is good code due to it's versitility and simplicity. If development of the game was continued, the code could quickly be adapted to allow for different behaviour for new AI types, such as adding the script to multiple firepoints on a larger ship or adding one extra line of code to make the fire rate a public variable, create a more constant, but low damage laser beam. The code is also fairly efficient, as it had to run on every entity in a swarm. Keeping track of the player from the start limits the calls the script needs to make and being called on late update ensures everything else is done before this.
https://github.com/Nickel64/Singularity-Group-Project/blob/master/Project3/Assets/Scripts/AI/AiShoot.cs

---

## Reflection


I learnt quite a bit throughout this project, with the main areas being leadership/teamwork between different disciplines and working within the restrictions of an engine.
At the start of the project, I was quite surpirsed to find myself put in charge of a team and the direction project which I had had no input into previously. I found myself strugling to delegate out tasks, mostly because I was still working out how the game worked myself and because I had no clue about the workload of the designers and what they were cabable of.
This led to the group not achieving much outside of group discussions for the first part of the project, which put the game behind significantly and limited the scope of what we were able to produce. To remedy this, I should have had more individual comunication with the team early in the project. Most of all with Nick, having him run me through the code and discussing the structure in more detail would've been a fast way to understand the project and get the group started earlier. This would've also helped with the designers, seeing their capabilites and interests would help me to ensure they were getting the right jobs and how long those should take to complete.
I feel that my leadership improved throughout the project, but I would have liked to have done more about the imbalance of work done between team members. These are lessons I will definitely be considering the next time I have the chance to lead a project.

In terms of coding, I found The limitations of unity fustrating. Working in the engine required a change in how I thought about coding in this project. When I ran into issues in previous projects, I was able to approach the issue from both sides but in unity the issues were mostly code I had written and existing features of the engine. At the beginning of the project, this compounded with my lack of understading regarding the existing work done on the project and created quite a daunting roadblock to my contributions.

Ultimately, I am proud of the team and the game we produced, although in all honesty, this should have been the result of the first sprint and not the final product. With about half of the possible programming work done and even less than that for design work. A lot of this was due to my leadership and the communication in the group, but I would have liked to see the designers step up regarding input into the game systems and take some work that ended up on the programmers.