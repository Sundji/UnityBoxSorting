# UnityBoxSorting

![alt_text](https://github.com/Sundji/UnityBoxSorting/blob/main/Assets/Screenshots/Screenshot.png?raw=TRUE)

- the worker goes from wall to wall and sorts boxes found on the way
- the worker changes his direction only when a wall is hit or when the needed container is in the opposite direction
- container positions are initially unknown, the worker saves them once he finds the containers
- boxes spawn randomly on the floor
- the number of sorted boxes is displayed with the help of a simple user interface
- used boxes return to an object pool to be reused again
- prefabs are generic in a way that it is not needed to create a prefab for each color, the appearance is set through code with the color value given in an initialization function
- made for the resolution 1920x1080