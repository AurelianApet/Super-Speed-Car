using UnityEngine;
using System.Collections;

public class CarData : BaseCarData
{
	float suspensionDamper = 0;
	float suspensionSpringFront = 20000;
	float suspensionSpringRear = 10000;
	Vector3 dragMultiplier = new Vector3 (2, 3, 1);
	Wheel[] wheels;
	WheelFrictionCurve wfc;		
	
	//--------------------------------------------------------------------------------
	float throttle = 0;
	float steer = 0;
	
	//--------------------------------------------------------------------------------
	float[] engineForceValues;
	float[] gearSpeeds;
	int currentGear;
	int numberOfGears = 5;
	float currentEnginePower = 0.0f;
	float handbrakeXDragFactor = 0.5f;
	
	//--------------------------------------------------------------------------------
	bool canDrive;

	//--------------------------------------------------------------------------------
	Vector3 flyForce;
	
	//--------------------------------------------------------------------------------
	float velocityMagnitude;
	
	public float VelocityMagnitude {
		get {
			return velocityMagnitude;
		}
	}
	
	Vector3 relativeVelocity;

	public Vector3 RelativeVelocity {
		get {
			return relativeVelocity;
		}
	}

	bool isNeedSlower;

	//--------------------------------------------------------------------------------
	float turnSpeed;
	float turnRadius;
	float rotationDirection;

	//
	float sqrVel;
	float normPower;
	float value;
	float force;

	void Start ()
	{		
		if (this.id == BaseCarManager.mainPlayerID) {
			this.carController = new PlayerCarController (this);
			this.initPlayerCarData ();
		} else {
			this.carController = new AICarController (this);
			this.initAICarData ();
		}
		
		wheels = new Wheel[frontWheels.Length + rearWheels.Length];
		
		SetupWheelColliders ();		
		SetupGears ();
		
		rigidbody.centerOfMass = centerOfMass;	
		
		flyForce = new Vector3 (0, 3000, Random.Range (500, 1200));

		if (BaseCarManager.mainPlayerID != this.id) {
			playerAvatarController.playerName.text = transform.root.gameObject.name;
		} else {
			playerAvatarController.playerName.text = string.Empty;
		}
	}
	
	void Update ()
	{
		if (Game.gameState == Game.GAME_STATE.RUNNING || Game.gameState == Game.GAME_STATE.PRE_GAME_OVER) {
			if (this.id == BaseCarManager.mainPlayerID) {
				if (carController.handlingInfo.isNitroUsing == true) {					
					if (this.NitroBar > 0) {
						this.IsDrift = false;
						this.NitroBar = this.NitroBar - Time.deltaTime * this.NitroRate;
					} else {						
						carController.useNitro (false);
					}
				} else {
					this.NitroBar = this.NitroBar + Time.deltaTime * (GameData.IsDoubleNitro == true ? 2 : 1);
				}
			}
			
			if (GameData.isSinglePlayer == true) {	
				this.UpdateSteer ();

				if (this.id == BaseCarManager.mainPlayerID) {
					if (this.velocityMagnitude > GameData.maxVelocityLimit) {
						GameData.maxVelocityLimit = this.velocityMagnitude;
					}
					this.UpdateCarData ();

				} else {	
					this.updateEnemyCarData ();										
				}
			} else {
				if (this.id == BaseCarManager.mainPlayerID) {					
					this.UpdateSteer ();	
					this.UpdateCarData ();
				}
			}
			
			currentGear = 0;
			int i;
			for (i = 0; i < numberOfGears - 1; i++) {
				if (relativeVelocity.z > gearSpeeds [i])
					currentGear = i + 1;
			}
			
			for (i=0; i<frontWheels.Length; i++) {
				frontWheels [i].Rotate (velocityMagnitude * 100 * Time.deltaTime, 0, 0);
				rearWheels [i].Rotate (velocityMagnitude * 100 * Time.deltaTime, 0, 0);
			}
		}
	}
	
	void FixedUpdate ()
	{	
		if (Game.gameState == Game.GAME_STATE.RUNNING || Game.gameState == Game.GAME_STATE.PRE_GAME_OVER) {
			// The rigidbody velocity is always given in world space, but in order to work in local space of the car model we need to transform it first.
			relativeVelocity = transform.InverseTransformDirection (rigidbody.velocity);
			velocityMagnitude = this.rigidbody.velocity.magnitude;
			
			CalculateState ();	
			
			UpdateFriction ();
			
			UpdateDrag ();
			
			CalculateEnginePower ();
			
			ApplyControl ();
		}
	}

