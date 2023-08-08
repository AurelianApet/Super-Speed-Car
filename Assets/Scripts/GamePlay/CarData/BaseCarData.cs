using UnityEngine;
using System.Collections;

public abstract class BaseCarData : CachingMonoBehaviour
{
	public static Vector3 TRAIL_OFFSET = new Vector3 (0, 0.1f, 0);
	public static Vector3 DOWN_PRESSURE = new Vector3 (0, -100000, 0);

	//--------------------------------------------------------------------------------
	protected int id;
	
	public int ID {
		get {
			return id;
		}
		set {
			id = value;
		}
	}

	//--------------------------------------------------------------------------------
	public Vector3 centerOfMass;
	public Transform[] frontWheels;
	public Transform[] rearWheels;
	
	//--------------------------------------------------------------------------------
	public float wheelRadius = 0.5f;
	public float suspensionRange = 0.1f;
	public bool isPlayer = true;
	public bool isPolice = false;

	//--------------------------------------------------------------------------------
	public LightBlastController lightBlastController;
	public NitroController nitro;
	public SmokeController smoke;
	public GameObject[] backLight;
	public OrderNumberController OrderNumberController;
	public GameObject sparkRight;
	public GameObject sparkLeft;
	public PlayerAvatarController playerAvatarController;

	//--------------------------------------------------------------------------------
	protected float currentTopSpeed;

	public float CurrentTopSpeed {
		get {
			return currentTopSpeed;
		}
	}

	protected float initialTopSpeed;

	public float InitialTopSpeed {
		get {
			return initialTopSpeed;
		}
	}

	//--------------------------------------------------------------------------------
	private float initialAccelerationFactor;

	public float InitialAccelerationFactor {
		get {
			return initialAccelerationFactor;
		}
		set {
			initialAccelerationFactor = value;
		}
	}

	private float currentAccelerationFactor;

	public float CurrentAccelerationFactor {
		get {
			return currentAccelerationFactor;
		}
		set {
			if (currentAccelerationFactor < initialAccelerationFactor) {
				currentAccelerationFactor = value;
			} else {
				currentAccelerationFactor = initialAccelerationFactor;
			}
		}
	}

	private float accelerationMultiplier = 1;

	public float AccelerationMultiplier {
		get {
			return accelerationMultiplier;
		}
		set {
			accelerationMultiplier = value;
		}
	}

	//--------------------------------------------------------------------------------
	private float handlingFactor;

	public float HandlingFactor {
		get {
			return handlingFactor;
		}
		set {
			handlingFactor = value;
		}
	}

	protected int turnSpeedDegree;

	//--------------------------------------------------------------------------------
	float nitroBar;

	public float NitroBar {
		get {
			return nitroBar;
		}
		set {
			if (value > 100) {
				nitroBar = 100;
			} else if (value < 0) {
				nitroBar = 0;
			} else {
				nitroBar = value;
			}
		}
	}

	private float nitroRate;

	public float NitroRate {
		get {
			return nitroRate;
		}
		set {
			nitroRate = value;
		}
	}

	protected float nitroMultiplier;

	public float NitroMultiplier {
		get {
			return nitroMultiplier;
		}
		set {
			nitroMultiplier = value;
		}
	}

	protected float nitroUsingDuration = 0;

	public float TotalNitroUsingDuration {
		get {
			return nitroUsingDuration;
		}
	}

	//--------------------------------------------------------------------------------
	protected int totalNumberNitroEarned = 0;

	public int TotalNumberNitroEarned {
		get {
			return totalNumberNitroEarned;
		}
		set {
			totalNumberNitroEarned = value;
		}
	}

	protected float nitroEarned = 0;

	public float NitroEarned {
		get {
			return nitroEarned;
		}
		set {
			nitroEarned = value;
			totalNumberNitroEarned++;
		}
	}

	protected float lastNitroEarnedTime;

	public float LastNitroEarnedTime {
		get {
			return lastNitroEarnedTime;
		}
		set {
			lastNitroEarnedTime = value;
		}
	}

	protected int lastNitroEarned;

	public int LastNitroEarned {
		get {
			return lastNitroEarned;
		}
		set {
			lastNitroEarned = value;
		}
	}

	//--------------------------------------------------------------------------------
	protected int totalDollarEarned = 0;

	public int TotalDollarEarned {
		get {
			return totalDollarEarned;
		}
		set {
			totalDollarEarned = value;
		}
	}

	protected float lastDollarEarnedTime;

	public float LastDollarEarnedTime {
		get {
			return lastDollarEarnedTime;
		}
		set {
			lastDollarEarnedTime = value;
		}
	}

	protected int lastDollarEarned;

	public int LastDollarEarned {
		get {
			return lastDollarEarned;
		}
		set {
			lastDollarEarned = value;
		}
	}

	protected int totalCheckPointEarned;

	public int TotalCheckPointEarned {
		get {
			return totalCheckPointEarned;
		}
	}

	//--------------------------------------------------------------------------------
	float wantedBar;

	public float WantedBar {
		get {
			return wantedBar;
		}
		set {
			if (value > 100) {
				wantedBar = 100;
			} else if (value < 0) {
				wantedBar = 0;
			} else {
				wantedBar = value;
			}
		}
	}

	float policeCaughtBar;

	public float PoliceCaughtBar {
		get {
			return policeCaughtBar;
		}
		set {
			if (value > 100) {
				policeCaughtBar = 100;
			} else if (value < 0) {
				policeCaughtBar = 0;
			} else {
				policeCaughtBar = value;
			}
		}
	}

	//--------------------------------------------------------------------------------
	float totalFlyTime;

