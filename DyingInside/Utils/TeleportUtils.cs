using Il2Cpp;
using Il2CppBasicTypes;
using Mono.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DyingInside.Utils
{
	internal class TeleportUtils
	{
		public static Vector2i ConvertWorldPointToMapPoint(Vector2 worldPoint)
		{
			Vector2i result;
			result.x = 0;
			result.y = 0;
			result.x = (int)((worldPoint.x + ConfigData.tileSizeX * 0.5f) / ConfigData.tileSizeX);
			result.y = (int)((worldPoint.y + ConfigData.tileSizeY * 0.5f) / ConfigData.tileSizeY);
			return result;
		}

		public static Vector2 ConvertMapPointToWorldPoint(Vector2i mapPoint)
		{
			Vector2 result;
			result.x = mapPoint.x * ConfigData.tileSizeX;
			result.y = mapPoint.y * ConfigData.tileSizeY;
			return result;
		}

		// thank chat gpt i do not understando a*

		public static List<Vector2i>? FindPath(Vector2i start, Vector2i goal)
		{
			if (!IsTileWalkable(start) || !IsTileWalkable(goal)) return null;

			int worldSizeX = ControllerHelper.worldController.world.worldSizeX;
			int worldSizeY = ControllerHelper.worldController.world.worldSizeY;

			// Create a list for open and closed sets
			List<Node> openSet = new List<Node>();
			List<Node> closedSet = new List<Node>();

			// Add the starting node to the open set
			Node startingNode = new Node(start, 0, GetHeuristic(start, goal));
			openSet.Add(startingNode);

			while (openSet.Count > 0)
			{
				// Find the node with the lowest F score in the open set
				Node current = openSet.OrderBy(node => node.F).First();

				// Check if we reached the goal
				if (current.position == goal)
				{
					return ReconstructPath(current);
				}

				// Remove current node from open set and add it to closed set
				openSet.Remove(current);
				closedSet.Add(current);

				// Get neighbors of the current node
				foreach (Vector2i neighbor in GetNeighbors(current.position, worldSizeX, worldSizeY))
				{
					// Skip checking if neighbor is outside world bounds or not walkable
					if (!IsWithinBounds(neighbor, worldSizeX, worldSizeY) || !IsTileWalkable(neighbor))
					{
						continue;
					}

					// Check if neighbor is already in closed set
					if (closedSet.Any(node => node.position == neighbor))
					{
						continue;
					}

					// Calculate G score (distance from start)
					int tentativeGScore = current.G + GetMovementCost(current.position, neighbor);

					// Find the node in the open set (if any) with the same position
					Node neighborInOpenSet = openSet.FirstOrDefault(node => node.position == neighbor);

					// If neighbor is not in the open set or the tentative G score is lower
					if (neighborInOpenSet == null || tentativeGScore < neighborInOpenSet.G)
					{
						// Calculate H score (heuristic estimate of distance to goal)
						int tentativeHScore = GetHeuristic(neighbor, goal);
						int tentativeFScore = tentativeGScore + tentativeHScore;

						// Update neighbor information
						if (neighborInOpenSet == null)
						{
							neighborInOpenSet = new Node(neighbor, tentativeGScore, tentativeFScore);
							openSet.Add(neighborInOpenSet);
						}
						else
						{
							neighborInOpenSet.parent = current;
							neighborInOpenSet.G = tentativeGScore;
							neighborInOpenSet.F = tentativeFScore;
						}

						neighborInOpenSet.parent = current;
					}
				}
			}

			// No path found
			return null;
		}

		private static List<Vector2i> GetNeighbors(Vector2i position, int worldSizeX, int worldSizeY)
		{
			List<Vector2i> neighbors = new List<Vector2i>();
			int[] dx = { -1, 0, 1, 0 };
			int[] dy = { 0, -1, 0, 1 };

			for (int i = 0; i < 4; i++)
			{
				int newX = position.x + dx[i];
				int newY = position.y + dy[i];

				if (IsWithinBounds(new Vector2i(newX, newY), worldSizeX, worldSizeY))
				{
					neighbors.Add(new Vector2i(newX, newY));
				}
			}

			return neighbors;
		}

		private static bool IsWithinBounds(Vector2i position, int worldSizeX, int worldSizeY)
		{
			return position.x >= 0 && position.x < worldSizeX && position.y >= 0 && position.y < worldSizeY;
		}

		private static int GetMovementCost(Vector2i from, Vector2i to)
		{
			// You can customize this function based on your game logic (e.g., diagonal movement cost)
			return 1; // Assuming equal movement cost for all directions
		}

		private static int GetHeuristic(Vector2i start, Vector2i goal)
		{
			// You can choose different heuristics (e.g., Manhattan distance, Euclidean distance, Chebyshev distance)
			return ManhattanDistance(start, goal);
		}

		private static int ManhattanDistance(Vector2i start, Vector2i goal)
		{
			return Math.Abs(start.x - goal.x) + Math.Abs(start.y - goal.y);
		}

		private static List<Vector2i> ReconstructPath(Node node)
		{
			List<Vector2i> path = new List<Vector2i>();
			while (node != null)
			{
				path.Add(node.position);
				node = node.parent;
			}
			path.Reverse();
			return path;
		}

		private class Node
		{
			public Vector2i position;
			public Node? parent;
			public int G; // Cost from start node
			public int H; // Heuristic estimate of cost to goal
			public int F; // Total cost (G + H)

			public Node(Vector2i position, int G, int H)
			{
				this.position = position;
				this.G = G;
				this.H = H;
				this.F = G + H;
			}
		}




		public static bool IsTileWalkable(Vector2i MP)
		{
			if (!ControllerHelper.worldController.world.IsMapPointInWorld(MP)) return false;

			World.BlockType blockType = ControllerHelper.worldController.world.GetBlockType(MP);

			if (ConfigData.IsBlockInstakill(blockType)) return false;

			if (blockType == World.BlockType.CloudPlatform || blockType == World.BlockType.TrapdoorMetalPlatform) return true;

			if (ConfigData.IsAnyDoor(blockType) && ControllerHelper.worldController.DoesPlayerHaveRightToGoDoorForCollider(MP)) return true;


			if (ConfigData.IsBlockBattleBarrier(blockType))
			{
				BattleBarrierBasicData battleBarrierBasicData = new BattleBarrierBasicData(1);
				battleBarrierBasicData.SetViaBSON(ControllerHelper.worldController.world.GetWorldItemData(MP).GetAsBSON());
				if (battleBarrierBasicData.isOpen) return true;
			}

			if (ConfigData.IsBlockDisappearingBlock(blockType))
			{
				DisappearingBlockData disappearingBlockData = new DisappearingBlockData(1);
				disappearingBlockData.SetViaBSON(ControllerHelper.worldController.world.GetWorldItemData(MP).GetAsBSON());
				if (disappearingBlockData.isOpen) return true;
			}

			if (blockType == World.BlockType.NetherKey || blockType == World.BlockType.JetRaceForcefieldStart || blockType == World.BlockType.JetRaceFinishline || blockType == World.BlockType.JetRaceCrestGold || blockType == World.BlockType.PortalMiningEntry || blockType == World.BlockType.PortalMineExit) return true;

			return !ConfigData.DoesBlockHaveCollider(blockType);
		}

	}
}