	void LateUpdate ()
	{
		if (Game.gameState == Game.GAME_STATE.RUNNING || Game.gameState == Game.GAME_STATE.PRE_GAME_OVER) {
			if (GameData.isSinglePlayer == true) {			
				if (this.id == BaseCarManager.mainPlayerID) {
					this.UpdateEffect ();
				} else {
					this.UpdateEnemyEffect ();
				}
			} else {
				if (this.id == BaseCarManager.mainPlayerID) {			
					this.UpdateEffect ();
				}
			}
		}
	}
	
	/**************************************************/
	/* Functions called from Start()                  */
	/**************************************************/	
	void SetupWheelColliders ()
	{
		wfc = new WheelFrictionCurve ();
		wfc.extremumSlip = 1;
		wfc.extremumValue = 50;
		wfc.asymptoteSlip = 2;
		wfc.asymptoteValue = 25;
		wfc.stiffness = 1;
		
		int wheelCount = 0;
		
		foreach (Transform t  in frontWheels) {
			wheels [wheelCount] = SetupWheel (t, true);
			wheelCount++;
		}
		
		foreach (Transform t  in rearWheels) {
			wheels [wheelCount] = SetupWheel (t, false);
			wheelCount++;
		}
	}
	
	Wheel SetupWheel (Transform wheelTransform, bool isFrontWheel)
	{
		GameObject go = new GameObject (wheelTransform.name + " Collider");
		go.transform.position = wheelTransform.position;
		go.transform.parent = transform;
		go.transform.rotation = wheelTransform.rotation;
		
		WheelCollider wc = go.AddComponent (typeof(WheelCollider)) as WheelCollider;
		wc.suspensionDistance = suspensionRange;
		JointSpring js = wc.suspensionSpring;
		
		if (isFrontWheel)
			js.spring = suspensionSpringFront;
		else
			js.spring = suspensionSpringRear;
		
		js.damper = suspensionDamper;
		wc.suspensionSpring = js;
		wc.mass = 100;
		
		Wheel wheel = new Wheel (); 
		wheel.wheelCollider = wc;
		wc.forwardFriction = wfc;
		wc.sidewaysFriction = wfc;
		wheel.wheelCollider.radius = wheelRadius;
		
		if (isFrontWheel) {
			wheel.steerWheel = true;
			
			go = new GameObject (wheelTransform.name + " Steer Column");
			go.transform.position = wheelTransform.position;
			go.transform.rotation = wheelTransform.rotation;
			go.transform.parent = transform;
			wheelTransform.parent = go.transform;
		} else
			wheel.driveWheel = true;
		
		return wheel;
	}
	
	void SetupGears ()
	{
		engineForceValues = new float[numberOfGears];
		gearSpeeds = new float[numberOfGears];
		
		this.SetupGearsSpeed ();		
	}
	
	void SetupGearsSpeed ()
	{
		float tempTopSpeed = currentTopSpeed;
		
		for (int i = 0; i < numberOfGears; i++) {
			if (i > 0)
				gearSpeeds [i] = tempTopSpeed / 4 + gearSpeeds [i - 1];
			else
				gearSpeeds [i] = tempTopSpeed / 4;
			
			tempTopSpeed -= tempTopSpeed / 4;
		}

		float engineFactor = currentTopSpeed / gearSpeeds [gearSpeeds.Length - 1];
		
		for (int i = 0; i < numberOfGears; i++) {
			float maxLinearDrag = gearSpeeds [i] * gearSpeeds [i];// * dragMultiplier.z;
			engineForceValues [i] = maxLinearDrag * engineFactor;
		}
	}

