# Girbal Pathfinding Readme

Path planning software for project Girbal that plans the paths for any number of drones so that they don’t collide with each other or static obstacles. The program includes a GUI that visualises the randomly generated static obstacles and the paths, start states and goal states of each drone.

## Packages Used

* SD.Tools.Algorithmia (1.4.0)
* SkiaSharp (2.80.3)

## Inputs

The program has several parameters that can be altered to fit the desired purpose in the Globals.cs file, such as:
* Number of drones 
* Start states for each drone 
* Goal states for each drone 
* Drone radius
* Density, size and shape of static obstacles:
  * Obstacle methods is altered for larger changes in obstacle density 
  * Obstacle chance is altered for smaller changes in obstacle density 
  * Obstacle rectangle dictates whether each static obstacle will be a rectangle 
  * Obstacle circle dictates whether each static obstacle will be a circle

## Using Different Pathplanners

This software has been designed so that different low level and high-level path planners can be used. All low-level path planner files should be stored in the path planners file and conform to the IPathplannable interface. The low-level path planner to be used can be altered by changing the line:
	
	ExecutiveController.initialisePlanner<Insert_Your_Path_Planner_Here>();

The high-level path planner is called in the planPath() function inside ExecutiveController.cs. This can easily be changed to which ever high-level path planner you wish to use.

## GUI

The aesthetics of the GUI are written in DisplayRenderer.cs. The colours of the paths, each drone’s start and goal states and the obstacles can be changed here.

## Current Development

* Implementing ROS into the program so that the current states can be received and final paths can be communicated over the thread network
* Adapting the algorithm so that it functions in 3 dimensions

## Possible Future Development

* Improving the efficiency of the algorithm
* Looking into different low and high-level pathfinding algorithms


