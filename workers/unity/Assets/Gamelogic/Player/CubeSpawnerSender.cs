using Improbable.Player;
using Improbable.Unity;
using Improbable.Unity.Common.Core.Math;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Player
{
	[WorkerType(WorkerPlatform.UnityClient)]
	public class CubeSpawnerSender : MonoBehaviour
	{
		[Require] private CubeSpawner.Writer CubeSpawnerWriter;

		private void Update()
		{
			if (Input.GetMouseButtonUp(0)) {
				var spawnPosition = new Vector3(0, 3, 0);

				CubeSpawnerWriter.Send(new CubeSpawner.Update()
					.AddSpawn(new Spawn(spawnPosition.ToSpatialCoordinates())));
			}
		}
	}
}