	/**************************************************/
	/* Functions called from Update()            */
	/**************************************************/
	void UpdateSteer ()
	{
		carController.getHandlingInput ();

		throttle = carController.handlingInfo.throttle;
		steer = carController.handlingInfo.steer;

		if (this.id == BaseCarManager.mainPlayerID) {
			if (this.steer > 1) {
				this.steer = 1;
			} else if (this.steer < -1) {
				this.steer = -1;
			}
		} 

		if (steer == 0) {
			frontWheels [0].localEulerAngles = new Vector3 (frontWheels [0].localEulerAngles.x, 0, frontWheels [0].localEulerAngles.z);
			frontWheels [1].localEulerAngles = new Vector3 (frontWheels [1].localEulerAngles.x, 0, frontWheels [1].localEulerAngles.z);

		} else if (steer > 0) {
			frontWheels [0].localEulerAngles = new Vector3 (frontWheels [0].localEulerAngles.x, turnSpeedDegree * Mathf.Abs (steer) - frontWheels [0].localEulerAngles.z, frontWheels [0].localEulerAngles.z);
			frontWheels [1].localEulerAngles = new Vector3 (frontWheels [1].localEulerAngles.x, turnSpeedDegree * Mathf.Abs (steer) - frontWheels [1].localEulerAngles.z, frontWheels [1].localEulerAngles.z);

		} else {
			frontWheels [0].localEulerAngles = new Vector3 (frontWheels [0].localEulerAngles.x, 0 - turnSpeedDegree * Mathf.Abs (steer) - frontWheels [0].localEulerAngles.z, frontWheels [0].localEulerAngles.z);
			frontWheels [1].localEulerAngles = new Vector3 (frontWheels [1].localEulerAngles.x, 0 - turnSpeedDegree * Mathf.Abs (steer) - frontWheels [1].localEulerAngles.z, frontWheels [1].localEulerAngles.z);
		}	
	}

	void UpdateCarData ()
	{
		if (Game.gameState == Game.GAME_STATE.RUNNING) {
			if (carController.game.carManager.isPoliceCaught == false) {
				this.rigidbody.constraints = RigidbodyConstraints.None;
			}

			if (carController.handlingInfo.isNitroUsing == true) {
				nitroUsingDuration += Time.deltaTime;
				carController.game.autoCam.mainCamera.fieldOfView = Mathf.Lerp (carController.game.autoCam.mainCamera.fieldOfView
			                                                                         , 100, Time.deltaTime);
			} else {
				carController.game.autoCam.mainCamera.fieldOfView = Mathf.Lerp (carController.game.autoCam.mainCamera.fieldOfView
			                                                                         , 75, Time.deltaTime);
			}

			if (steer > 0.2f || steer < -0.2f) {
				lastSteer = Time.timeSinceLevelLoad;
			}

			if (this.IsDrift == true) {
				if (driftRemainTime > 0) {
					if (steer > 0.2f || steer < -0.2f) {
						this.driftRemainTime = 0.5f;
					} else {
						this.driftRemainTime -= Time.deltaTime;
					}
				} else {
					this.IsDrift = false;
					this.steer = 0;
				}
			} else {
				if (ProfileManager.setttings.ControllerTilt == true) {
					if (Time.timeSinceLevelLoad - lastSteer < 1) {					
						if (carController.isBrakeUsing () || (Time.timeSinceLevelLoad - lastBrake < 0.5f)) {
							this.IsDrift = true;
						}
					}
				} else {
					if (Time.timeSinceLevelLoad - lastSteer < 1) {				
						if (carController.isBrakeUsing () || (Time.timeSinceLevelLoad - lastBrake < 1.5f)) {
							this.IsDrift = true;
						}
					}
				}
			}
		
			if (this.velocityMagnitude < 5) {					
				stuckTime += Time.deltaTime;
			
			} else {								
				if (stuckTime > 0) {	
					stuckTime -= Time.deltaTime * 5;
				} else {
					this.stuckTime = 0;
				}
			}

			if (stuckTime > 3) {
				carController.game.carManager.respawnPlayerCar ();
			}
			
			if (this.isWrongWay == false) {
				if (carController.game.carManager.isWrongWay (id) == true) {
					this.isWrongWay = true;
					this.lastWrongWay = Time.timeSinceLevelLoad;
				}
			} else {						
				if (carController.game.carManager.isWrongWay (id) == false) {
					this.isWrongWay = false;
				} else {
					if (Time.timeSinceLevelLoad - lastWrongWay > 2) {
						carController.game.carManager.respawnPlayerCar ();
					} 
				}
			}
		
			if (this.velocityMagnitude > 30) {
				if (carController.handlingInfo.isNitroUsing) {
					WantedBar += Time.deltaTime;
				} else {
					WantedBar += Time.deltaTime;
				}
			}

			if (IsFly == true) {
				this.NitroBar += Time.deltaTime * 20 * (GameData.IsDoubleNitro == true ? 2 : 1);
			}

			if (IsDrift == true) {
				this.NitroBar += Time.deltaTime * 5 * (GameData.IsDoubleNitro == true ? 2 : 1);
			}

			if (this.id == BaseCarManager.mainPlayerID) {
				if (GameData.firstPowerUp != null) {
					GameData.firstPowerUp.update (this);
				}

				if (GameData.secondPowerUp != null) {
					GameData.secondPowerUp.update (this);
				}

				if (GameData.thirdPowerUp != null) {
					GameData.thirdPowerUp.update (this);
				}
			}
		}
	}

