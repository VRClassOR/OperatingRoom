# Operating Room VR Project
Created by: Ankur Lal, Abbey White, Michael Riley, Lexi Anderson, Sarah Tesfaye

Built with Unity version 2018.2.15f1 using Oculus VR capabilities

For CS 3892/UNIV 3279 Fall 2018

In collaboration with Dr. Jonathan Schoenecker

In this project, we created a virtual, interactive operating room environment in which we provided a Trochanteric Fixation Nail System (TFN) to mend a hip fracture. Users follow a sequence to assemble the tools and optimize their score by assembing the kit quickly and accurately.

## Motivation
The purpose of this simulation is to familiarize users, in particular medical students, with the assembly process. A physical TFN kit is expensive and inaccessible, so it is difficult to acclimate oneself to using one before entering the operating room. This simulation is a simple solution to that problem.

## Assets & Features
- Operating room environment with tables and props
- TFN set
	- Singular tools
		- Aiming arm
		- Connector
		- Driver
		- Driving Cap
		- Guide Connector
		- Handle
		- Nail
	- Step-by-step "accumulator" objects that represent each stage of building the kit
- Primary C# scripts
	- GameEndScript: Ends the game when the kit has been built successfully.
	- GameTimerScript: Keeps track of time elapsed during the game and adjusts the score accordingly.
	- KeepingScore: Displays the current score.
	- JoinScript: Performs the "joining" of tools in order to build the set. If the user tries to combine two compatible tools A and B, a new aggregate tool C is formed, A and B are deleted, and the score is increased.
	- UnjoinScript: Performs the unjoining of the handle from the aggregate tool "Driving Cap + Guide Connector + Handle + Driver + Connector + Nail" without destroying the joinObjectSmallCollider.
	
## Future Goals
We have produced a minimum viable product, but there are still many features that can be implemented in the future:

- Learning mode with video walkthrough
- Menu compatible with Oculus VR
- Additional tool kits
- More dynamic joining techniques (screwing, twisting, etc.)
