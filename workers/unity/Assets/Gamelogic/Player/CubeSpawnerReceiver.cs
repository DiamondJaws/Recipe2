using Assets.Gamelogic.EntityTemplates;
using Improbable;
using Improbable.Player;
using Improbable.Unity;
using Improbable.Unity.Core;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Player
{
	[WorkerType(WorkerPlatform.UnityWorker)]
	public class CubeSpawnerReceiver : MonoBehaviour
	{
		[Require] private Position.Writer PositionWriter;
		[Require] private CubeSpawner.Reader CubeSpawnerReader;

		private void OnEnable()
		{
			CubeSpawnerReader.SpawnTriggered.Add(CreateCube);
		}

		private void OnDisable()
		{
			CubeSpawnerReader.SpawnTriggered.Remove(CreateCube);
		}

		private void CreateCube(Spawn args)
		{
			var cubeTemplate = EntityTemplateFactory.CreateCubeTemplate(args.initialPosition);
			SpatialOS.Commands.CreateEntity(PositionWriter, cubeTemplate);
		}
	}
}