	void updateEnemyCarData ()
	{
		if (Game.gameState == Game.GAME_STATE.RUNNING) {
			if (this.velocityMagnitude < 5) {					
				stuckTime += Time.deltaTime;
			
			} else {								
				if (stuckTime > 0) {	
					stuckTime -= Time.deltaTime * 5;
				} else {
					this.stuckTime = 0;
				}
			}
		
			if (this.isPolice == false) {				
				if (stuckTime > 3) {
					this.carController.game.carManager.respawnEnemyCar (this.id);
				}
			} else {
				if (stuckTime > 1) {
					this.carController.game.carManager.respawnPoliceCar ();
				}
			}
		
			if (this.isWrongWay == false) {
				if (this.isPolice == false) {
					if (carController.game.carManager.isWrongWay (id) == true) {
						this.isWrongWay = true;
						this.lastWrongWay = Time.timeSinceLevelLoad;
					}
				}
			} else {					
				if (carController.game.carManager.isWrongWay (id) == false) {
					this.isWrongWay = false;
				} else {
					if (Time.timeSinceLevelLoad - lastWrongWay > 1) {
						if (this.isPolice == false) {
							this.carController.game.carManager.respawnEnemyCar (this.id);
						} 
					} 
				}
			}
		}
	}

	/**************************************************/
	/* Functions called from LateUpdate()            */
	/**************************************************/
	void UpdateEffect ()
	{
		if (carController.handlingInfo.throttle < 0) {
			if (relativeVelocity.z > 0) {
				WheelHit leftHit = new WheelHit ();				
				WheelHit rightHit = new WheelHit ();
				
				if (wheels [2].wheelCollider.GetGroundHit (out leftHit) == true &&
					wheels [3].wheelCollider.GetGroundHit (out rightHit) == true) {
					
					carController.game.trailController.makeTrail (leftHit.point + this.rigidbody.velocity / 20 + TRAIL_OFFSET,
					                                              rightHit.point + this.rigidbody.velocity / 20 + TRAIL_OFFSET);
				}
			}
		} else if (carController.handlingInfo.throttle > 0) {
			if (carController.handlingInfo.steer < -0.2f) {
				backLight [0].SetActive (true);
				backLight [1].SetActive (false);
				if (IsFly == false && canDrive == true) {
					smoke.activateSmoke ();
				}

			} else if (carController.handlingInfo.steer > 0.2f) {
				backLight [1].SetActive (true);
				backLight [0].SetActive (false);
				if (IsFly == false && canDrive == true) {
					smoke.activateSmoke ();
				}

			} else {
				backLight [0].SetActive (false);
				backLight [1].SetActive (false);
				smoke.deactivateSmoke ();
			}
		}
		
		if (this.carController.handlingInfo.isNitroUsing == true) {
			Vector3 leftNitro = carController.game.autoCam.mainCamera.WorldToScreenPoint (nitro.getLeftNitro ());
			Vector3 rightNitro = carController.game.autoCam.mainCamera.WorldToScreenPoint (nitro.getRightNitro ());
			
			this.carController.game.menuRenderer.setNitroFlareEffect (leftNitro.x, leftNitro.y, rightNitro.x, rightNitro.y);
		}
	}

	void UpdateEnemyEffect ()
	{
		if (carController.handlingInfo.steer < -0.1f) {
			backLight [0].SetActive (true);
			backLight [1].SetActive (false);
			if (IsFly == false && canDrive == true) {
				smoke.activateSmoke ();
			}
				
		} else if (carController.handlingInfo.steer > 0.1f) {
			backLight [1].SetActive (true);
			backLight [0].SetActive (false);
			if (IsFly == false && canDrive == true) {
				smoke.activateSmoke ();
			}
				
		} else {
			backLight [0].SetActive (false);
			backLight [1].SetActive (false);
			smoke.deactivateSmoke ();
		}
	}	
	