	public float TotalFlyTime {
		get {
			return totalFlyTime;
		}
	}

	float flyTime;

	public float FlyTime {
		get {
			return (Time.timeSinceLevelLoad - flyTime);
		}
	}

	float flyDuration;

	public float FlyDuration {
		get {
			return flyDuration;
		}
	}

	bool isFly;
	
	public bool IsFly {
		get {
			return isFly;
		}
		set {
			if (value == true) {
				if (isFly == false) {
					flyTime = Time.timeSinceLevelLoad;
					isFly = true;
					
					this.onFlyStateChange (value);
				}
			} else {
				if (isFly == true) {
					flyDuration = Time.timeSinceLevelLoad - flyTime;
					totalFlyTime += flyDuration;
					isFly = false;
					carController.game.menuRenderer.setLastFly ();					
					this.onFlyStateChange (value);
				}
			}						
		}
	}

	//--------------------------------------------------------------------------------
	protected float driftRemainTime;
	float totalDriftTime;

	public float TotalDriftTime {
		get {
			return totalDriftTime;
		}
	}

	float driftTime;

	public float DriftTime {
		get {
			return (Time.timeSinceLevelLoad - driftTime);
		}
	}

	float driftDuration;

	public float DriftDuration {
		get {
			return driftDuration;
		}
	}

	bool isDrift;

	public bool IsDrift {
		get {
			return isDrift;
		}
		set {
			if (value == true) {
				if (isDrift == false) {
					driftTime = Time.timeSinceLevelLoad;
					isDrift = true;			
				}
			} else {
				if (isDrift == true) {
					driftRemainTime = 1;
					driftDuration = Time.timeSinceLevelLoad - driftTime;
					totalDriftTime += driftDuration;
					isDrift = false;
					carController.game.menuRenderer.setLastDrift ();
				}
			}
		}
	}

	protected float lastBrake;
	protected float lastSteer;

	//--------------------------------------------------------------------------------
	int totalObstacleCollision;

	public int TotalObstacleCollision {
		get {
			return totalObstacleCollision;
		}
		set {
			lastObstacleCollisionTime = Time.timeSinceLevelLoad;
			totalObstacleCollision = value;
			this.NitroBar += 3 * (GameData.IsDoubleNitro == true ? 2 : 1);
		}
	}

	float lastObstacleCollisionTime;

	public float LastObstacleCollisionTime {
		get {
			return lastObstacleCollisionTime;
		}
	}
	
	protected float brokenGlassForce;	

	//--------------------------------------------------------------------------------
	protected float stuckTime;
	protected float lastWrongWay;
	protected bool isWrongWay;

	//--------------------------------------------------------------------------------
	protected BaseCarController carController;
	
	public BaseCarController CarController {
		get {
			return carController;
		}
	}

	//--------------------------------------------------------------------------------
	public void initPlayerCarData ()
	{		
		GameData.CAR_NAME carName = GameData.getCarName (ProfileManager.userProfile.SelectedCar);

		if (GameData.IsTuningKit == false) {
			CarProfile selectedCar = ProfileManager.userProfile.CarProfile [ProfileManager.userProfile.SelectedCar];
		
			initialTopSpeed = AllCarDescription.getCarSpeed (carName, selectedCar.Speed);
			initialAccelerationFactor = AllCarDescription.getCarAcceleration (carName, selectedCar.Acceleration);
			handlingFactor = AllCarDescription.getCarHandling (carName, selectedCar.Handling);
			nitroRate = 100f / AllCarDescription.getCarNitro (carName, selectedCar.Nitro);
		} else {
			initialTopSpeed = AllCarDescription.getCarSpeed (carName, 4);
			initialAccelerationFactor = AllCarDescription.getCarAcceleration (carName, 4);
			handlingFactor = AllCarDescription.getCarHandling (carName, 4);
			nitroRate = 100f / AllCarDescription.getCarNitro (carName, 4);
		}
		
		currentTopSpeed = initialTopSpeed;
		currentAccelerationFactor = 0;

		nitroMultiplier = 1.2f;

		brokenGlassForce = currentTopSpeed / 3;
		
		if (GameData.IsNitroFull == false) {
			nitroBar = 30;
		} else {
			nitroBar = 100;
		}
		
		turnSpeedDegree = 15;
	}

	public void initAICarData ()
	{
		if (this.isPolice == false) {
			currentTopSpeed = EnemySpeedDescription.getEnemySpeed (id);		
			initialAccelerationFactor = Random.Range (0.5f, 2f);
		} else {
			currentTopSpeed = carController.game.carManager.MainPlayer.carData.initialTopSpeed * 1.2f;			
			initialAccelerationFactor = 2f;	
		}

		handlingFactor = 1f;
		initialTopSpeed = currentTopSpeed;

		currentTopSpeed = initialTopSpeed;
		currentAccelerationFactor = 0;
		
		turnSpeedDegree = 70;
	}

	public void resetStuck ()
	{
		this.stuckTime = 0;
		this.isWrongWay = false;
		this.isDrift = false;
		this.carController.handlingInfo.steer = 0;
		this.carController.useNitro (false);
		this.carController.useBrake (false);

		this.nitro.clearAllNitro ();
		this.smoke.deactivateSmoke ();
		this.carController.game.trailController.clearAllTrail ();
		
		this.currentAccelerationFactor = 0;
		this.rigidbody.constraints = RigidbodyConstraints.None;
	}

	public void freezeAll ()
	{
		this.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		this.gameObject.SetActive (false);
	}

	public abstract void onFlyStateChange (bool state);
}