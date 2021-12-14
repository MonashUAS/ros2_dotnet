using System;
using GirbalPathfinding;
using SD.Tools.Algorithmia.PriorityQueues;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System;
using System.Linq;

public class ConstraintNode
{
	//public int x;
	//public int y;
	//public int time;

	//constraint --> (a_i,State)

	//public List<State> constraints;
	public List<(State constraint, int agentId)> constraints; // initilises a list that contains a state and an agent ID
	
	public int cost; // cost of moving to a location
	//public List<List<State>> solution;
	public List<(List<State> pathList, int pathCost, int agentId)> solution;

	public ConstraintNode(List<(State constraint, int agentId)> constraints, int cost, List<(List<State> list, int cost, int agentId)> solution)
	{	
		// sets values based on newly create instance
		this.constraints = constraints;
		this.cost = cost;
		this.solution = solution;
	}
}