	/**************************************************/
	/* Functions called from FixedUpdate()            */
	/**************************************************/	
	void CalculateState ()
	{
		canDrive = false;

		WheelHit wheelHit;

		for (int i=0; i<wheels.Length; i++) {
			if (wheels [i].wheelCollider.GetGroundHit (out wheelHit)) {								
				if (wheelHit.collider != null) {
					if (wheelHit.collider.gameObject.layer == LayerDefinition.MAP || wheelHit.collider.gameObject.layer == LayerDefinition.OBSTACLE
						|| wheelHit.collider.gameObject.layer == LayerDefinition.PLAYER || wheelHit.collider.gameObject.layer == LayerDefinition.ENEMY
						|| wheelHit.collider.gameObject.layer == LayerDefinition.POLICE) {		
						canDrive = true;
						return;
					}
				}
			}
		}
	}
	
	void UpdateFriction ()
	{
		sqrVel = relativeVelocity.x * relativeVelocity.x;
		
		// Add extra sideways friction based on the car's turning velocity to avoid slipping

		wfc.extremumValue = Mathf.Clamp (300 - sqrVel, 0, 300);
		wfc.asymptoteValue = Mathf.Clamp (150 - (sqrVel / 2), 0, 150);

		for (int i=0; i<wheels.Length; i++) {
			wheels [i].wheelCollider.sidewaysFriction = wfc;
			wheels [i].wheelCollider.forwardFriction = wfc;
		}
	}
	
	void UpdateDrag ()
	{
		Vector3 relativeDrag = new Vector3 (-relativeVelocity.x * Mathf.Abs (relativeVelocity.x), 
		                                    -relativeVelocity.y * Mathf.Abs (relativeVelocity.y), 
		                                    -relativeVelocity.z * Mathf.Abs (relativeVelocity.z));
		
		Vector3 drag = Vector3.Scale (dragMultiplier, relativeDrag);
		
		if (carController.isBrakeUsing ()) { // Handbrake code		
			drag.x /= (relativeVelocity.magnitude / (currentTopSpeed / (1 + 2 * handbrakeXDragFactor)));
			drag.z *= (1 + Mathf.Abs (Vector3.Dot (rigidbody.velocity.normalized, transform.forward)));
			drag += rigidbody.velocity * Mathf.Clamp01 (velocityMagnitude / currentTopSpeed);
		} else { // No handbrake
			drag.x *= currentTopSpeed / relativeVelocity.magnitude;
		}
		
		if (Mathf.Abs (relativeVelocity.x) < 5)
			drag.x = -relativeVelocity.x * dragMultiplier.x;		
		
		rigidbody.AddForce (transform.TransformDirection (drag) * rigidbody.mass * Time.fixedDeltaTime);
	}
	
	void CalculateEnginePower ()
	{
		if (throttle == 0) {
			currentEnginePower -= Time.deltaTime * 200;
		} else if (Mathf.Sign (relativeVelocity.z) == Mathf.Sign (throttle)) {
			normPower = (currentEnginePower / engineForceValues [engineForceValues.Length - 1]) * 2;

			value = 0;
			if (normPower < 1) {
				value = 10 - normPower * 9;
			} else {
				value = 1.9f - normPower * 0.9f;
			}
			currentEnginePower += Time.fixedDeltaTime * 200 * value;
			
		} else {
			currentEnginePower -= Time.fixedDeltaTime * 300;
		}
		
		if (currentGear == 0)
			currentEnginePower = Mathf.Clamp (currentEnginePower, 0, engineForceValues [0]);
		else
			currentEnginePower = Mathf.Clamp (currentEnginePower, engineForceValues [currentGear - 1], engineForceValues [currentGear]);
	}
	
