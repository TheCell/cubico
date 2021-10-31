using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRespawnPoint : MonoBehaviour
{
	[SerializeField] private Transform spawnPoint;
	[SerializeField] private RespawnEffect respawnEffect;
	[SerializeField] private ParticleSystem activeParticles;
	[SerializeField] private GameObject icoSphere;
	[SerializeField] private Material activeMaterial;
	public bool isActive = false;
	private TurnObject turnScript;
	private Material standardMaterial;
	private float standardTurnSpeed;
	public GameObject SDobj;
	public StatsDisplay SD;

	AudioSource soundEffectWhenSet;

	private void Start()
	{
		SDobj = GameObject.Find("Stats");
		SD = SDobj.GetComponent<StatsDisplay>();
		SD.CheckpointsReached = 0;
		if (icoSphere == null)
		{
			Debug.LogError("icoSphere not set");
		}
		if (activeMaterial == null)
		{
			Debug.LogError("activeMaterial not set");
		}
		standardMaterial = icoSphere.GetComponent<MeshRenderer>().material;
		turnScript = icoSphere.GetComponent<TurnObject>();
		standardTurnSpeed = turnScript.turnSpeed;

		soundEffectWhenSet = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (!isActive)
		{
			turnScript.turnSpeed = standardTurnSpeed;
			activeParticles.Stop();
			icoSphere.GetComponent<MeshRenderer>().material = standardMaterial;
			return;
		}

		if (!activeParticles.isPlaying)
		{
			activeParticles.Play();
		}
		turnScript.turnSpeed = 100f;
		icoSphere.GetComponent<MeshRenderer>().material = activeMaterial;
		SDobj = GameObject.Find("Stats");
		SD = SDobj.GetComponent<StatsDisplay>();
	}

	private void OnTriggerEnter(Collider collider)
	{
		RespawnInfo respawnInfo = collider.gameObject.GetComponent<RespawnInfo>();
		if (respawnInfo == null)
		{
			return;
		}

		respawnInfo.RespawnPosition = spawnPoint.position;
		respawnInfo.RespawnEffect = respawnEffect;
		if (respawnInfo.currentRespawn != null)
		{
			respawnInfo.currentRespawn.isActive = false;
		}
		respawnInfo.currentRespawn = this;
		if (!isActive)
		{
			soundEffectWhenSet.Play();
			SD.CheckpointsReached += 1;
		}
		isActive = true;
	}
}
