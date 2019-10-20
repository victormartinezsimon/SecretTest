This file will explain all the decisions I make to develop this test.

The first thing is that there are only 2 scenes, Menu and Game. Each scene can be executed without the other. This is done because its more easy to debug if all scenes can be executed independently.

Game Manager:
The main script in the test is GameManager.cs. This is a Singleton class, so the different classes in the different scenes can use it.
This script controlls the change to a different scene, it get the data from the endpoint json and it controlls the game time, the best score and the current score.

The ui:
The UI its simple. It will read the data from the Game Manager and it will show the data. If there is a button, the UI will call the method in the script, and the method will call the GameManager.
I do this because if the button calls the GameManager, it may be deleted and nothing will work. The GameManager can be deleted because the Singleton Pattern.

Pool System:
The bullets and the planes are generated and saved in a Pool. The pool is initialized with the correct size in the Start() of the script.
At any time, when a object is needed, it can be obtained from the pool, but only if there is some object available.

Screen Limits:
The task says that we need to do somethings when the plane or the bullets reach the screen limits. This task can be done in different ways.
The first one, is a script that is added to the bullet or the plane and in the update, check if the object is out of the screen.
The second one, and the one that I make, is create some colliders in the limits and when something hits them, do the job. I do this way so you can see that I know the different between normal collision and Trigger collision.

StartManager:
The start manager move the colliders to the correct position, after that, move the turret to the correct position and notify the GameManager that everything is correct so the game can start.

Input Manager:
The input manager is the only script that read the data from the keyboard. This script changes the turret that is visible, so everything is correctly viewed. It will also create the bullets, move to the correct position and rotate to the correct grades.

LinearMovement:
The planes and the bullets move from the left to the right. With this thing in mind, the only problem was for the bullets. To solve the problem, the bullets are rotated so all the times move from "left" to "right"

PlaneGenerator:
The plane generator controls the planes alive and if there are no planes left, if will generate the random number of planes.
When a plane is generated, it will also set the velocity and the start point to controlled random values. This is done because I don't want to all the games to be the same.
The velocity of the planes are in the LinearMovement script and its public so it can be changed from the editor. 