	void ApplyControl ()
	{
		if (this.IsFly == true) {
			this.IsDrift = false;
			this.rigidbody.AddRelativeForce (flyForce);

		} else {
			rigidbody.AddForceAtPosition (DOWN_PRESSURE, frontWheels [0].position);
			rigidbody.AddForceAtPosition (DOWN_PRESSURE, frontWheels [1].position);
			rigidbody.AddForceAtPosition (DOWN_PRESSURE, rearWheels [0].position);
			rigidbody.AddForceAtPosition (DOWN_PRESSURE, rearWheels [1].position);
		}
		
		if (canDrive) {
			if (this.id == BaseCarManager.mainPlayerID) {
				if (IsDrift == false) {
					if (throttle >= 0) {
						if (ProfileManager.setttings.ControllerTilt == true) {
							if (steer < -0.5f || steer > 0.5f) {
								rigidbody.AddForce (transform.forward * Time.fixedDeltaTime * engineForceValues [0] * rigidbody.mass * CurrentAccelerationFactor * HandlingFactor);
							} else {
								rigidbody.AddForce (transform.forward * Time.fixedDeltaTime * engineForceValues [0] * rigidbody.mass * CurrentAccelerationFactor);
							}
						} else {
							rigidbody.AddForce (transform.forward * Time.fixedDeltaTime * engineForceValues [0] * rigidbody.mass * CurrentAccelerationFactor);
						}
					} else {
						this.IsDrift = false;
						rigidbody.AddForce (transform.forward * Time.fixedDeltaTime * throttle * engineForceValues [0] * rigidbody.mass);
					}
				} else {
					rigidbody.AddForce (transform.forward * Time.fixedDeltaTime * engineForceValues [0] * rigidbody.mass * CurrentAccelerationFactor * HandlingFactor);
				}
			} else {
				if (isNeedSlower == true) {
					rigidbody.AddForce (transform.forward * Time.fixedDeltaTime * engineForceValues [0] * rigidbody.mass * CurrentAccelerationFactor);
				} else {
					rigidbody.AddForce (transform.forward * Time.fixedDeltaTime * engineForceValues [0] * rigidbody.mass * CurrentAccelerationFactor * 2);
				}
			}
		}
		
		if (velocityMagnitude * 3.6f > currentTopSpeed) {
			rigidbody.velocity = rigidbody.velocity.normalized * currentTopSpeed / 3.6f;
		}

		if (carController.isBrakeUsing () == false) {
			CurrentAccelerationFactor = CurrentAccelerationFactor + Time.fixedDeltaTime * AccelerationMultiplier / 2;
		} 

		turnRadius = 3.0f / Mathf.Sin ((90 - (steer * 30)) * Mathf.Deg2Rad);

		turnSpeed = Mathf.Clamp (relativeVelocity.z / turnRadius, -turnSpeedDegree / 10f, turnSpeedDegree / 10f);
		
		transform.RotateAround (transform.position + transform.right * turnRadius * steer, 
		                        transform.up, turnSpeed * Mathf.Rad2Deg * Time.fixedDeltaTime * steer);

		if (this.IsDrift == true) {
			rotationDirection = Mathf.Sign (steer); // rotationDirection is -1 or 1 by default, depending on steering
			if (steer == 0) {
				if (rigidbody.angularVelocity.y < 1) // If we are not steering and we are handbraking and not rotating fast, we apply a random rotationDirection
					rotationDirection = 0;
				else
					rotationDirection = rigidbody.angularVelocity.y; // If we are rotating fast we are applying that rotation to the car
			}

			// -- Finally we apply this rotation around a point between the cars front wheels.
			transform.RotateAround (transform.TransformPoint ((frontWheels [0].localPosition + frontWheels [1].localPosition) * 0.5f), 
				                        transform.up, 
				                        velocityMagnitude * Mathf.Clamp01 (1 - velocityMagnitude / currentTopSpeed) * rotationDirection * Time.fixedDeltaTime);

			if (this.id == BaseCarManager.mainPlayerID) {
				carController.game.trailController.activateTrail ();

				WheelHit leftHit = new WheelHit ();				
				WheelHit rightHit = new WheelHit ();
				
				if (wheels [2].wheelCollider.GetGroundHit (out leftHit) == true &&
					wheels [3].wheelCollider.GetGroundHit (out rightHit) == true) {

					carController.game.trailController.makeTrail (leftHit.point + this.rigidbody.velocity / 20 + TRAIL_OFFSET,
				                                              rightHit.point + this.rigidbody.velocity / 20 + TRAIL_OFFSET);
				}
				
			}
		} else {		
			if (this.id == BaseCarManager.mainPlayerID) {
				if (carController.isBrakeUsing () == false) {
					carController.game.trailController.deactivateTrail ();
				}
			}
		}
	}

	/**************************************************/
	/*               Car Control	                  */
	/**************************************************/
	public void useNitro (bool value)
	{
		if (value == true) {
			if (NitroBar > 10 && canDrive == true && carController.game.carManager.isPoliceCaught == false) {
				GameData.isUseNitro = true;
				carController.handlingInfo.isNitroUsing = true;
				this.currentTopSpeed = this.initialTopSpeed * nitroMultiplier;		
				this.SetupGearsSpeed ();	

				this.IsDrift = false;
				
				this.nitro.activateNitro ();
				carController.game.soundManager.playEngineNitro ();
				carController.game.autoCam.activateShakeEffect (AutoCam.SHAKE_STATE.NITRO_SHAKE);
			}
		} else {
			carController.handlingInfo.isNitroUsing = false;
			this.currentTopSpeed = this.initialTopSpeed;				
			this.SetupGearsSpeed ();

			this.nitro.deactivateNitro ();
			carController.game.soundManager.playEngine ();
			carController.game.autoCam.activateShakeEffect (AutoCam.SHAKE_STATE.NO_SHAKE);
		}
	}
	
