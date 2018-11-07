# Singularity - Individual Reflection

## Brandon Scott-Hill - scotthbran - The Wolf

Dealt with the targeting systems, shooting systems, menus and code clean ups

---

## Code Discussion


Code| All | Most | Half | Some | Touched |
|---|---|---|---|---|---|
| Targeting Systems |✓| | | | |
| Environment Force Emitter | | | | |✓|
| Health Bar Code (Player)| | | ✓| | |
| Pause Menu Code| |✓| | | |
| Main Menu Code|✓| | | | |
| Game Over Code| | | | |✓|
| Player Code | | |✓| | |
| Weapon System | | | |✓| |
| Tutorial Menu |✓| | | | |


The most interesting section of code that I had created during the project would have to be the [target system code](https://github.com/Nickel64/Singularity-Group-Project/blob/master/Project3/Assets/Scripts/Targetable.cs) specifically Target Lock method. While it does look complex due to the number of pre-conditions needed what is doing is both interesting and simple. What it’s doing it is it got a list of possible target locks which are ai in a certain distance from the player, then it loops through those possible target locks to find the closest ai to the mouse after it’s being transformed into an on-screen 2D point. Because there are some many possible enemy ai on screen at any time to save on performing instead of looping over all enemy ai it loops through a smaller subset of them. That adaptation to improve performance is what makes the target lock code/method interesting. 

Regarding code that I’m the proudest of is the pause menu controller code. The reason why I’m pleased with this code and why it’s good quality code how well it is working with unity and by working well with unity makes something possibly complicated simple. Like how pausing working instead of trying the script control all other game objects adding high-level coupling with pausing it simply stops time with the use of unity. Or going between menus instead of controlling the text of the screen and removing object the code simply loads a different scene. By loading a different scene, it removes all coupling between pause menu and the other menu and allows different game objects for the other menu.

---

## Learning Reflection

The biggest thing that I’ve learned working with unity compared to my other experiences with different languages is the abstraction of scripting and working with engine and not fighting it. What I mean by that I learn on how to think to when coming up for a solution for unity that works with unity. Instead of thinking about I have this set of the code base and need design this solution with different objects. As my experience with unity help me think more about the actual game objects in the scene instead of abstract code objects. I think learning this idea of scripting and not fighting engine will help in me in future work with other engines and possible frameworks and give me the tool to like code script abstraction instead of the standard.

Regarding what was the most important thing I’ve learned from this project has to do with project management. As I learned communication is extremely important, and lack of it leads to wasted time and demotivates the team, And that needs to be a process set on communication even when there are team members have a completely different profession. This communication process could include progress reporting or regular meeting/stand up to check progress with the idea to create micro deadlines to generate motivation. While issue systems would normally cover this with team members that don’t work with issues a method that forces communication with those team members should also be adopted. In future projects, I will at the beginning be part of my focus to create and plan a form of communication that forces team members to regularly provide information on what they do are how well they are doing. 