	public void useBrake (bool value)
	{
		if (value == true) {
			if (canDrive == true && carController.game.carManager.isPoliceCaught == false) {
				if (this.id == BaseCarManager.mainPlayerID) {
					smoke.activateSmoke (); 
					carController.game.trailController.activateTrail ();

				}
				backLight [0].SetActive (true);
				backLight [1].SetActive (true);
				carController.game.soundManager.playBrake ();
				
				this.CurrentAccelerationFactor = 0;
				this.lastBrake = Time.timeSinceLevelLoad;
			}
		} else {			
			this.CurrentAccelerationFactor = 0;
			smoke.deactivateSmoke ();
			carController.game.trailController.deactivateTrail ();
			backLight [0].SetActive (false);
			backLight [1].SetActive (false);
		}
	}

	public void changeController ()
	{
		this.resetStuck ();

		this.carController = new AICarController (this);		
		this.initAICarData ();

		currentTopSpeed = 250;
		initialTopSpeed = 250;
		this.SetupGearsSpeed ();
	}

	void activateBrokenGlassEffect (float force)
	{
		if (GameData.IsProtectedFromCrash == false) {
			if (force > brokenGlassForce) {
				this.CurrentAccelerationFactor = 0;
				carController.game.soundManager.playCrash ();
				carController.game.menuRenderer.activateBrokenGlassEffect ();
				carController.game.autoCam.activateShakeEffect (AutoCam.SHAKE_STATE.CRASH_SHAKE);
			}
		}
	}

	public override void onFlyStateChange (bool flyState)
	{
		if (flyState == true) {
			carController.game.autoCam.followVelocity = true;
		} else {
			carController.game.autoCam.followVelocity = false;
		}
	}

	public void resetAISpeed ()
	{
		this.isNeedSlower = false;
		this.currentTopSpeed = initialTopSpeed;
		this.SetupGearsSpeed ();
	}
	
	public void changeAISpeed (float newSpeed, bool isToSlow)
	{
		this.isNeedSlower = isToSlow;
		this.currentTopSpeed = newSpeed;
		this.SetupGearsSpeed ();
	}
	
	public void policeCaught ()
	{
		this.rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ
			| RigidbodyConstraints.FreezeRotation;
		this.WantedBar = 0;
		this.PoliceCaughtBar = 0;

		this.carController.useNitro (false);
		this.carController.useBrake (false);

		this.sparkLeft.SetActive (false);	
		this.sparkRight.SetActive (false);	

		this.backLight [0].SetActive (false);
		this.backLight [1].SetActive (false);

		this.smoke.deactivateSmoke ();

		this.carController.game.trailController.deactivateTrail ();
	}

	/**************************************************/
	/*               Event			                  */
	/**************************************************/	
	void OnTriggerEnter (Collider other)
	{
		if (this.id == BaseCarManager.mainPlayerID) {
			if (other.gameObject.layer == LayerDefinition.CHECKPOINT) {
				carController.game.soundManager.playItem ();
				other.gameObject.SetActive (false);
				totalCheckPointEarned++;
				lightBlastController.activateLightBlast ();
			}
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		if (this.id == BaseCarManager.mainPlayerID) {
			if (collision.gameObject.layer == LayerDefinition.BOUND) {
				this.IsDrift = false;

				if (this.IsFly == true) {
					this.IsFly = false;
					carController.game.soundManager.playLanded ();
					carController.game.autoCam.changePivot (new Vector3 (0, 2, 0));
				}

				if (collision.contacts.Length > 0) {
					ContactPoint contact = collision.contacts [0];
					force = Vector3.Dot (contact.normal, this.transform.forward);
					
					if (force < -0.9f || force > 0.9f) {
//						carController.game.carManager.respawnPlayerCar ();
					} else if (force > 0.2f || force < -0.2f) {
						this.activateBrokenGlassEffect (this.velocityMagnitude);
						this.WantedBar += 3;
					}
				}

				this.activateBrokenGlassEffect (this.velocityMagnitude);
				this.WantedBar += 3;

			} else if (collision.gameObject.layer == LayerDefinition.ENEMY) {				
				this.IsDrift = false;		

				if (this.IsFly == true) {
					this.IsFly = false;
					carController.game.soundManager.playLanded ();
					carController.game.autoCam.changePivot (new Vector3 (0, 2, 0));
				}
					
				this.activateBrokenGlassEffect (this.velocityMagnitude);
				this.WantedBar += 3;

			} else if (collision.gameObject.layer == LayerDefinition.POLICE) {				
				this.IsDrift = false;		
				
				if (this.IsFly == true) {
					this.IsFly = false;
					carController.game.soundManager.playLanded ();
					carController.game.autoCam.changePivot (new Vector3 (0, 2, 0));
				}

				this.activateBrokenGlassEffect (this.velocityMagnitude);
				this.WantedBar += 3;

			} else if (collision.gameObject.layer == LayerDefinition.MAP) {
				if (this.IsFly == true) {
					this.IsFly = false;
					carController.game.soundManager.playLanded ();
					carController.game.autoCam.changePivot (new Vector3 (0, 2, 0));
				}
			} else if (collision.gameObject.layer == LayerDefinition.OBSTACLE) {
				this.IsDrift = false;
				carController.game.soundManager.playObstacleCrash ();

			} else if (collision.collider.gameObject.layer == LayerDefinition.VEHICLE) {	
				if (velocityMagnitude * 3.6f > currentTopSpeed * 0.7f) {
					this.CurrentAccelerationFactor = -5;
				} else {
					this.CurrentAccelerationFactor = 0;
				}
				this.carController.useBrake (false);

				carController.game.soundManager.playCrash ();
				carController.game.menuRenderer.activateBrokenGlassEffect ();
				carController.game.autoCam.activateShakeEffect (AutoCam.SHAKE_STATE.CRASH_SHAKE);

				rigidbody.velocity = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
			}
		}
	}

	void OnCollisionStay (Collision collision)
	{
		if (this.id == BaseCarManager.mainPlayerID) {
			if (collision.collider.gameObject.layer != LayerDefinition.MAP) {
				if (this.IsFly == true) {
					this.IsFly = false;
				}

				if (collision.contacts.Length > 0) {
					Vector3 relativePosition = this.transform.InverseTransformPoint (collision.contacts [0].point);
						
					if (relativePosition.x > 0) {								
						sparkRight.SetActive (true);
						sparkLeft.SetActive (false);	

					} else if (relativePosition.x < 0) {
						sparkLeft.SetActive (true);
						sparkRight.SetActive (false);	

					} else {
						sparkLeft.SetActive (false);	
						sparkRight.SetActive (false);	
					}
				}
			} else if (collision.collider.gameObject.layer == LayerDefinition.VEHICLE) {	
				if (velocityMagnitude * 3.6f > currentTopSpeed * 0.7f) {
					this.CurrentAccelerationFactor = -5;
				} else {
					this.CurrentAccelerationFactor = 0;
				}
				this.carController.useBrake (false);

				carController.game.soundManager.playCrash ();
				carController.game.menuRenderer.activateBrokenGlassEffect ();
				carController.game.autoCam.activateShakeEffect (AutoCam.SHAKE_STATE.CRASH_SHAKE);

				rigidbody.velocity = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
			}
		}

		if (collision.collider.gameObject.layer == LayerDefinition.MAP || collision.collider.gameObject.layer == LayerDefinition.OBSTACLE
			|| collision.collider.gameObject.layer == LayerDefinition.PLAYER || collision.collider.gameObject.layer == LayerDefinition.ENEMY
			|| collision.collider.gameObject.layer == LayerDefinition.POLICE) {		
			canDrive = true;
		}
	}

	void OnCollisionExit (Collision collision)
	{
		if (this.id == BaseCarManager.mainPlayerID) {
			if (collision.collider.gameObject.layer != LayerDefinition.MAP) {
				sparkLeft.SetActive (false);
				sparkRight.SetActive (false);

			} else if (collision.collider.gameObject.layer == LayerDefinition.VEHICLE) {	
				if (velocityMagnitude * 3.6f > currentTopSpeed * 0.7f) {
					this.CurrentAccelerationFactor = -5;
				} else {
					this.CurrentAccelerationFactor = 0;
				}
				this.carController.useBrake (false);

				carController.game.soundManager.playCrash ();
				carController.game.menuRenderer.activateBrokenGlassEffect ();
				carController.game.autoCam.activateShakeEffect (AutoCam.SHAKE_STATE.CRASH_SHAKE);

				rigidbody.velocity = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
			}
		}
	}
}